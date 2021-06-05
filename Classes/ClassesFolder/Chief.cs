using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Chief : Employee, IChief
    {
        public Chief(string username,
                     string name,
                     string surname,
                     string property,
                     decimal salary,
                     int experience,
                     string hireDate) : base(username, name, surname, property, salary, experience, hireDate)
        {

        }

        public void SetNewTicketPrice(decimal value)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update TicketPrice set price = @price where id = 1;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@price", value);
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

        public void SetNewMonthlyCardPrice(int value)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update MontlyCardPrice set price = @price where id = 1;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@price", value);
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

        public void SetDiscountCategoryPercentage(Category category, int percentage)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update DiscountCategory 
                              set discountPercentage = @percentage 
                              where category = @category;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@percentage", percentage);

                var cat = "";

                switch (category)
                {
                    case Category.Student:
                        cat = "student";
                        break;
                    case Category.Soldier:
                        cat = "soldier";
                        break;
                    case Category.LowIncome:
                        cat = "low_income";
                        break;
                    case Category.DissabilityIssues:
                        cat = "dissabilities";
                        break;
                }

                cmd.Parameters.AddWithValue("@category", cat);
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

        public bool CheckDuplicateUsername(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select count(*)
                              from User
                              where username = @username;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public void InsertUserInDatabase(string username, string password, string name, string surname, string prop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into User values (@username, @name, @surname, EncryptPassword(@password), @property);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@property", prop);
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

        public void InsertEmployeeInDatabase(string username, int salary, int experience)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into Employee values (@username, @salary, @experience, CURRENT_DATE());";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@experience", experience);
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

        public void InsertBusDriverInInDatabase(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into BusDriver values (@username, @complaintsCounter, @availableWorkingHours);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@complaintsCounter", 0);
                cmd.Parameters.AddWithValue("@availableWorkingHours", 360);
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

        public void InsertQualityManagerInInDatabase(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into QualityManager values (@username);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public void InsertItineraryDistributionManagerInInDatabase(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into ItineraryDistributionManager values (@username, @isResponsibleForWeek);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@isResponsibleForWeek", false);
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

        public List<Employee> GetEmployees()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select User.username, name, surname, property, salary, experience, hireDate
                              from Employee
                              inner join User on employee.username = User.username;";
                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Employee> employees = new List<Employee>();

                while (reader.Read())
                {
                    employees.Add(new Employee(reader.GetString(0),
                                               reader.GetString(1),
                                               reader.GetString(2),
                                               reader.GetString(3),
                                               reader.GetDecimal(4),
                                               reader.GetInt32(5),
                                               DateTime.Parse(reader.GetString(6)).ToString("dd-MM-yyyy")));
                }

                return employees;
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

        public List<ItineraryDistributionManager> GetDistributionManagers()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select User.username, name, surname, property, salary, experience, hireDate, isResponsibleForWeek
                              from Employee
                              inner join ItineraryDistributionManager on Employee.username = ItineraryDistributionManager.username
                              inner join User on employee.username = User.username;";
                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<ItineraryDistributionManager> employees = new List<ItineraryDistributionManager>();

                while (reader.Read())
                {
                    employees.Add(new ItineraryDistributionManager(reader.GetString(0),
                                                                   reader.GetString(1),
                                                                   reader.GetString(2),
                                                                   reader.GetString(3),
                                                                   reader.GetDecimal(4),
                                                                   reader.GetInt32(5),
                                                                   reader.GetString(6),
                                                                   reader.GetBoolean(7)));
                }

                return employees;
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

        public void ChangeDistributionManagerState(ItineraryDistributionManager distributor, bool state)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"update ItineraryDistributionManager
                          set isResponsibleForWeek = @state
                          where username = @username;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", distributor.Username);
                cmd.Parameters.AddWithValue("@state", state);
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

        public List<PaidLeaveApplication> GetUncheckedPaidLeaveApplications()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select busDriverUsername, reason, applicationDate, requestedDate 
                             from paidleaveapplication
                             where status = @status";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", "pending");
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<PaidLeaveApplication> applications = new List<PaidLeaveApplication>();

                while (reader.Read())
                {
                    applications.Add(new PaidLeaveApplication(reader.GetString(0),
                                                              reader.GetDateTime(2).ToString("dd-MM-yyyy"),
                                                              reader.GetString(1),
                                                              "",
                                                              reader.GetDateTime(3).ToString("dd-MM-yyyy"),
                                                              Status.Pending));
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

        public List<Transaction> GetTransactions(string startDate, string endDate)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select price, purchaseDatetime
                          from transaction 
                          where purchaseDatetime >= @startDate and purchaseDatetime <= @endDate;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Transaction> transactions = new List<Transaction>();

                while (reader.Read())
                {
                    transactions.Add(new Transaction(reader.GetDecimal(0), null, reader.GetDateTime(1)));
                }

                return transactions;
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

        public List<DismissalPetition> GetDismissalPetitions()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select targetUsername 
                             from dismissalpetition;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<DismissalPetition> petitions = new List<DismissalPetition>();

                while (reader.Read())
                {
                    petitions.Add(new DismissalPetition(reader.GetString(0)));
                }

                return petitions;
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

        public void DeleteClientComplaints(List<ClientComplaint> complaints)
        {
            foreach (var complaint in complaints)
            {
                complaint.DeleteClientComplaint();
            }
        }

        public List<PaidLeaveApplication> GetPaidLeaveApplications(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"select busDriverUsername, reason, applicationDate, requestedDate 
                          from paidleaveapplication
                          where busDriverUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<PaidLeaveApplication> applications = new List<PaidLeaveApplication>();
                while (reader.Read())
                {
                    applications.Add(new PaidLeaveApplication(reader.GetString(0),
                                                                  reader.GetDateTime(2).ToString("dd-MM-yyyy"),
                                                                  reader.GetString(1),
                                                                  "",
                                                                  reader.GetDateTime(3).ToString("dd-MM-yyyy"),
                                                                  Status.Pending));
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

        public void DeletePaidLeaveApplications(List<PaidLeaveApplication> applications)
        {
            foreach (var application in applications)
            {
                application.DeletePaidLeaveApplication();
            }
        }

        public void DeletePaidLeaveDates(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from PaidLeaveDates
                          where busDriverUsername = @username";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public void DeleteEmployee(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from Employee
                          where username = @username";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public void DeleteBusDriver(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from BusDriver
                              where username = @username";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public void DeleteUser(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from User
                          where username = @username";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
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

        public string GetUserFullNameFromDatabase(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select name, surname
                              from User
                              where username = @username;";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", username);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return $"{reader.GetString(0)} {reader.GetString(1)}";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
                return "";
            }
        }
    }
}
