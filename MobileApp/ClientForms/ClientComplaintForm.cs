using ClassesFolder;
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
using static ClassesFolder.Enums;

namespace Project.ClientForms
{
    public partial class ClientComplaintForm : Form
    {
        private Client _client;
        private Itinerary _latestItinerary;

        public ClientComplaintForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void ClientComplaint_Load(object sender, EventArgs e)
        {
            complaintListCombobox.Items.AddRange(new string[] 
            { 
                "Ο οδηγός ήταν προσβλητικός",
                "Ο οδηγός άργησε χωρίς λόγο",
                "Ο οδηγός συμπεριφερόταν επιθετικά",
                "Ο οδηγός οδηγούσε επικύνδινα",
                "Ο οδηγός δεν τηρούσε τον Κ.Ο.Κ."
            });

            _latestItinerary = _client.GetLatestItinerary();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (_latestItinerary == null)
            {
                return;
            }

            if (complaintListCombobox.SelectedItem == null || describeRichTextbox.Text == "")
            {
                MessageBox.Show("Παρακαλώ εισάγετε όλα τα απαραίτητα πεδία.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            if (CheckForDuplicateClientComplaint(_latestItinerary.ResponsibleDriver, _client))
            {
                MessageBox.Show("Έχετε ήδη καταχωρήσει παράπονο για τον οδηγό του τελευταίου δρομολογίου για το οποίο ταξιδέψατε.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (_latestItinerary != null)
            {
                ClientComplaintCategory category = ClientComplaintCategory.Rude;

                switch (complaintListCombobox.SelectedItem.ToString())
                {
                    case "Ο οδηγός άργησε χωρίς λόγο":
                        category = ClientComplaintCategory.LateForNoReason;
                        break;
                    case "Ο οδηγός συμπεριφερόταν επιθετικά":
                        category = ClientComplaintCategory.AggresiveBehaviour;
                        break;
                    case "Ο οδηγός οδηγούσε επικύνδινα":
                        category = ClientComplaintCategory.CarelessDriving;
                        break;
                    case "Ο οδηγός δεν τηρούσε τον Κ.Ο.Κ.":
                        category = ClientComplaintCategory.DrivingRuleViolation;
                        break;
                }

                ClientComplaint complaint = new ClientComplaint(_latestItinerary.ResponsibleDriver,
                                                                _client,
                                                                false,
                                                                describeRichTextbox.Text,
                                                                category);

                var busDriver = Functions.GetBusDriverByUsername(_latestItinerary.ResponsibleDriver.Username);
                _client.InsertClientComplaint(complaint);
                busDriver.IncreaseComplaintCounter();
                busDriver.UpdateComplaintCounter();

                if (busDriver.HasExceededToleratedComplaints())
                {
                    complaint.SetAsChecked();
                    DismissalPetition petition = new DismissalPetition(busDriver);
                    if (!_client.CheckDuplicateDismissalPetition(petition))
                    {
                        _client.InsertDismissalPetitionInDatabase(petition);
                    }
                }

                MessageBox.Show("Επιτυχής καταχώρηση παραπόνου.", 
                                "Επιτυχία", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Δεν βρέθηκε το τελευταίο δρομολόγιο για το οποίο ταξιδέψατα.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }

        private void DescribeRichTextbox_TextChanged(object sender, EventArgs e)
        {
            describeLabel.Text = $"Περιγράψτε με λίγα λόγια τον λόγο καταγγελίας. ({300 - describeRichTextbox.Text.Length})";
        }
    
        public bool CheckForDuplicateClientComplaint(BusDriver targetDriver, Client complaintClient)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"select count(*) 
                          from clientcomplaint 
                          where targetUsername = @driverUsername and clientUsername = @clientUsername;";

            using var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@driverUsername", targetDriver.Username);
            cmd.Parameters.AddWithValue("@clientUsername", complaintClient.Username);

            using MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return reader.GetInt32(0) != 0;
        }
    }
}

