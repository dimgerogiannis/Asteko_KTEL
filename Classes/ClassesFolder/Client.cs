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
        private decimal _balance;
        private bool _monthlyCard;
        private int _discount;
        private List<Ticket> _ticketList;
        private List<Ticket> _usableTicketList;
        private List<Reservation> _reservationList;
        private List<Poll> _availablePolls;


        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public bool MonthlyCard => _monthlyCard;
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
        public List<Poll> AvailablePolls => _availablePolls;

        public Client(string username,
                      string name,
                      string surname,
                      Specialization property) : base(username, name, surname, property)
        {
            FindInformation();
            InitializeAvailablePolls();
            InitializeReservationList();
            _ticketList = new List<Ticket>();
        }


        public void FindInformation()
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
                _monthlyCard = reader.GetBoolean(1);
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

        public void InitializeTicketList()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itineraryID, used, delayedItinerary
                              from ticket
                              where clientUsername = @username and used = @used;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@used", false);
                using MySqlDataReader reader = cmd.ExecuteReader();

                _ticketList = new List<Ticket>();

                while (reader.Read())
                {
                    _ticketList.Add(new Ticket(GetItineraryData(reader.GetInt32(0)),
                                               reader.GetBoolean(2),
                                               reader.GetBoolean(1)));
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
                                     Functions.GetBusDriverByUsername(busDriverUsername),
                                     Functions.GetBusLine(busLineNumber),
                                     Functions.GetBus(busID),
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

        public void InitializeReservationList()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select clientUsername, reservationDate, travelDatetime, travelBusLine, chargedPrice
                          from reservation
                          where clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                _reservationList = new List<Reservation>();
                while (reader.Read())
                {
                    _reservationList.Add(new Reservation(this,
                                                         reader.GetDateTime(1),
                                                         reader.GetDateTime(2),
                                                         Functions.GetBusLine(reader.GetInt32(3)),
                                                         reader.GetDecimal(4)));
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

        public decimal GetStandardTicketPrice()
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
                                                  Functions.GetBusDriverByUsername(busDriverUsername),
                                                  Functions.GetBusLine(_busLineNumber),
                                                  Functions.GetBus(busID),
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

        public void AutomaticTicketPurchase(Itinerary itinerary)
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
                cmd.Parameters.AddWithValue("@itineraryID", itinerary.ID);
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

        public void InsertReservationToDatabase(Reservation reservation)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into Reservation(reservationDate, travelDatetime, travelBusLine, chargedPrice, clientUsername) values 
	                     (CURRENT_TIME(), @travelDatetime, @travelBusLine, @chargedPrice, @clientUsername);";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@travelDatetime", reservation.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@travelBusLine", reservation.TravelBusLine.Number);
                cmd.Parameters.AddWithValue("@chargedPrice", reservation.ChargedPrice);
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

        public void InsertLastMinuteTravelRequestToDatabase(LastMinuteTravelRequest request)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into LastMinuteTravelRequest (applicationDate, travelDatetime, travelBusLine, status, clientUsername) values
                          (@applicationDate, @travelDatetime, @travelBusLine, @status, @clientUsername);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@applicationDate", request.ApplicationDate);
                cmd.Parameters.AddWithValue("@travelDatetime", request.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@travelBusLine", request.TravelBusLine.Number);
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.Parameters.AddWithValue("@clientUsername", request.ApplicantClient.Username);
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

                cmd.Parameters.AddWithValue("@category", Enums.CategoryFromEnumToDatabaseEquivalant(application.Category));
                cmd.Parameters.AddWithValue("@phoneNumber", application.PhoneNumber);
                cmd.Parameters.AddWithValue("@taxID", application.TaxIdentificationNumber);
                cmd.Parameters.AddWithValue("@clientUsername", application.ApplicantClient.Username);
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
                          where clientUsername = @clientUsername and status = @status";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);
                cmd.Parameters.AddWithValue("@status", "pending");
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

        public List<DiscountApplication> GetDiscountApplications()
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
                    string phoneNumber = reader.GetInt64(3).ToString();
                    string taxID = reader.GetInt64(5).ToString();

                    discountApplications.Add(new DiscountApplication(this,
                                                                     applicationDatetime,
                                                                     possibleRejectionReason,
                                                                     Enums.CategoryFromDatabaseToEnumEquivalant(reader.GetString(2)),
                                                                     taxID,
                                                                     phoneNumber,
                                                                     Enums.StatusFromDatabaseToEnumEquivalant(reader.GetString(4)),
                                                                     null));
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

                var query = @"select itinerary.itineraryID, status, travelDatetime, busDriverUsername, busLineNumber, busID , availableSeats, fired
                              from itinerary
                              inner join ticket on ticket.itineraryID = itinerary.itineraryID
                              inner join busdriver on busdriver.username = itinerary.busDriverUsername
                              where clientUsername = @clientUsername and used = 1
                              order by itinerary.itineraryID desc limit 1;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _username);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read() || reader.GetBoolean(7))
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
                                     Functions.GetBusDriverByUsername(busDriverUsername),
                                     Functions.GetBusLine(busLineNumber),
                                     Functions.GetBus(busID),
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

        public void InitializeAvailablePolls()
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
                cmd.Parameters.AddWithValue("@clientUsername", complaint.ComplaintClient.Username);
                cmd.Parameters.AddWithValue("@targetUsername", complaint.TargetDriver.Username);
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

        public List<Ticket> GetTickets(string from, string to)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select ticket.itineraryID, delayedItinerary, used
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
                                                            reader.GetBoolean(1),
                                                            reader.GetBoolean(2)));
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

        public int GetMonthlyCardPrice()
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
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select id
                          from discountcategory
                          where category = @category;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@category", Enums.CategoryFromEnumToDatabaseEquivalant(category));
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
                cmd.Parameters.AddWithValue("@targetUsername", petition.TargetDriver.Username);
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
                cmd.Parameters.AddWithValue("@targetUsername", petition.TargetDriver.Username);
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
                    lastMinuteTravelRequests.Add(new LastMinuteTravelRequest(this,
                                                                             reader.GetDateTime(0).ToString("dd-MM-yyyy"),
                                                                             reader.GetDateTime(1),
                                                                             Functions.GetBusLine(reader.GetInt32(2)),
                                                                             Enums.StatusFromDatabaseToEnumEquivalant(reader.GetString(3))));
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

        public void DeleteLastMinuteTravelRequest(LastMinuteTravelRequest request)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from LastMinuteTravelRequest
                             where clientUsername = @username and travelDatetime = @travelDatetime and travelBusLine = @travelBusLine";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@travelDatetime", request.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@travelBusLine", request.TravelBusLine.Number);
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

        public int GetLastTicketID()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select max(ticketID)
                                  from ticket
                                  where clientUsername = @username;";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", _username);
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
    }
}
