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
    public class Client : User
    {
        private decimal _balance;
        private bool _montlyCard;
        private int _discount;
        private List<Ticket> _ticketList;
        private List<Ticket> _usableTicketList;
        private List<Reservation> _reservationList;
        private List<Transaction> _transactionList;

        public string Username => _username;
        public string Name => _name;
        public string Surname => _surname;
        public string Property => _property;

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public bool MonthlyCard => _montlyCard;
        public int Discount => _discount;
        public List<Ticket> TicketList
        {
            get { return _ticketList; }
            set { _ticketList = value; }
        }
        public List<Ticket> UsableTicketList
        {
            get { return _usableTicketList; }
            set { _usableTicketList = value; }
        }
        public List<Reservation> ReservationList => _reservationList;
        public List<Transaction> TransactionList => _transactionList;

        public Client(string username,
                      string name,
                      string surname,
                      string property) : base(username, name, surname, property)
        {
            GetInformation();
        }

        public string GetFullName()
        {
            return $"{_name} {_surname}";
        }

        private void GetInformation()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select balance, monthlyCard, discountPercentage
                             from client
                             inner join discountcategory on client.discountID = discountcategory.id
                             where username = @username;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@username", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                _balance = reader.GetDecimal(0);
                _montlyCard = reader.GetBoolean(1);
                _discount = reader.GetInt32(2);
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

        public void GetTickets()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select ticketID, itineraryID, used, delayedItinerary
                          from ticket
                          where clientUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();

                _ticketList = new List<Ticket>();

                while (reader.Read())
                {
                    int ticketID = reader.GetInt32(0);
                    int itineraryID = reader.GetInt32(1);
                    bool used = reader.GetBoolean(2);
                    bool delayedItinerary = reader.GetBoolean(3);
                    _ticketList.Add(new Ticket(ticketID, GetItineraryData(itineraryID), delayedItinerary, used));
                }
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
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
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
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
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
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
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
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }

        public void GetReservations()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select clientUsername, reservationDate, travelDatetime, travelBusLine
                          from reservation
                          where clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                _reservationList = new List<Reservation>();
                while (reader.Read())
                {
                    _reservationList.Add(new Reservation(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3)));
                }
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

        public void GetTransactions()
        {
            _transactionList = new List<Transaction>();
            foreach (var ticket in _ticketList)
            {
                _transactionList.Add(GetTransaction(ticket));
            }
        }

        public Transaction GetTransaction(Ticket ticket)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select price, purchaseDatetime
                              from transaction 
                              where ticketID = @ticketID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ticketID", ticket.ID);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return new Transaction(reader.GetDecimal(0), ticket, reader.GetDateTime(1));
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

        public List<string> GetBusLinesNumbers()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var statement = @"select number
                              from busline;";

                using var cmd = new MySqlCommand(statement, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();
                List<string> busLines = new List<string>();

                while (reader.Read())
                {
                    busLines.Add(reader.GetInt32(0).ToString());
                }
                return busLines;
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

        public decimal GetTicketPrice()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select price
                          from ticketprice;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                return reader.GetDecimal(0);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return -1;
            }
        }



        public decimal CalculateTicketPrice(decimal price)
        {
            return price - (_discount / 100.0m * price);
        }

        public bool CanAffordCost(decimal ticketCost)
        {
            return _balance >= ticketCost;
        }

        public void PayForTicket(decimal price)
        {
            _balance -= price;
        }

        public List<ItineraryInfo> GetMatchingItineraries(string busLineNumber, string travelDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itineraryID, availableSeats
                          from Itinerary
                          where travelDatetime = @travelDatetime and busLineNumber = @busLineNumber";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@travelDatetime", travelDatetime.ToString());
                cmd.Parameters.AddWithValue("@busLineNumber", busLineNumber);

                List<ItineraryInfo> itineraryInfo = new List<ItineraryInfo>();
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    itineraryInfo.Add(new ItineraryInfo() { ItineraryID = reader.GetInt32(0), AvailableSeats = reader.GetInt32(1) });
                }

                return itineraryInfo;
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

        public void InsertTicketToDatabase(int itineraryID)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"insert into Ticket (delayedItinerary, used, issued, clientUsername, itineraryID) values 
	                        (false, false, false, @clientUsername, @itineraryID);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@delayedItinerary", false);
                cmd.Parameters.AddWithValue("@used", false);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                cmd.Parameters.AddWithValue("@itineraryID", itineraryID);
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

        public void DecrementItinerarySeats(int itineraryID, int oldSeatsNumber)
        {
            try
            {
                oldSeatsNumber--;
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"UPDATE Itinerary
                          SET availableSeats = @availableSeats
                          WHERE itineraryID = @itineraryID;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@availableSeats", oldSeatsNumber);
                cmd.Parameters.AddWithValue("@itineraryID", itineraryID);

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