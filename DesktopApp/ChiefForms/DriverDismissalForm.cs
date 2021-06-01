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
    public partial class DriverDismissalForm : Form
    {
        private Chief _chief;
        private List<DismissalPetition> _petitions;
        public DriverDismissalForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void DriverDismissalForm_Load(object sender, EventArgs e)
        {
            _petitions = _chief.GetDismissalPetitions();
            busDriverNameCombobox.Items.AddRange(_petitions.Select(x => x.TargetUserame).ToArray());
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (busDriverNameCombobox.SelectedItem != null)
            {
               ComplaintHistory form = new ComplaintHistory(_chief, _petitions[busDriverNameCombobox.SelectedIndex]);
               form.ShowDialog();
               _petitions[busDriverNameCombobox.SelectedIndex].DeleteDismissalPetition();
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε το όνομα κάποιου οδηγού.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }
    }
}
