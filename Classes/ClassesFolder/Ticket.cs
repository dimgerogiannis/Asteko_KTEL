using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class Ticket
    {
        private int _id;
        private Itinerary _correspondingItinerary;
        private bool _delayedItinerary;
        private bool _used;

        public int ID => _id;
        public Itinerary CorrespondingItinerary => _correspondingItinerary;
        public bool DelayedItinerary
        {
            get { return _delayedItinerary; }
            set { _delayedItinerary = value; }
        }
        public bool Used
        {
            get { return _used; }
            set { _used = value; }
        }


        public Ticket(int ID, Itinerary correspondingItinerary, bool delayedItinerary, bool used)
        {
            _id = ID;
            _correspondingItinerary = correspondingItinerary;
            _delayedItinerary = delayedItinerary;
            _used = used;
        }

        public void SetAsUsed()
        {
            _used = true;

            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"update Ticket
                          set used = @used
                          where ticketID = @ticketID;";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@used", _used);
            cmd.Parameters.AddWithValue("@ticketID", _id);
            cmd.ExecuteNonQuery();
        }

        public void SetAsDelayed()
        {
            _delayedItinerary = true;

            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"update Ticket 
                          set delayedItinerary = @delayedItinerary
                          where ticketID = @ticketID;";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ticketID", _id);
            cmd.Parameters.AddWithValue("@delayedItinerary", _delayedItinerary);
            cmd.ExecuteNonQuery();
        }

        public void UnsetDelayed()
        {
            _delayedItinerary = false;

            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"update Ticket 
                          set delayedItinerary = @delayedItinerary
                          where ticketID = @ticketID;";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ticketID", _id);
            cmd.Parameters.AddWithValue("@delayedItinerary", _delayedItinerary);
            cmd.ExecuteNonQuery();
        }
    }
}
