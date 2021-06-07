using ClassesFolder;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class ClientComplaintReviewForm : Form
    {
        private QualityManager _qualityManager;
        private Dictionary<string, List<ClientComplaint>> _complaints;
        public ClientComplaintReviewForm(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void ClientComplaintReviewForm_Load(object sender, EventArgs e)
        {
            _complaints = _qualityManager.GetUnckeckedClientComplaints();

            foreach (var key in _complaints.Keys)
                nameCombobox.Items.Add($"{GetUserFullName(key)} ({_complaints[key][0].TargetDriver.Username})");
        }

        private void NameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameCombobox.SelectedItem != null)
            {
                infoListview.Items.Clear();
                var username = nameCombobox.SelectedItem.ToString().Split("(")[1].Split(")")[0];

                foreach (var complaint in _complaints[username])
                {
                    var cat = complaint.Category;
                    var category = "";
                    switch (cat)
                    {
                        case Enums.ClientComplaintCategory.AggresiveBehaviour:
                            category = "Επιθετική συμπεριφορά";
                            break;
                        case Enums.ClientComplaintCategory.CarelessDriving:
                            category = "Επιθετική οδήγηση";
                            break;
                        case Enums.ClientComplaintCategory.DrivingRuleViolation:
                            category = "Παραβίαση του Κ.Ο.Κ.";
                            break;
                        case Enums.ClientComplaintCategory.LateForNoReason:
                            category = "Αργοπορία χωρίς λόγο";
                            break;
                        case Enums.ClientComplaintCategory.Rude:
                            category = "Αγενής συμπεριφορά";
                            break;
                    }

                    infoListview.Items.Add(new ListViewItem(new string[]
                    {
                        category,
                        complaint.ComplaintClient.GetFullName()
                    }));
                }

                infoListview.ContextMenuStrip = contextMenuStrip;
            }
        }

        private void SummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (infoListview.SelectedItems.Count == 1)
            {
                var index = infoListview.SelectedIndices[0];
                var summary = _complaints[nameCombobox.SelectedItem.ToString().Split("(")[1].Split(")")[0]][index].Summary;
                ReasonForm form = new ReasonForm(summary);
                form.ShowDialog();
            }
        }

        private void DisciplinaryCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (infoListview.SelectedItems.Count == 1)
            {
                var complaint = _complaints[nameCombobox.SelectedItem.ToString().Split("(")[1].Split(")")[0]][infoListview.SelectedIndices[0]];

                DisciplinaryForm form = new DisciplinaryForm(_qualityManager,
                                                             complaint);
                form.ShowDialog();

                _complaints[nameCombobox.SelectedItem.ToString().Split("(")[1].Split(")")[0]].RemoveAt(infoListview.SelectedIndices[0]);
                infoListview.Items.RemoveAt(infoListview.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε ένα παράπονο επιβάτη για να προσθέσετε σχόλιο επίπληξης.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public string GetUserFullName(string username)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select name, surname
                              from User
                              where username = @username;";

                using var cmd = new MySqlCommand(query, connection);
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
