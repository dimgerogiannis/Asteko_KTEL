using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Itinerary
    {
        private int _id;
        private DateTime _travelDatetime;
        private string _responsibleDriver;
        private BusLine _itineraryLine;
        private Bus _responsibleBus;
        private ItineraryStatus _status;

        public int ID => _id;
        public DateTime TravelDatetime => _travelDatetime;
        public string ResponsibleDriver => _responsibleDriver;
        public BusLine ItineraryLine => _itineraryLine;
        public Bus ResponsibleBus => _responsibleBus;
        public ItineraryStatus Status 
        { 
            get { return _status; } 
            set { _status = value; } 
        }

        public Itinerary(int ID, 
                         DateTime travelDatetime, 
                         string responsibleDriver, 
                         BusLine itineraryLine, 
                         Bus responsibleBus, 
                         ItineraryStatus status)
        {
            _id = ID;
            _travelDatetime = travelDatetime;
            _responsibleDriver = responsibleDriver;
            _itineraryLine = itineraryLine;
            _responsibleBus = responsibleBus;
            _status = status;
        }

        public List<Ticket> GetTickets()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select ticketID, itineraryID, used, delayedItinerary
                              from ticket
                              where itineraryID = @itineraryID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itineraryID", _id);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Ticket> tickets = new List<Ticket>();

                while (reader.Read())
                {
                    int ticketID = reader.GetInt32(0);
                    int itineraryID = reader.GetInt32(1);
                    bool used = reader.GetBoolean(2);
                    bool delayedItinerary = reader.GetBoolean(3);
                    tickets.Add(new Ticket(ticketID, GetItineraryData(itineraryID), delayedItinerary, used));
                }

                return tickets;
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        private Itinerary GetItineraryData(int itineraryID)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select status, travelDatetime, busDriverUsername, busLineNumber, busID
                              from itinerary
                              where itineraryID = @itineraryID";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itineraryID", itineraryID);

                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                string status = reader.GetString(0);
                ItineraryStatus enumStatus = status == "no_delayed" ? ItineraryStatus.NoDelayed : ItineraryStatus.Delayed;

                DateTime travelDatetime = reader.GetDateTime(1);

                string busDriverUsername = reader.GetString(2);

                int busLineNumber = reader.GetInt32(3);

                int busID = reader.GetInt32(4);

                return new Itinerary(itineraryID, travelDatetime, busDriverUsername, GetBusLineData(busLineNumber), GetBusData(busID), enumStatus);
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        private Bus GetBusData(int busID)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select size 
                              from bus 
                              where busID = @busID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busID", busID);
                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                string size = reader.GetString(0);
                BusSize enumSize = BusSize.SMALL;

                switch (size)
                {
                    case "medium":
                        enumSize = BusSize.MEDIUM;
                        break;
                    case "large":
                        enumSize = BusSize.LARGE;
                        break;
                }

                return new Bus(busID, enumSize);
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        private BusLine GetBusLineData(int number)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select duration 
                              from busline 
                              where number = @number;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", number);

                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                return new BusLine(number, reader.GetInt32(0), GetBusLineStops(number));
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        private List<string> GetBusLineStops(int number)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select stopName 
                              from stop 
                              where number = @number;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", number);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<string> stops = new List<string>();

                while (reader.Read())
                {
                    stops.Add(reader.GetString(0));
                }

                return stops;
            }
            catch (MySqlException)
            {
                return null;
            }
        }
    }
}
