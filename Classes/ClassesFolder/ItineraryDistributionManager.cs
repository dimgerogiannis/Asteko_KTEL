using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class ItineraryDistributionManager : Employee
    {
        private bool _isResponsibleForWeek;
        public bool IsResponsibleForWeek => _isResponsibleForWeek;

        public ItineraryDistributionManager(string username,
                                            string name,
                                            string surname,
                                            string property,
                                            decimal salary,
                                            int experience,
                                            string hireDate,
                                            bool isResponsibleForWeek) : base(username, name, surname, property, salary, experience, hireDate)
        {
            _isResponsibleForWeek = isResponsibleForWeek;
        }

        public List<Feedback> GetFeedbacks()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select feedbackText
                          from Feedback;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Feedback> feedbacks = new List<Feedback>();

                while (reader.Read())
                {
                    feedbacks.Add(new Feedback(reader.GetString(0)));
                }

                return feedbacks;
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

        public void DeleteFeedback(Feedback feedback)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from Feedback
                          where feedbackText = @feedbackText;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@feedbackText", feedback.FeedbackText);
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

        public List<BusLine> GetBusLines()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select number, duration 
                              from busline;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<BusLine> busLines = new List<BusLine>();

                while (reader.Read())
                {
                    int number = reader.GetInt32(0);
                    busLines.Add(new BusLine(number, reader.GetInt32(1), GetBusLineStops(number)));
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

        public List<Reservation> GetReservations()
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select clientUsername, reservationDate, travelDatetime, travelBusLine, chargedPrice
                          from reservation;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reservations.Add(new Reservation(Functions.GetClientByUsername(reader.GetString(0)), 
                                                     reader.GetDateTime(1), 
                                                     reader.GetDateTime(2), 
                                                     reader.GetInt32(3),
                                                     reader.GetDecimal(4)));
                }

                return reservations;
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

        public bool CheckDuplicateBusLineNumber(int number)
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select count(*) 
                          from BusLine 
                          where number = @number;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", number);
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

        public List<BusDriver> GetBusDrivers()
        {
            try
            {
                List<BusDriver> busDrivers = new List<BusDriver>();

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select BusDriver.username, name, surname, salary, experience, hireDate, complaintsCounter
                                  from user 
                                  inner join Employee on User.username = Employee.username
                                  inner join BusDriver on User.username = BusDriver.username
                                  where fired = @fired;";

                using var cmd = new MySqlCommand(statement, connection);
                cmd.Parameters.AddWithValue("@fired", false);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    busDrivers.Add(new BusDriver(reader.GetString(0),
                                                 reader.GetString(1),
                                                 reader.GetString(2),
                                                 "BusDriver",
                                                 reader.GetDecimal(3),
                                                 reader.GetInt32(4),
                                                 reader.GetString(5),
                                                 reader.GetInt32(6)));
                }

                return busDrivers;
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

        public List<Bus> GetBuses()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select busID, size 
                                from bus;";

                using var cmd = new MySqlCommand(statement, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Bus> buses = new List<Bus>();

                while (reader.Read())
                {
                    var size = BusSize.SMALL;

                    switch (reader.GetString(1))
                    {
                        case "medium":
                            size = BusSize.MEDIUM;
                            break;
                        case "large":
                            size = BusSize.LARGE;
                            break;
                    }

                    buses.Add(new Bus(reader.GetInt32(0), size));
                }

                return buses;
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

        public void InsertItineraryInDatabase(Itinerary itinerary)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var statement = @"insert into Itinerary (status, travelDatetime, availableSeats, distributorUsername, busDriverUsername, busLineNumber, busID) VALUES 
			                (@status, @travelDatetime,  @availableSeats, @distributorUsername, @busDriverUsername, @busLineNumber, @busID)";

                using var cmd = new MySqlCommand(statement, connection);
                cmd.Parameters.AddWithValue("@status", "no_delayed");
                cmd.Parameters.AddWithValue("@travelDatetime", itinerary.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@availableSeats", itinerary.AvailableSeats);
                cmd.Parameters.AddWithValue("@distributorUsername", _username);
                cmd.Parameters.AddWithValue("@busDriverUsername", itinerary.ResponsibleDriver);
                cmd.Parameters.AddWithValue("@busLineNumber", itinerary.ItineraryLine.Number);
                cmd.Parameters.AddWithValue("@busID", itinerary.ResponsibleBus.ID);
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

        public Client GetClient(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select name, surname
                                  from user
                                  where username = @username;";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return new Client(username,
                                  reader.GetString(0),
                                  reader.GetString(1),
                                  "Client");
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

        public int GetClientsLastTicketID(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select max(ticketID)
                              from ticket
                              where clientUsername = @username;";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", username);
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

        public int GetMaxItineraryID()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select max(itineraryID)
                              from itinerary";

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

        public void DeleteReservation(Reservation reservation)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"delete from reservation
                              where clientUsername = @username and travelDatetime = @travelDatetime and travelBusLine = @travelBusLine;";
                using var cmd = new MySqlCommand(statement, connection);
                cmd.Parameters.AddWithValue("@username", reservation.ReserveringClient);
                cmd.Parameters.AddWithValue("@travelDatetime", reservation.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@travelBusLine", reservation.TravelBusLine);
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

        public List<LastMinuteTravelRequest> GetLastMinuteTravelRequests()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select clientUsername, applicationDate, travelDatetime, travelBusLine, status 
                              from lastminutetravelrequest
                              where status = @status;";
                using var cmd = new MySqlCommand(statement, connection);
                cmd.Parameters.AddWithValue("@status", "pending");
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<LastMinuteTravelRequest> lastMinuteRequests = new List<LastMinuteTravelRequest>();

                while (reader.Read())
                {
                    lastMinuteRequests.Add(new LastMinuteTravelRequest(reader.GetString(0),
                                                                       reader.GetDateTime(1).ToString("dd-MM-yyyy"),
                                                                       reader.GetDateTime(2),
                                                                       reader.GetInt32(3),
                                                                       Status.Pending));
                }

                return lastMinuteRequests;
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
