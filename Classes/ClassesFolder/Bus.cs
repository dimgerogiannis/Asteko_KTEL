using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Bus
    {
        private int _id;
        private BusSize _size;

        public int ID => _id;
        public BusSize Size => _size;

        public Bus(int id, BusSize size)
        {
            _id = id;
            _size = size;
        }

        public bool IsAvailableOnHour(string date, string startingHour, int duration)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                          from Itinerary
                          inner join BusLine on BusLineNumber = number
                          inner join Bus on Itinerary.busID = Bus.busID
                          where Bus.busID = @busID AND (travelDatetime >= @targetDatetime and travelDatetime < ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) or
                            ADDDATE(travelDatetime, INTERVAL duration MINUTE) > @targetDatetime and ADDDATE(travelDatetime, INTERVAL duration MINUTE) <= ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) or
                            travelDatetime <= @targetDatetime and ADDDATE(travelDatetime, INTERVAL duration MINUTE) >= ADDDATE(@targetDatetime, INTERVAL @duration MINUTE));";

                var targetDatetime = $"{date} {startingHour}:00";
                var target = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busID", _id);
                cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
                cmd.Parameters.AddWithValue("@duration", duration);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0) == 0;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        public bool DoesntHaveItineraryOnWantedTimeInterval(string date, string startingHour, int duration)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                          from Itinerary
                          inner join BusLine on BusLine.number = busLineNumber
                          inner join Bus on Itinerary.busID = Bus.busID  
                          where Bus.busID = @busID and  (TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:00' AND TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) < '00:30:00' OR
                            TIMEDIFF(travelDatetime, @targetDatetime) < '-30:00:00' AND TIMEDIFF(travelDatetime, @targetDatetime) < '00:00:00');";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busID", _id);
                cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
                cmd.Parameters.AddWithValue("@duration", duration);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0) == 0;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }
   
        public bool HasItineraryOnEndTimeAndNoNextItineraryOnSpecificTime(string date, string startingHour, int duration, string targetStop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusLine on BusLine.number = busLineNumber
                        inner join Bus on Itinerary.busID = Bus.busID  
                        where Bus.busID = @busID AND 
                        ADDDATE(travelDatetime, INTERVAL duration MINUTE) = @targetDatetime and (select stopName from stop where Stop.number = BusLine.number order by Stop.id desc limit 1) = @targetStop;";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@busID", _id);
                cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
                cmd.Parameters.AddWithValue("@targetStop", targetStop);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0) == 1;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        public bool DoesntHaveItineraryAfterTargetItinerary(string date, string startingHour, int duration, string targetStop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusLine on BusLine.number = busLineNumber
                        inner join Bus on Itinerary.busID = Bus.busID  
                        where Bus.busID = @busID AND 
                        (select stopName from stop where Stop.number = BusLine.number order by Stop.id asc limit 1) != @endStop and 
                        TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:00' and 
                        TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) < '00:30:00';";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@busID", _id);
                cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
                cmd.Parameters.AddWithValue("@targetStop", targetStop);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0) == 0;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        public bool MeetsRequirements(string date, string startingHour, int duration)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusLine on BusLine.number = busLineNumber
                        inner join Bus on Itinerary.busID = Bus.busID  
                        where Bus.busID = @busID AND
                        (TIMEDIFF(@targetDatetime, travelDatetime) <= '00:30:00' AND TIMEDIFF(@targetDatetime, travelDatetime) > '00:00:01'
                        OR TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) <= '00:30:00' AND TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:01');";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@busID", _id);
                cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0) == 0;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }
        
        public bool IsRecommended(string date, string startingHour, string startStop, string endStop, int duration)
        {
            if (DoesntHaveItineraryOnWantedTimeInterval(date, startingHour, duration) &&
                HasItineraryOnEndTimeAndNoNextItineraryOnSpecificTime(date, startingHour, duration, startStop) &&
                DoesntHaveItineraryAfterTargetItinerary(date, startingHour, duration, endStop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}