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
    public partial class BusDriverComplaintsForm : Form
    {
        private QualityManager _qualityManager;
        private Dictionary<string, List<SanitaryComplaint>> _complaints;
        public BusDriverComplaintsForm(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void BusDriverComplaintsForm_Load(object sender, EventArgs e)
        {
            _complaints = _qualityManager.GetSanitaryComplaints();

            foreach (var key in _complaints.Keys)
                nameCombobox.Items.Add($"{GetUserFullName(key)} ({key})");

            infoListview.ContextMenuStrip = contextMenuStrip;
        }

        private void NameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameCombobox.SelectedItem != null)
            {
                infoListview.Items.Clear();

                foreach (var complaint in _complaints[nameCombobox.SelectedItem.ToString().Split("(")[1].Split(")")[0]])
                {
                    string cat = "";
                    switch (complaint.Category)
                    {
                        case Enums.SanitaryComplaintCategory.CloseDistance:
                            cat = "Μη τήρηση αποστάσεων";
                            break;
                        case Enums.SanitaryComplaintCategory.HasIllnessSymptoms:
                            cat = "Συμπτώματα ιού";
                            break;
                        case Enums.SanitaryComplaintCategory.WeakMaskRefusal:
                            cat = "Άρνηση χρήσης μάσκας";
                            break;
                    }

                    infoListview.Items.Add(new ListViewItem(new string[]
                    {
                        cat,
                        complaint.ComplaintDriver.GetFullName()
                    }));
                }
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
