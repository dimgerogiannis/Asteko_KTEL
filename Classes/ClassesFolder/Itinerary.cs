using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Itinerary
    {
        private int _id;
        private DateTime _travelDatetime;
        private BusDriver _responsibleDriver;
        private BusLine _itineraryLine;
        private Bus _responsibleBus;
        private ItineraryStatus _status;
        private int _availableSeats;

        public int ID => _id;
        public DateTime TravelDatetime => _travelDatetime;
        public BusDriver ResponsibleDriver => _responsibleDriver;
        public BusLine ItineraryLine => _itineraryLine;
        public Bus ResponsibleBus => _responsibleBus;
        public ItineraryStatus Status 
        { 
            get { return _status; } 
            set { _status = value; } 
        }
        public int AvailableSeats => _availableSeats;

        public Itinerary(int ID, 
                         DateTime travelDatetime, 
                         BusDriver responsibleDriver, 
                         BusLine itineraryLine, 
                         Bus responsibleBus, 
                         ItineraryStatus status,
                         int availableSeats)
        {
            _id = ID;
            _travelDatetime = travelDatetime;
            _responsibleDriver = responsibleDriver;
            _itineraryLine = itineraryLine;
            _responsibleBus = responsibleBus;
            _status = status;
            _availableSeats = availableSeats;
        }

        public List<Ticket> GetTickets()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select delayedItinerary, used
                              from ticket
                              where itineraryID = @itineraryID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itineraryID", _id);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Ticket> tickets = new List<Ticket>();

                while (reader.Read())
                {
                    tickets.Add(new Ticket(this, 
                                           reader.GetBoolean(0),
                                           reader.GetBoolean(1)));
                }

                return tickets;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }

        public void DecrementItinerarySeats()
        {
            try
            {
                _availableSeats--;
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"UPDATE Itinerary
                              SET availableSeats = @availableSeats
                              WHERE itineraryID = @itineraryID;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@availableSeats", _availableSeats);
                cmd.Parameters.AddWithValue("@itineraryID", _id);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
