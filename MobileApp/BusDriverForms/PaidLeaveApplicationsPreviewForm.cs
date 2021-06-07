using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace Project.BusDriverForms
{
    public partial class PaidLeaveApplicationsPreviewForm : Form
    {
        private BusDriver _busDriver;
        private List<PaidLeaveApplication> _applications;
        public PaidLeaveApplicationsPreviewForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void PaidLeaveApplicationsPreviewForm_Load(object sender, EventArgs e)
        {
            _applications = _busDriver.GetPaidLeaveApplications();
            foreach (var application in _applications)
            {
                var status = "";
                switch (application.Status)
                {
                    case Status.Pending:
                        status = "Εκρεμμής";
                        break;
                    case Status.Accepted:
                        status = "Εγκρίθηκε";
                        break;
                    case Status.Rejected:
                        status = "Απορρίφθηκε";
                        break;
                }
                paidLeaveApplicationsListview.Items.Add(new ListViewItem(new string[]
                {
                    application.WantedDatetime,
                    status
                }));
            }

            paidLeaveApplicationsListview.ContextMenuStrip = contextMenuStrip;
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paidLeaveApplicationsListview.SelectedItems.Count == 1)
            {
                int index = paidLeaveApplicationsListview.SelectedIndices[0];
                if (paidLeaveApplicationsListview.Items[index].SubItems[1].Text == "Απορρίφθηκε" || 
                    paidLeaveApplicationsListview.Items[index].SubItems[1].Text == "Αποδέχτηκε")
                {
                    _applications[index].DeletePaidLeaveApplication();
                    _applications.RemoveAt(index);
                    paidLeaveApplicationsListview.Items.RemoveAt(index);

                    MessageBox.Show("Επιτυχής διαγραφή",
                                    "Επιτυχία", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void RejectionReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paidLeaveApplicationsListview.SelectedItems.Count == 1)
            {
                int index = paidLeaveApplicationsListview.SelectedIndices[0];
                if (paidLeaveApplicationsListview.Items[index].SubItems[1].Text == "Απορρίφθηκε")
                {
                    rejectionReasonRitchTextbox.Text = _applications[index].PossibleRejectionReason;
                }
            }
        }
    }
}
