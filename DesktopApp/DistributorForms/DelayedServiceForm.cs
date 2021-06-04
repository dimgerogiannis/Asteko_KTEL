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
    public partial class DelayedServiceForm : Form
    {
        private ItineraryDistributionManager _ditributor;

        public DelayedServiceForm(ItineraryDistributionManager distributor)
        {
            _ditributor = distributor;
            InitializeComponent();
        }

        private void DelayedServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
