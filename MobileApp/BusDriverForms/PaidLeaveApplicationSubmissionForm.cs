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
using static ClassesFolder.Enums;

namespace Project.BusDriverForms
{
    public partial class PaidLeaveApplicationSubmissionForm : Form
    {
        private BusDriver _busDriver;

        public PaidLeaveApplicationSubmissionForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void PaidLeaveApplicationSubmissionForm_Load(object sender, EventArgs e)
        {
            if (!_busDriver.HasRemainingPaidLeaves())
            {
                MessageBox.Show("Έχετε φτάσει το μέγιστο αριθμό αδειών με αποδοχές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {        

            if (dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Άδεια μπορείτε να λάβετε από την επόμενη μέρα και μετά.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else if (reasonRichTextbox.Text == "")
            { 
                MessageBox.Show("Παρακαλώ συμπληρώστε τον λόγο για τον οποίο θέλετε να πάρετε άδεια.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }     
            else if (_busDriver.CheckDuplicatePaidLeaveApplication(dateTimePicker.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("Έχετε ήδη κάνει αίτημα για άδεια τη συγκεκριμένη μέρα.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show("Είστε σίγουρος ότι θέλετε να πάρετε άδεια την συγκεκριμένη μέρα;",
                                              "Ερώτηση",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PaidLeaveApplication application = new PaidLeaveApplication(_busDriver,
                                                                                DateTime.Now.ToString("yyyy-MM-dd"),
                                                                                reasonRichTextbox.Text,
                                                                                "",
                                                                                dateTimePicker.Value.ToString("yyyy-MM-dd"),
                                                                                Status.Pending);

                    _busDriver.InsertPaidLeaveApplicationInDatabase(application);
                    MessageBox.Show("Επιτυχής καταχώρηση άδειας στο σύστημα.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }
    }
}
