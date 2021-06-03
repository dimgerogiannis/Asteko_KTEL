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
            if (complaintListCombobox.SelectedItem == null || describeRichTextbox.Text == "")
            {
                MessageBox.Show("Παρακαλώ εισάγετε όλα τα απαραίτητα πεδία.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ClientComplaint complaint = new ClientComplaint
                (
                    _latestItinerary.ResponsibleDriver,
                    false,
                    describeRichTextbox.Text,
                    category,
                    _client.Username
                );

                var busDriver = _client.GetBusDriver(_latestItinerary.ResponsibleDriver);
                _client.InsertClientComplaint(complaint);
                busDriver.IncreaseComplaintCounter();
                busDriver.UpdateComplaintCounter();

                if (busDriver.HasExceededTolaratedComplaints())
                {
                    complaint.SetAsChecked();
                    DismissalPetition petition = new DismissalPetition(busDriver.Username);
                    if (!_client.CheckDuplicateDismissalPetition(petition))
                    {
                        _client.InsertDismissalPetitionInDatabase(petition);
                    }
                }

                MessageBox.Show("Επιτυχής καταχώρηση παραπόνου.", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Δεν βρέθηκε το τελευταίο δρομολόγιο για το οποίο ταξιδέψατα.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DescribeRichTextbox_TextChanged(object sender, EventArgs e)
        {
            describeLabel.Text = $"Περιγράψτε με λίγα λόγια τον λόγο καταγγελίας. ({300 - describeRichTextbox.Text.Length})";
        }
    }
}

