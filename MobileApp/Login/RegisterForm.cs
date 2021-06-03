using MySql.Data.MySqlClient;
using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Login
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "" ||
                passwordTextbox.Text == "" ||
                nameTextbox.Text == "" ||
                surnameTextbox.Text == "")
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία που απαιτούνται για την εγγραφή.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            else
            {
                if (!CheckIfUsernameExistsInDatabase(usernameTextbox.Text))
                {
                    RegisterUser(usernameTextbox.Text,
                                 passwordTextbox.Text,
                                 nameTextbox.Text,
                                 surnameTextbox.Text);

                    RegisterClient(usernameTextbox.Text);

                    MessageBox.Show("Επιτυχής εγγραφή στο σύστημα!", 
                                    "Επιτυχία", 
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Το όνομα χρήστη είναι ήδη εγγεγραμένο. Παρακαλώ επιλέξτε ένα άλλο.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckIfUsernameExistsInDatabase(string username)
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

        private void RegisterUser(string username, string password, string name, string surname)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"insert into User (username, name, surname, password, property) values
                          (@username, @name, @surname, @password, @property);";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@property", "client");
            cmd.ExecuteNonQuery();
        }

        private void RegisterClient(string username)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"insert into Client (username, balance, monthlyCard, discount) values
                          (@username, @balance, @monthlyCard, @discount);";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@balance", 0);
            cmd.Parameters.AddWithValue("@monthlyCard", false);
            cmd.Parameters.AddWithValue("@discountID", 1);
            cmd.ExecuteNonQuery();
        }
    }
}
