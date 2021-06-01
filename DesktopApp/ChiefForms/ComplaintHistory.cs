using ClassesFolder;
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
                    complaint.TargetUsername,
                    category,
                    complaint.ClientUsername
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
            var result = MessageBox.Show("Θέλετε να προχωρήσετε σε απόλυση του οδηγού;",
                                         "Ερώτηση",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                _chief.DeleteClientComplaints(_complaints);
                _chief.DeletePaidLeaveApplications(_chief.GetPaidLeaveApplications(_petition.TargetUserame));
                _chief.DeletePaidLeaveDates(_petition.TargetUserame);
                this.Close();
            }
            else
            {
                var busDriver = _chief.GetBusDriver(_complaints[0].TargetUsername);
                busDriver.ResetComplaintsCounter();

                this.Close();
            }
        }
    }
}
