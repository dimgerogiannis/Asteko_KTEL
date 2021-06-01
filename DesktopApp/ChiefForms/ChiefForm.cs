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
    public partial class ChiefForm : Form
    {
        private Chief _chief;

        public ChiefForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void ChiefForm_Load(object sender, EventArgs e)
        {        
            salaryLabel.Text = $"{_chief.Salary} Ευρώ";

            fullNameLabel.Text = _chief.GetFullName() + "    " ;
            fullNameLabel.Location = fullNameLabel.Location = new Point(this.Width / 2 - fullNameLabel.Width / 2, 50);

            var responsibleDistributor = _chief.GetDistributionManagers().Find(x => x.IsResponsibleForWeek);
            responsibleDitributorLabel.Text = $"{responsibleDistributor.Name} {responsibleDistributor.Surname}";        }

        private void BaseTicketPriceLabel_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm(_chief, "Νέα τιμή εισητηρίου", "ticket_price");
            form.ShowDialog();
        }

        private void MonthCardLabel_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm(_chief, "Νέα τιμή μηνιαίας κάρτας", "month_card_price");
            form.ShowDialog();
        }

        private void DiscountLabel_Click(object sender, EventArgs e)
        {
            DiscountForm form = new DiscountForm(_chief);
            form.ShowDialog();
        }

        private void HireLabel_Click(object sender, EventArgs e)
        {
            HireForm form = new HireForm(_chief);
            form.ShowDialog();
        }

        private void EmployeeLabel_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm(_chief);
            form.ShowDialog();
        }

        private void ChangeLabel_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                ChangeResponsibleDistributor form = new ChangeResponsibleDistributor(_chief);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Η αλλαγή του υπεύθυνου για την κατανομή δρομολογίων μπορεί να συμβεί μόνο τις Κυριακές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BusDriverApplicationsLabel_Click(object sender, EventArgs e)
        {
            PaidLeaveRequestsForm form = new PaidLeaveRequestsForm(_chief);
            form.ShowDialog();
        }

        private void WatchLabel_Click(object sender, EventArgs e)
        {
            MonetaryStatsForm form = new MonetaryStatsForm(_chief);
            form.ShowDialog();
        }

        private void BusDriverFireLabel_Click(object sender, EventArgs e)
        {
            DriverDismissalForm form = new DriverDismissalForm(_chief);
            form.ShowDialog();
        }
    }
}
