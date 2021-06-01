using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class QualityManagerForm : Form
    {
        private QualityManager _qualityManager;

        public QualityManagerForm(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void QualityManagerForm_Load(object sender, EventArgs e)
        {
            fullNameLabel.Text = _qualityManager.GetFullName() + "    ";
            fullNameLabel.Location = fullNameLabel.Location = new Point(this.Width / 2 - fullNameLabel.Width / 2, 50);
            salaryLabel.Text = $"{_qualityManager.Salary} Ευρώ";
        }

        private void HealthViolationComplaintsLabel_Click(object sender, EventArgs e)
        {
            BusDriverComplaintsForm form = new BusDriverComplaintsForm(_qualityManager);
            form.ShowDialog();
        }

        private void ReviewDiscountApplicationsLabel_Click(object sender, EventArgs e)
        {
            DiscountApplications form = new DiscountApplications(_qualityManager);
            form.ShowDialog();
        }

        private void ClientComplaintsLabel_Click(object sender, EventArgs e)
        {
            ClientComplaintReviewForm form = new ClientComplaintReviewForm(_qualityManager);
            form.ShowDialog();
        }

        private void ResultsLabel_Click(object sender, EventArgs e)
        {
            ExpiredPollsForm form = new ExpiredPollsForm(_qualityManager);
            form.ShowDialog();
        }

        private void CreateLabel_Click(object sender, EventArgs e)
        {
            PollCreationForm form = new PollCreationForm(_qualityManager);
            form.ShowDialog();
        }
    }
}
