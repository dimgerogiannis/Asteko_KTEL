using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChiefForms
{
    public partial class PaidLeaveRequestsForm : Form
    {
        private Chief _chief;
        private List<PaidLeaveApplication> _applications;

        public PaidLeaveRequestsForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void PaidLeaveRequestsForm_Load(object sender, EventArgs e)
        {
            _applications = _chief.FindUncheckedPaidLeaveApplications();
            foreach (var application in _applications)
            {
                applicationsListview.Items.Add(new ListViewItem(new string[]
                {
                    application.ApplicantDriver.GetFullName(),
                    application.ApplicationDatetime,
                    application.WantedDatetime
                }));
            }

            applicationsListview.ContextMenuStrip = contextMenuStrip;
        }

        private void ReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (applicationsListview.SelectedItems.Count == 1)
            {
                ReasonForm form = new ReasonForm(_applications[applicationsListview.SelectedIndices[0]].Reason);
                form.ShowDialog();
            }
        }

        private void AcceptOrRejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (applicationsListview.SelectedItems.Count == 1)
            {
                var index = applicationsListview.SelectedIndices[0];
                var application = _applications[index];

                var result = MessageBox.Show("Αποδέχεστε την αίτηση;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    application.SetAsAccepted();
                    application.UpdatePaidLeaveApplcationStatus();

                    var busDriver = application.ApplicantDriver;
                    busDriver.SetAsUnavailable(application.WantedDatetime);
                    busDriver.DecreaseYearlyPaidDates();
                }
                else
                {
                    RejectReasonForm form = new RejectReasonForm(_chief, application);
                    form.ShowDialog();
                }

                applicationsListview.Items.RemoveAt(index);

                MessageBox.Show("Επιτυχής επεργασία αίτησης.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
