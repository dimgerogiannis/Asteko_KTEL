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
    public class BusDriver : Employee
    {
        private int _complaintCounter;
        private List<string> _paidLeaveDates;
        private int _yearlyPaidLeaves = 15;
        private int _availableWorkingHours;

        public int ComplaintCounter => _complaintCounter;
        public List<string> PaidLeaveDates
        {
            get { return _paidLeaveDates; }
            set { _paidLeaveDates = value; }
        }
        public int AvailableWorkingHours => _availableWorkingHours;

        public BusDriver(string username,
                         string name,
                         string surname,
                         string property,
                         decimal salary,
                         int experience,
                         string hireDate,
                         int complaintCounter,
                         int availableWorkingHours) : base(username, name, surname, property, salary, experience, hireDate)
        {
            _complaintCounter = complaintCounter;
            _paidLeaveDates = new List<string>();
            _availableWorkingHours = availableWorkingHours;

            GetPaidLeaveDates();
            _yearlyPaidLeaves = 15 - PaidLeaveDates.Count;
        }

        public bool HasRemainingPaidLeaves()
        {
            return _paidLeaveDates.Count <= 15;
        }

        private void GetPaidLeaveDates()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select paidLeaveDate 
                              from paidleavedates
                              where busDriverUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _paidLeaveDates.Add(reader.GetString(0));
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

        public List<Itinerary> GetCurrentWeekItineraries()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itineraryID, travelDatetime, busDriverUsername, busLineNumber, busID, availableSeats
                              from itinerary
                              where busDriverUsername = @username and current_timestamp() <= travelDatetime and travelDatetime < date(now() + INTERVAL 7 - weekday(now()) DAY);";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Itinerary> itineraries = new List<Itinerary>();

                while (reader.Read())
                {
                    itineraries.Add(new Itinerary(reader.GetInt32(0),
                                                  reader.GetDateTime(1),
                                                  reader.GetString(2),
                                                  GetBusLineData(reader.GetInt32(3)),
                                                  GetBusData(reader.GetInt32(4)),
                                                  ItineraryStatus.NoDelayed,
                                                  reader.GetInt32(5)));
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

        public Dictionary<string, string> GetLastItineraryClients()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select concat(User.name, ' ', User.surname) , Client.username from Itinerary
                              inner join Ticket on Ticket.itineraryID = Itinerary.itineraryID
                              inner join client on Ticket.clientUsername = Client.username
                              inner join User on Client.username = User.username
                              where busDriverUsername = @busDriverUsername and itinerary.itineraryID = (select max(itinerary.itineraryID) from itinerary where busDriverUsername = @busDriverUsername and travelDatetime<current_timestamp());";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> clients = new Dictionary<string, string>();

                while (reader.Read())
                {
                    clients.Add(reader.GetString(0), reader.GetString(1));
                }

                return clients;
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

        public bool CheckDuplicateSanitaryComplaint(string clientUsername)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*) 
                          from sanitarycomplaint
                          where busDriverUsername = @busDriverUsername and targetUsername = @clientUsername;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", _username);
                cmd.Parameters.AddWithValue("@clientUsername", clientUsername);
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

        public void InsertSanitaryComplaintInDatabase(SanitaryComplaint complaint)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into SanitaryComplaint (targetUsername, summary, category, busDriverUsername) values
	                     (@targetUsername, @summary, @category, @busDriverUsername);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", complaint.BusDriverUsername);
                cmd.Parameters.AddWithValue("@summary", complaint.Summary);

                var cat = "";
                switch (complaint.Category)
                {
                    case SanitaryComplaintCategory.CloseDistance:
                        cat = "close_distance";
                        break;
                    case SanitaryComplaintCategory.HasIllnessSymptoms:
                        cat = "has_illness_symptom";
                        break;
                    case SanitaryComplaintCategory.WeakMaskRefusal:
                        cat = "wear_mask_refusal";
                        break;
                }

                cmd.Parameters.AddWithValue("@category", cat);
                cmd.Parameters.AddWithValue("@targetUsername", complaint.TargetUsername);
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

        public Itinerary GetCurrentAssignedItinerary()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select itineraryID, travelDatetime, busDriverUsername, busLineNumber, busID, availableSeats
                            from Itinerary
                            inner join BusLine on Itinerary.busLineNumber = BusLine.number
                            where status = @status and Itinerary.busDriverUsername = @busDriverUsername and current_timestamp() >= travelDatetime and current_timestamp() < date_add(travelDatetime, interval duration minute);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", _username);
                cmd.Parameters.AddWithValue("@status", "no_delayed");
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Itinerary(reader.GetInt32(0),
                                         reader.GetDateTime(1),
                                         reader.GetString(2),
                                         GetBusLineData(reader.GetInt32(3)),
                                         GetBusData(reader.GetInt32(4)),
                                         ItineraryStatus.NoDelayed,
                                         reader.GetInt32(5));
                }
                else
                {
                    return null;
                }
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

        public void SetItineraryAsDelayed(Itinerary itinerary, string reason)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update Itinerary
                          set status = @status, lateReason = @reason
                          where itineraryID = @itineraryID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@itineraryID", itinerary.ID);
                cmd.Parameters.AddWithValue("@status", "delayed");
                cmd.Parameters.AddWithValue("@reason", reason);
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

        public List<DisciplinaryComplaint> GetDisciplinaryComplaints()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select submittedDatetime, comment 
                          from disciplinarycomplaint
                          where targetUsername = @busDriverUsername;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<DisciplinaryComplaint> complaints = new List<DisciplinaryComplaint>();

                while (reader.Read())
                {
                    complaints.Add(new DisciplinaryComplaint(_username, reader.GetString(1), reader.GetDateTime(0)));
                }

                return complaints;
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

        public void InsertPaidLeaveApplicationInDatabase(PaidLeaveApplication application)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"insert into PaidLeaveApplication (busDriverUsername, reason, applicationDate, status, requestedDate) values
	                      (@busDriverUsername, @reason, @applicationDate, @status, @requestedDate);";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", application.ApplicantDriver);
                cmd.Parameters.AddWithValue("@reason", application.Reason);
                cmd.Parameters.AddWithValue("@applicationDate", application.ApplicationDatetime);
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.Parameters.AddWithValue("@requestedDate", application.WantedDatetime);
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

        public bool CheckDuplicatePaidLeaveApplication(string requestedDate)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                          from PaidLeaveApplication
                          where busDriverUsername = @busDriverUsername and requestedDate = @requestedDate;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busDriverUsername", _username);
                cmd.Parameters.AddWithValue("@requestedDate", requestedDate);
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

        public List<PaidLeaveApplication> GetPaidLeaveApplications()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select reason, rejectionReason, applicationDate, status, requestedDate 
                             from paidleaveapplication
                             where busDriverUsername = @username;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<PaidLeaveApplication> applications = new List<PaidLeaveApplication>();

                while (reader.Read())
                {
                    var status = Status.Pending;
                    switch (reader.GetString(3))
                    {
                        case "rejected":
                            status = Status.Rejected;
                            break;
                        case "accepted":
                            status = Status.Accepted;
                            break;
                    }

                    applications.Add(new PaidLeaveApplication(_username,
                                                              reader.GetDateTime(2).ToString("dd-MM-yyyy"),
                                                              reader.GetString(0),
                                                              reader.IsDBNull(1) ? "" : reader.GetString(1),
                                                              reader.GetDateTime(4).ToString("dd-MM-yyyy"),
                                                              status));
                }

                return applications;
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

        public void SetAsUnavailable(string date)
        {
            _paidLeaveDates.Add(date);
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"insert into PaidLeaveDates values (@username, @requestedDate);";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@requestedDate", DateTime.Parse(date).ToString("yyyy-MM-dd"));
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

        public void DecreasePaidYearlyDates()
        {
            _yearlyPaidLeaves--;
        }

        public void IncreaseComplaintCounter()
        {
            _complaintCounter++;
        }

        public void UpdateComplaintCounter()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update BusDriver
                          set complaintsCounter = complaintsCounter + 1
                          where username = @username;";
                using var cmd = new MySqlCommand(query, connection);

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

        public bool HasExceededTolaratedComplaints()
        {
            return _complaintCounter > 9;
        }

        public void ResetComplaintsCounter()
        {
            _complaintCounter = 0;
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update BusDriver
                          set complaintCounter = @complaintCounter
                          where username = @username;";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@complaintCounter", _complaintCounter);
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

        public bool HasAssignedItineraryForNextWeek(string startingDate)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*) 
                          from itinerary 
                          where busDriverUsername = @username and travelDatetime >= @startingDate;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@startingDate", startingDate);
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

        public bool IsOnPaidLeave(string date)
        {
            return _paidLeaveDates.Contains(date);
        }

        public bool IsAvailableOnHour(string date, string startingHour, int duration)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusDriver on BusDriver.username = Itinerary.busDriverUsername
                        inner join BusLine on BusLine.number = busLineNumber
                        where BusDriver.username = @username AND (travelDatetime <= @targetDatetime AND ADDDATE(travelDatetime, INTERVAL duration MINUTE) > @targetDatetime
OR @targetDatetime <= travelDatetime AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE)
OR travelDatetime <= ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE)
OR @targetDatetime > travelDatetime AND ADDDATE(@targetDatetime, INTERVAL @duration MINUTE) <= ADDDATE(travelDatetime, INTERVAL duration MINUTE));";

                var target = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@targetDatetime", target);
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
    
        public bool IsLeadToOverWorking(int duration)
        {
            return _availableWorkingHours - duration < 0;
        }
   
        public bool HasItineraryEndTimeAndNoNextItineraryOnSpecificTime(string date, string startingHour, string targetStop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                          from Itinerary
                          inner join BusLine on BusLine.number = busLineNumber
                          where busDriverUsername = @targetUsername and ADDDATE(travelDatetime, INTERVAL duration MINUTE) = @targetDatetime and (select stopName from Stop where Stop.number = BusLine.number order by id desc limit 1) = @targetStop;";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", _username);
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

        public bool DoesntHaveImmidiatelyItinerary(string date, string startingHour, int duration, string targetStop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusDriver on BusDriver.username = Itinerary.busDriverUsername
                        inner join BusLine on BusLine.number = busLineNumber
                        where BusDriver.username = @targetUsername AND 
                        (TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:00' AND TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) < '00:30:00'
                        AND (select stopName from Stop where Stop.number = BusLine.number order by Stop.id asc limit 1) != @targetStop);";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@targetUsername", _username);
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
    
        public bool FindIfCanBeAccepted(string date, string startingHour, int duration)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                        from Itinerary
                        inner join BusDriver on BusDriver.username = Itinerary.busDriverUsername
                        inner join BusLine on BusLine.number = busLineNumber
                        where BusDriver.username = @targetUsername AND (TIMEDIFF(@targetDatetime, travelDatetime) <= '00:30:00' AND TIMEDIFF(@targetDatetime, travelDatetime) > '00:00:01'
                        OR TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) <= '00:30:00' AND TIMEDIFF(travelDatetime, ADDDATE(@targetDatetime, INTERVAL @duration MINUTE)) > '00:00:01');";

                var targetDatetime = $"{date} {startingHour}:00";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@targetUsername", _username);
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
    
        public void DecreaseAvailableWorkingHours(int duration)
        {
            try
            {
                _availableWorkingHours -= duration;
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"update BusDriver
                          set availableWorkingHours = @availableWorkingHours
                          where username = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _username);
                cmd.Parameters.AddWithValue("@availableWorkingHours", _availableWorkingHours);
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
