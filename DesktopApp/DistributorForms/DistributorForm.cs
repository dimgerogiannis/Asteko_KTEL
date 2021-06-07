using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistributorForms
{
    public partial class DistributorForm : Form
    {
        private ItineraryDistributionManager _distributor;

        public DistributorForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void DistributorForm_Load(object sender, EventArgs e)
        {
            fullNameLabel.Text = _distributor.GetFullName() + "    ";
            fullNameLabel.Location = fullNameLabel.Location = new Point(this.Width / 2 - fullNameLabel.Width / 2, 50);
            salaryLabel.Text = $"{_distributor.Salary} Ευρώ";

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                programmingLabel.Click += ProgrammingLabel_Click;
            }
        }

        private void ImprovementCommentsLabel_Click(object sender, EventArgs e)
        {
            FeedbackForm form = new FeedbackForm(_distributor);
            form.ShowDialog();
        }

        private void AddNewBusLineLabel_Click(object sender, EventArgs e)
        {
            BusLineConfigurationForm form = new BusLineConfigurationForm(_distributor);
            form.ShowDialog();
        }

        private void ProcessBusLineStops_Click(object sender, EventArgs e)
        {
            BusLineEditingForm form = new BusLineEditingForm(_distributor);
            form.ShowDialog();
        }

        private void ProgrammingLabel_Click(object sender, EventArgs e)
        {
            ItineraryDistributionForm form = new ItineraryDistributionForm(_distributor);
            form.ShowDialog();
        }

        private void LastMinuteTravelRequestsLabel_Click(object sender, EventArgs e)
        {
            DelayedServiceForm form = new DelayedServiceForm(_distributor);
            form.ShowDialog();
        }
    }
}
