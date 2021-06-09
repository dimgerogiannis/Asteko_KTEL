using ClassesFolder;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ChiefForms
{
    public partial class ComplaintHistory : Form
    {
        private Chief _chief;
        private DismissalPetition _petition;
        private List<ClientComplaint> _complaints;

        public ComplaintHistory(Chief chief, DismissalPetition petition)
        {
            _chief = chief;
            _petition = petition;
            InitializeComponent();
        }

        private void ComplaintHistory_Load(object sender, EventArgs e)
        {
            _complaints = _petition.GetComplaintHistory();
            foreach (var complaint in _complaints)
            {
                var category = "";
                switch (complaint.Category)
                {
                    case ClientComplaintCategory.AggresiveBehaviour:
                        category = "Επιθετική συμπεριφορά";
                        break;
                    case ClientComplaintCategory.CarelessDriving:
                        category = "Απρόσεκτη οδήγηση";
                        break;
                    case ClientComplaintCategory.DrivingRuleViolation:
                        category = "Παραβίαση Κ.Ο.Κ.";
                        break;
                    case ClientComplaintCategory.LateForNoReason:
                        category = "Καθυστέρηση χωρίς λόγο";
                        break;
                    case ClientComplaintCategory.Rude:
                        category = "Αγενής συμπεριφορά";
                        break;
                }

                complaintsListview.Items.Add(new ListViewItem(new string[]
                {
                    complaint.TargetDriver.GetFullName(),
                    category,
                    complaint.ComplaintClient.GetFullName()
                }));
            }

            complaintsListview.ContextMenuStrip = contextMenuStrip;
        }

        private void ReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReasonForm form = new ReasonForm(_complaints[complaintsListview.SelectedIndices[0]].Summary);
            form.ShowDialog();
        }

        private void FireButton_Click(object sender, EventArgs e)
        {
            if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
            {
                MessageBox.Show("Οι απολύσεις οδηγών μπορούν να συμβούν μόνο τις κυριακές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            var result = MessageBox.Show("Θέλετε να προχωρήσετε στην απόλυση του οδηγού;",
                                         "Ερώτηση",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            
            var busDriver = _complaints[0].TargetDriver;

            if (result == DialogResult.Yes)
            {
                if (!busDriver.HasAssignedItineraryForNextWeek())
                {
                    _chief.DeleteClientComplaints(_complaints);
                    _chief.DeletePaidLeaveApplications(_chief.GetPaidLeaveApplications(_petition.TargetDriver));
                    _chief.DeletePaidLeaveDates(_petition.TargetDriver.Username);
                    _petition.DeleteDismissalPetition();
                    SetBusDriverAsFired(_petition.TargetDriver);

                    MessageBox.Show("Επιτυχής απόλυση οδηγού.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ο οδηγός δεν μπορεί να απολυθεί γιατί του έχουν ανατεθεί δρομολόγια.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                }

                this.Close();
            }
            else
            {
                _chief.DeleteClientComplaints(_complaints);
                _petition.DeleteDismissalPetition();
                busDriver.ResetComplaintsCounter();

                this.Close();
            }
        }

        public void SetBusDriverAsFired(BusDriver busDriver)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update BusDriver set fired = @fired where username = @username";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", busDriver.Username);
                cmd.Parameters.AddWithValue("@fired", true);
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
