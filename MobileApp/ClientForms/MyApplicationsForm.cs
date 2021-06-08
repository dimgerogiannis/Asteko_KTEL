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
    public partial class MyApplicationsForm : Form
    {
        private Client _client;
        private List<DiscountApplication> _applications;

        public MyApplicationsForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void MyApplications_Load(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            _applications = _client.GetDiscountApplications();
            foreach (var application in _applications)
                dateCombobox.Items.Add(application.ApplicationDatetime?.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void DateCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dateCombobox.SelectedItem != null)
            {
                deleteButton.Enabled = false;
                rejectionReasonRichTextbox.Text = "";
                deleteButton.Enabled = false;

                var application = _applications
                    .Find(y => y.ApplicationDatetime == DateTime.Parse(dateCombobox.SelectedItem.ToString()));

                switch (application.Status)
                {
                    case Status.Pending:
                        statusLabel.Text = $"Κατάσταση αίτησης: Εκκρεμής";
                        break;
                    case Status.Accepted:
                        statusLabel.Text = $"Κατάσταση αίτησης: Εγκρίθηκε";
                        deleteButton.Enabled = true;
                        break;
                    case Status.Rejected:
                        statusLabel.Text = $"Κατάσταση αίτησης: Απορρίφθηκε";
                        rejectionReasonRichTextbox.Text = application.PossibleRejectionReason;
                        deleteButton.Enabled = true;
                        break;
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _client.DeleteDiscountApplicationFromDatabase(dateCombobox.SelectedItem.ToString());
            _applications.Remove(_applications.Find(y => y.ApplicationDatetime == DateTime.Parse(dateCombobox.SelectedItem.ToString())));
            deleteButton.Enabled = false;
            rejectionReasonRichTextbox.Text = "";
            statusLabel.Text = $"Κατάσταση αίτησης: -";
            dateCombobox.Items.Remove(dateCombobox.SelectedItem.ToString());
            MessageBox.Show("Επιτυχής διαγραφή.", 
                            "Επιτυχία", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
        }
    }
}
