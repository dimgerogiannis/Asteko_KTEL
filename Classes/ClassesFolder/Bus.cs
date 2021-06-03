using MySql.Data.MySqlClient;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Bus
    {
        private int _id;
        private BusSize _size;

        public int Id => _id;
        public BusSize Size => _size;

        public Bus(int id, BusSize size)
        {
            _id = id;
            _size = size;
        }

        public bool IsAvailableOnHour(string date, string startingHour, int duration)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();
            var query = @"select count(*)
                          from Itinerary
                          inner join BusLine on BusLineNumber = number
                          inner join Bus on Itinerary.busID = Bus.busID
                          where Bus.busID = @busID AND (travelDatetime <= @targetDatetime AND ADDDATE(travelDatetime, INTERVAL duration MINUTE) > @targetDatetime
                          OR @targetDatetime <= travelDatetime AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE)
                          OR travelDatetime <= ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE)
                          OR @targetDatetime > travelDatetime AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE));";

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

        public bool HasItineraryEndTimeAndNoNextItineraryOnSpecificTime(string date, string startingHour, string targetStop)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();
            var query = @"select count(*)
                          from Itinerary
                          inner join BusLine on BusLine.number = busLineNumber
                          inner join Bus on Itinerary.busID = Bus.busID  
                          where Bus.busID = @busID and ADDDATE(travelDatetime, INTERVAL duration MINUTE) = @targetDatetime and (select stopName from Stop where Stop.number = BusLine.number order by id desc limit 1) = @targetStop;";

            var targetDatetime = $"{date} {startingHour}:00";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@busID", _id);
            cmd.Parameters.AddWithValue("@targetDatetime", targetDatetime);
            cmd.Parameters.AddWithValue("@targetStop", targetStop);
            using MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return reader.GetInt32(0) == 1;
        }

        public bool DoesntHaveImmidiatelyItinerary(string date, string startingHour, int duration, string targetStop)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();
            var query = @"select count(*)
                        from Itinerary
                        inner join BusLine on BusLine.number = busLineNumber
                        inner join Bus on Itinerary.busID = Bus.busID  
                        where Bus.busID = @busID AND 
                        (TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:00' AND TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) < '00:30:00'
                        AND (select stopName from Stop where Stop.number = BusLine.number order by Stop.id asc limit 1) != @targetStop);";

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

        public bool FindIfCanBeAccepted(string date, string startingHour, int duration)
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
    }
}