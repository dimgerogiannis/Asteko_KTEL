using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Project.ClientForms;
using Project.Login;
using Project.BusDriverForms;
using ClassesFolder;

namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text != "" && passwordTextbox.Text != "")
            {
                var existsInDatabase = FindExistanceInDatabase(usernameTextbox.Text, passwordTextbox.Text);

                if (existsInDatabase.Item1)
                {
                    if (existsInDatabase.Item2 == "client")
                    {
                        ClientForm form = new ClientForm(FindClientInfo(usernameTextbox.Text));
                        form.ShowDialog();
                    }
                    else if (existsInDatabase.Item2 == "bus_driver")
                    {
                        BusDriverForm form = new BusDriverForm(FindBusDriverInfo(usernameTextbox.Text));
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Λάθος όνομα χρήση ή κωδικός πρόσβασης.", 
                                        "Σφάλμα", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Λάθος όνομα χρήση ή κωδικός πρόσβασης.", 
                                    "Σφάλμα", 
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private (bool, string) FindExistanceInDatabase(string username, string password)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select count(*), property 
                                  from user 
                                  where username = @username and password = EncryptPassword(@password);";
                using var cmd = new MySqlCommand(statement, connection);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return (reader.GetInt32(0) == 1, reader.IsDBNull(1) ? "" : reader.GetString(1));
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                this.Close();
                return (false, "");
            }
        }

        private Client FindClientInfo(string username)
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
                this.Close();
                return null;
            }
        }
   
        private BusDriver FindBusDriverInfo(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var statement = @"select name, surname, salary, experience, hireDate, complaintsCounter, availableWorkingHours
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
                                     reader.GetInt32(5),
                                     reader.GetInt32(6));
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Close();
                return null;
            }
        }
    }
}
