using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ChiefForms
{
    public partial class ChangeResponsibleDistributor : Form
    {
        private Chief _chief;
        private List<ItineraryDistributionManager> _distributors;
        public ChangeResponsibleDistributor(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void ChangeResponsibleDistributor_Load(object sender, EventArgs e)
        {
            _distributors = _chief.GetDistributionManagers();

            distributorCombobox.Items.AddRange(_distributors.Select(x => $"{x.Name} {x.Surname}").ToArray());
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (distributorCombobox.SelectedItem != null)
            {
                _chief.ChangeDistributionManagerState(_distributors.Find(x => x.IsResponsibleForWeek), false);
                _chief.ChangeDistributionManagerState(_distributors[distributorCombobox.SelectedIndex], true);
                MessageBox.Show("Επιτυχής καταχώρηση.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Παρακαλώ κάποιον υπεύθυνο διασφάλισης υπηρεσιών.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
