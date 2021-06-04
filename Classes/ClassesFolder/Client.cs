using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Client : User
    {
        public string Username => _username;
        public string Name => _name;
        public string Surname => _surname;
        public string Property => _property;

        private decimal _balance;
        private bool _montlyCard;
        private int _discount;
        private List<Ticket> _ticketList;
        private List<Transaction> _transactionList;

        private List<Ticket> _usableTicketList;

        private List<Reservation> _reservationList;
        private List<Poll> _availablePolls;


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
        public List<Transaction> TransactionList
        {
            get { return _transactionList; }
            set { _transactionList = value; }
        }

        public List<Ticket> UsableTicketList
        {
            get { return _usableTicketList; }
            set { _usableTicketList = value; }
        }

        public List<Reservation> ReservationList => _reservationList;
        public List<Poll> AvailablePolls => _availablePolls;

        public Client(string username,
                      string name,
                      string surname,
                      string property) : base(username, name, surname, property)
        {
            GetInformation();
            GetAvailablePolls();
            GetReservations();
            _ticketList = new List<Ticket>();
        }

        public string GetFullName()
        {
            return $"{_name} {_surname}";
        }

        public void GetInformation()
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

                var query = @"select itineraryID, used, delayedItinerary, clientUsername
                              from ticket
                              where clientUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();

                _ticketList = new List<Ticket>();

                while (reader.Read())
                {
                    _ticketList.Add(new Ticket(GetItineraryData(reader.GetInt32(0)),
                                               reader.GetBoolean(2),
                                               reader.GetBoolean(1),
                                               reader.GetString(3)));
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

                var query = @"select status, travelDatetime, busDriverUsername, busLineNumber, busID, availableSeats
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
                int availableSeats = reader.GetInt32(5);

                return new Itinerary(itineraryID,
                                     travelDatetime,
                                     busDriverUsername,
                                     GetBusLineData(busLineNumber),
                                     GetBusData(busID),
                                     enumStatus,
                                     availableSeats);
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
                              from Ticket inner join Transaction on Ticket.ticketID = Transaction.TicketID
                              where itineraryID = @itineraryID and clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itineraryID", ticket.CorrespondingItinerary.ID);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
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

        public Dictionary<string, int> GetBusLinesNumbers()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var statement = @"select number, duration
                                 from busline;";

                using var cmd = new MySqlCommand(statement, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, int> busLines = new Dictionary<string, int>();

                while (reader.Read())
                {
                    busLines.Add(reader.GetInt32(0).ToString(), reader.GetInt32(1));
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
            DecreaseBalance(price);
        }

        private void DecreaseBalance(decimal price)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update Client set balance = balance - @price where username = @username;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@username", _username);
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

        public List<Itinerary> GetMatchingItineraries(string busLineNumber, string travelDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itineraryID, status, travelDatetime, busDriverUsername, busLineNumber, busID, availableSeats
                              from Itinerary
                              where travelDatetime = @travelDatetime and busLineNumber = @busLineNumber";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@travelDatetime", travelDatetime.ToString());
                cmd.Parameters.AddWithValue("@busLineNumber", busLineNumber);

                List<Itinerary> itineraries = new List<Itinerary>();
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int itineraryID = reader.GetInt32(0);
                    string status = reader.GetString(1);
                    ItineraryStatus enumStatus = status == "no_delayed" ? ItineraryStatus.NoDelayed : ItineraryStatus.Delayed;
                    DateTime _travelDatetime = reader.GetDateTime(2);
                    string busDriverUsername = reader.GetString(3);
                    int _busLineNumber = reader.GetInt32(4);
                    int busID = reader.GetInt32(5);
                    int availableSeats = reader.GetInt32(6);

                    itineraries.Add(new Itinerary(itineraryID,
                                                  _travelDatetime,
                                                  busDriverUsername,
                                                  GetBusLineData(_busLineNumber),
                                                  GetBusData(busID),
                                                  enumStatus,
                                                  availableSeats));
                }

                return itineraries;
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

        public void AutomaticTicketPurchase(int itineraryID)
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

        public void InsertReservationToDatabase(Reservation reservation, decimal chargedPrice)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into Reservation(reservationDate, travelDatetime, travelBusLine, chargedPrice, clientUsername) values 
	                     (CURRENT_TIME(), @travelDatetime, @travelBusLine, @chargedPrice, @clientUsername);";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@travelDatetime", reservation.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@travelBusLine", reservation.ResBusLine);
                cmd.Parameters.AddWithValue("@chargedPrice", chargedPrice);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
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

        public int GetLastInsertedTicketID()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select max(ticketID)
                          from ticket
                          where clientUsername = @clientUsername";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return 0;
            }
        }

        public void InsertTransactionToDatabase(int ticketID, decimal price)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into Transaction (ticketID, price, purchaseDatetime) values 
	                          (@ticketID, @price, current_timestamp());";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ticketID", ticketID);
                cmd.Parameters.AddWithValue("@price", price);
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

        public void InsertLastMinuteTravelRequestToDatabase(LastMinuteTravelRequest lastMinuteTravelRequest)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into LastMinuteTravelRequest (applicationDate, travelDatetime, travelBusLine, status, clientUsername) values
                          (@applicationDate, @travelDatetime, @travelBusLine, @status, @clientUsername);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@applicationDate", lastMinuteTravelRequest.ApplicationDate);
                cmd.Parameters.AddWithValue("@travelDatetime", lastMinuteTravelRequest.TravelDatetime);
                cmd.Parameters.AddWithValue("@travelBusLine", lastMinuteTravelRequest.TravelBusLine);
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.Parameters.AddWithValue("@clientUsername", lastMinuteTravelRequest.ClientUsername);
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

        public bool CheckForDuplicateTicket(string busLineNumber, string travelDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select count(*)
                          from ticket
                          inner join Itinerary on Itinerary.itineraryID = Ticket.itineraryID
                          where travelDatetime = @travelDatetime and busLineNumber = @busLineNumber and clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@travelDatetime", travelDatetime);
                cmd.Parameters.AddWithValue("@busLineNumber", busLineNumber);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

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

        public bool CheckForDuplicateReservation(string travelBusLine, string travelDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select count(*)
                          from Reservation
                          where travelDatetime = @travelDatetime and travelBusLine = @travelBusLine and clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@travelDatetime", travelDatetime);
                cmd.Parameters.AddWithValue("@travelBusLine", travelBusLine);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

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

        public bool CheckForDuplicateLastMinuteTravelRequest(string travelBusLine, string travelDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select count(*)
                          from LastMinuteTravelRequest
                          where travelDatetime = @travelDatetime and travelBusLine = @travelBusLine and clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@travelDatetime", travelDatetime);
                cmd.Parameters.AddWithValue("@travelBusLine", travelBusLine);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

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

        public void InsertDiscountApplicationInDatabase(DiscountApplication application)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into DiscountApplication (applicationDatetime, category, phoneNumber, status, taxIdentificationNumber, clientUsername) values
                          (current_timestamp(), @category, @phoneNumber, 'pending', @taxID, @clientUsername);";
                using var cmd = new MySqlCommand(query, connection);

                string category = "student";
                switch (application.Category)
                {
                    case 0:
                        category = "student";
                        break;
                    case (Category)1:
                        category = "soldier";
                        break;
                    case (Category)2:
                        category = "dissabilities";
                        break;
                    case (Category)3:
                        category = "low_income";
                        break;
                }
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@phoneNumber", application.PhoneNumber);
                cmd.Parameters.AddWithValue("@taxID", application.TaxIdentificationNumber);
                cmd.Parameters.AddWithValue("@clientUsername", application.ApplicantUsername);
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

        public int GetDiscountApplicationID()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select applicationID
                          from DiscountApplication
                          where clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return 0;
            }
        }

        public bool CheckForDuplicateDiscountApplication()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select count(*)
                          from DiscountApplication
                          where clientUsername = @clientUsername";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

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

        public void InsertDiscountApplicationFilesInDatabase(int discountApplicationID, List<File> files)
        {
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                    connection.Open();
                    var query = @"insert into file (fileName, fileSize, file, applicationID) values
                          (@fileName, @fileSize, @file, @applicationID);";
                    using var cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.Add("@fileName", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@fileSize", MySqlDbType.Int64);
                    cmd.Parameters.Add("@file", MySqlDbType.LongBlob);
                    cmd.Parameters.Add("@applicationID", MySqlDbType.Int32);

                    cmd.Parameters["@fileName"].Value = files[i].FileName;
                    cmd.Parameters["@fileSize"].Value = files[i].FileContent.Length;
                    cmd.Parameters["@file"].Value = files[i].FileContent;
                    cmd.Parameters["@applicationID"].Value = discountApplicationID;

                    cmd.ExecuteNonQuery();
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

        public List<DiscountApplication> GetDiscountApplicationsFromDatabase()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select applicationDatetime, possibleRejectionReason, category, phoneNumber, status, taxIdentificationNumber
                          from DiscountApplication
                          where clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<DiscountApplication> discountApplications = new List<DiscountApplication>();
                while (reader.Read())
                {
                    DateTime applicationDatetime = reader.GetDateTime(0);
                    string possibleRejectionReason = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string category = reader.GetString(2);
                    string phoneNumber = reader.GetInt64(3).ToString();
                    string status = reader.GetString(4);
                    string taxID = reader.GetInt64(5).ToString();

                    Category cat = Category.Student;
                    switch (category)
                    {
                        case "student":
                            cat = Category.Student;
                            break;
                        case "soldier":
                            cat = Category.Soldier;
                            break;
                        case "low_income":
                            cat = Category.LowIncome;
                            break;
                        case "dissabilities":
                            cat = Category.DissabilityIssues;
                            break;
                    }

                    Status st = Status.Pending;
                    switch (status)
                    {
                        case "pending":
                            st = Status.Pending;
                            break;
                        case "accepted":
                            st = Status.Accepted;
                            break;
                        case "rejected":
                            st = Status.Rejected;
                            break;
                    }

                    discountApplications.Add(new DiscountApplication
                    (
                        _username,
                        applicationDatetime,
                        possibleRejectionReason,
                        cat,
                        taxID,
                        phoneNumber,
                        st,
                        null
                    ));
                }

                return discountApplications;
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

        public void DeleteDiscountApplicationFromDatabase(string applicationDatetime)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from DiscountApplication
                          where clientUsername = @clientUsername and applicationDatetime = @applicationDatetime;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                cmd.Parameters.AddWithValue("@applicationDatetime", applicationDatetime);

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

        public Itinerary GetLatestItinerary()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itinerary.itineraryID, status, travelDatetime, busDriverUsername, busLineNumber, busID , availableSeats
                              from itinerary
                              inner join ticket on ticket.itineraryID = itinerary.itineraryID
                              where clientUsername = @clientUsername and used = 1
                              order by itinerary.itineraryID desc limit 1;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                int itineraryID = reader.GetInt32(0);

                string status = reader.GetString(1);

                ItineraryStatus enumStatus = status == "no_delayed" ? ItineraryStatus.NoDelayed : ItineraryStatus.Delayed;

                DateTime travelDatetime = reader.GetDateTime(2);

                string busDriverUsername = reader.GetString(3);

                int busLineNumber = reader.GetInt32(4);

                int busID = reader.GetInt32(5);
                int availableSeats = reader.GetInt32(6);

                return new Itinerary(itineraryID,
                                     travelDatetime,
                                     busDriverUsername,
                                     GetBusLineData(busLineNumber),
                                     GetBusData(busID),
                                     enumStatus,
                                     availableSeats);
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

        public void GetAvailablePolls()
        {
            try
            {
                var activePolls = FindAvailablePolls();
                List<Poll> availablePolls = new List<Poll>();

                foreach (var poll in activePolls)
                {
                    using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                    connection.Open();
                    var query = @"select count(*)
                                  from PollVote
                                  inner join PollChoice on PollVote.pollChoiceID = PollChoice.pollChoiceID
                                  inner join Poll on PollChoice.title = Poll.title
                                  where PollVote.clientUsername = @clientUsername and Poll.title = @title;";

                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@clientUsername", _username);
                    cmd.Parameters.AddWithValue("@title", poll.Title);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.GetInt32(0) == 0)
                        availablePolls.Add(poll);
                }

                _availablePolls = availablePolls;
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

        public List<Poll> FindAvailablePolls()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select title, startingDate, endingDate, question, expired 
                              from poll
                              where startingDate <= CURRENT_DATE() and endingDate >= CURRENT_DATE();";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Poll> activePolls = new List<Poll>();

                while (reader.Read())
                {
                    activePolls.Add(new Poll(reader.GetString(0),
                                             reader.GetDateTime(1),
                                             reader.GetDateTime(2),
                                             reader.GetString(3),
                                             reader.GetBoolean(4)));
                }

                return activePolls;
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

        public void InsertClientComplaint(ClientComplaint complaint)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into ClientComplaint (targetUsername, checked, summary, category, clientUsername) values
                          (@targetUsername, @checked, @summary, @category, @clientUsername);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", complaint.ClientUsername);
                cmd.Parameters.AddWithValue("@targetUsername", complaint.TargetUsername);
                cmd.Parameters.AddWithValue("@checked", false);
                cmd.Parameters.AddWithValue("@summary", complaint.Summary);
                var category = "";

                switch (complaint.Category)
                {
                    case ClientComplaintCategory.AggresiveBehaviour:
                        category = "aggresive_behavior";
                        break;
                    case ClientComplaintCategory.CarelessDriving:
                        category = "aggresive_driving";
                        break;
                    case ClientComplaintCategory.DrivingRuleViolation:
                        category = "driving_rules_violation";
                        break;
                    case ClientComplaintCategory.LateForNoReason:
                        category = "late_for_no_reason";
                        break;
                    case ClientComplaintCategory.Rude:
                        category = "rude_bus_driver";
                        break;
                }

                cmd.Parameters.AddWithValue("@category", category);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.ToString());
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public List<Ticket> GetTickets(string lastMonth)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select ticket.itineraryID, used, delayedItinerary, clientUsername
                              from ticket
                              inner join itinerary on ticket.itineraryID = itinerary.itineraryID
                              where clientUsername = @username and month(travelDatetime) >= month(@date) and month(travelDatetime) <= month(@date) and year(travelDatetime) = year(@date);";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@date", lastMonth);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Ticket> tickets = new List<Ticket>();

                while (reader.Read())
                {
                    tickets.Add(new Ticket(GetItineraryData(reader.GetInt32(0)),
                                           reader.GetBoolean(2),
                                           reader.GetBoolean(1),
                                           reader.GetString(3)));
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

        public List<Ticket> GetTickets(string from, string to)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select ticketID, ticket.itineraryID, used, delayedItinerary
                          from ticket
                          inner join itinerary on ticket.itineraryID = itinerary.itineraryID
                          where clientUsername = @username and travelDatetime >= @from and travelDatetime <= @to;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Ticket> tickets = new List<Ticket>();

                while (reader.Read())
                {
                    tickets.Add(new Ticket(GetItineraryData(reader.GetInt32(0)),
                                                            reader.GetBoolean(2),
                                                            reader.GetBoolean(1),
                                                            reader.GetString(3)));
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

        public int GetMontlyCardPrice()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select price 
                          from MontlyCardPrice;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
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

        public int GetDiscountCategoryID(Category category)
        {
            try
            {
                string cat = "";
                switch (category)
                {
                    case Category.DissabilityIssues:
                        cat = "dissabilities";
                        break;
                    case Category.LowIncome:
                        cat = "low_income";
                        break;
                    case Category.Soldier:
                        cat = "soldier";
                        break;
                    case Category.Student:
                        cat = "student";
                        break;
                }

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select id
                          from discountcategory
                          where category = @category;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@category", cat);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader.GetInt32(0);
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

        public void UpdateDiscount(Category category)
        {
            try
            {
                var id = GetDiscountCategoryID(category);

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update client
                          set discountID = @discountID
                          where username = @username;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@discountID", id);
                cmd.Parameters.AddWithValue("@username", _username);
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

        public BusDriver GetBusDriver(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select name, surname, salary, experience, hireDate, complaintsCounter
                                  from user 
                                  inner join Employee on User.username = Employee.username
                                  inner join BusDriver on User.username = BusDriver.username
                                  where User.username = @username;";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return new BusDriver(username,
                                     reader.GetString(0),
                                     reader.GetString(1),
                                     "Bus Driver",
                                     reader.GetDecimal(2),
                                     reader.GetInt32(3),
                                     reader.GetString(4),
                                     reader.GetInt32(5));
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

        public bool CheckDuplicateDismissalPetition(DismissalPetition petition)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*) 
                          from DismissalPetition 
                          where targetUsername = @targetUsername;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", petition.TargetUserame);
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

        public void InsertDismissalPetitionInDatabase(DismissalPetition petition)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into DismissalPetition (targetUsername) values (@targetUsername);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", petition.TargetUserame);
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

        public void SetAsUnavailable(Poll poll)
        {
            _availablePolls.Remove(poll);
        }

        public void AddToCollection(Ticket ticket)
        {
            _ticketList.Add(ticket);
        }

        public Itinerary GetItinerary(string datetime, string _busLineNumber)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itineraryID, status, travelDatetime, busDriverUsername, busLineNumber, busID, availableSeats
                              from itinerary
                              where busLineNumber = @busLineNumber and travelDatetime = @travelDatetime";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busLineNumber", _busLineNumber);
                cmd.Parameters.AddWithValue("@travelDatetime", datetime);

                using MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                int itineraryID = reader.GetInt32(0);
                string status = reader.GetString(1);
                ItineraryStatus enumStatus = status == "no_delayed" ? ItineraryStatus.NoDelayed : ItineraryStatus.Delayed;
                DateTime travelDatetime = reader.GetDateTime(2);
                string busDriverUsername = reader.GetString(3);
                int busLineNumber = reader.GetInt32(4);
                int busID = reader.GetInt32(5);
                int availableSeats = reader.GetInt32(6);

                return new Itinerary(itineraryID,
                                     travelDatetime,
                                     busDriverUsername,
                                     GetBusLineData(busLineNumber),
                                     GetBusData(busID),
                                     enumStatus,
                                     availableSeats);
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

        public List<LastMinuteTravelRequest> GetLastMinuteTravelRequests()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select applicationDate, travelDatetime, travelBusLine, status
                          from LastMinuteTravelRequest
                          where clientUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();
                List<LastMinuteTravelRequest> lastMinuteTravelRequests = new List<LastMinuteTravelRequest>();

                while (reader.Read())
                {
                    var status = reader.GetString(3);
                    Status _status = Status.Pending;

                    switch (status)
                    {
                        case "accepted":
                            _status = Status.Accepted;
                            break;
                        case "rejected":
                            _status = Status.Rejected;
                            break;
                    }

                    lastMinuteTravelRequests.Add(new LastMinuteTravelRequest(_username,
                                                                             reader.GetDateTime(0).ToString("dd-MM-yyyy"),
                                                                             reader.GetDateTime(1),
                                                                             reader.GetInt32(2),
                                                                             _status));
                }

                return lastMinuteTravelRequests;
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
    }
}
