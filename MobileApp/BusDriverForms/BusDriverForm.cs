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

namespace Project.BusDriverForms
{
    public partial class BusDriverForm : Form
    {
        private BusDriver _busDriver;

        public BusDriverForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void BusDriverForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Καλωσόρισες {_busDriver.Name} {_busDriver.Surname}";
            salaryLabel.Text = $"{_busDriver.Salary} Ευρώ";
            salaryLabel.Location = new Point(this.Width / 2 - salaryLabel.Width / 2, salaryLabel.Height);
        }

        private void WeekScheduleButton_Click(object sender, EventArgs e)
        {
            WeekScheduleForm form = new WeekScheduleForm(_busDriver);
            form.ShowDialog();
        }

        private void HealthViolationButton_Click(object sender, EventArgs e)
        {
            SanitaryComplaintForm form = new SanitaryComplaintForm(_busDriver);
            form.ShowDialog();
        }

        private void LateItineraryDeclareButton_Click(object sender, EventArgs e)
        {
            ItineraryDelayForm form = new ItineraryDelayForm(_busDriver);
            form.ShowDialog();
        }

        private void IncommingComplaintsButton_Click(object sender, EventArgs e)
        {
            IncommingComplaintForm form = new IncommingComplaintForm(_busDriver);
            form.ShowDialog();
        }

        private void OnLeaveApplicationsButton_Click(object sender, EventArgs e)
        {
            PaidLeaveApplicationSubmissionForm form = new PaidLeaveApplicationSubmissionForm(_busDriver);
            form.ShowDialog();
        }

        private void OnLeaveApplicationPreviewButton_Click(object sender, EventArgs e)
        {
            PaidLeaveApplicationsPreviewForm form = new PaidLeaveApplicationsPreviewForm(_busDriver);
            form.ShowDialog();
        }
    }
}
