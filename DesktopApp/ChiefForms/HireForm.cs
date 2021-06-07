using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChiefForms
{
    public partial class HireForm : Form
    {
        private Chief _chief;

        public HireForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            decimal salary;

            if (usernameTextbox.Text != "" &&
                passwordTextbox.Text != "" &&
                nameTextbox.Text != "" &&
                surnameTextbox.Text != "" &&
                decimal.TryParse(salaryTextbox.Text, out salary) &&
                salary > 0 &&
                experienceCobmobox.SelectedItem != null &&
                categoryCombobox.SelectedItem != null)
            {
                var category = categoryCombobox.SelectedItem.ToString();

                if (category == "Οδηγός λεωφορείων")
                {
                    if (!_chief.CheckDuplicateUsername(usernameTextbox.Text))
                    {
                        _chief.InsertUserInDatabase(new User(usernameTextbox.Text,
                                                             nameTextbox.Text,
                                                             surnameTextbox.Text,
                                                             Enums.Specialization.BusDriver),
                                                             passwordTextbox.Text);

                        _chief.InsertEmployeeInDatabase(new Employee(usernameTextbox.Text,
                                                                     nameTextbox.Text,
                                                                     surnameTextbox.Text,
                                                                     Enums.Specialization.BusDriver,
                                                                     salary,
                                                                     int.Parse(experienceCobmobox.SelectedItem.ToString()),
                                                                     DateTime.Now.ToShortDateString()));

                        _chief.InsertBusDriverInDatabase(new BusDriver(usernameTextbox.Text,
                                                                       nameTextbox.Text,
                                                                       surnameTextbox.Text,
                                                                       Enums.Specialization.BusDriver,
                                                                       salary,
                                                                       int.Parse(experienceCobmobox.SelectedItem.ToString()),
                                                                       DateTime.Today.ToShortDateString(),
                                                                       0));

                        MessageBox.Show("Επιτυχής καταχώρηση.",
                                        "Επιτυχία",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Το όνομα χρήστη υπάρχει ήδη. Παρακαλώ συμπληρώστε κάποιο άλλο.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!_chief.CheckDuplicateUsername(usernameTextbox.Text))
                    {
                        Enums.Specialization specialization = Enums.Specialization.QualityManager;

                        if (categoryCombobox.SelectedItem.ToString() == "Υπ. διασφάλισης υπηρεσιών")
                        {
                            specialization = Enums.Specialization.QualityManager;
                        }
                        else
                        {
                            specialization = Enums.Specialization.Distributor;
                        }

                        _chief.InsertUserInDatabase(new User(usernameTextbox.Text,
                                                             nameTextbox.Text,
                                                             surnameTextbox.Text,
                                                             specialization),
                                                             passwordTextbox.Text);

                        _chief.InsertEmployeeInDatabase(new Employee(usernameTextbox.Text,
                                                                     nameTextbox.Text,
                                                                     surnameTextbox.Text,
                                                                     specialization,
                                                                     salary,
                                                                     int.Parse(experienceCobmobox.SelectedItem.ToString()),
                                                                     DateTime.Today.ToShortDateString()));

                        if (specialization == Enums.Specialization.QualityManager)
                        {
                            _chief.InsertQualityManagerInDatabase(new QualityManager(usernameTextbox.Text,
                                                                                     nameTextbox.Text,
                                                                                     surnameTextbox.Text,
                                                                                     specialization,
                                                                                     salary,
                                                                                     int.Parse(experienceCobmobox.SelectedItem.ToString()),
                                                                                     DateTime.Today.ToShortDateString()));
                        }
                        else
                        {
                            _chief.InsertItineraryDistributionManagerInDatabase(new ItineraryDistributionManager(usernameTextbox.Text,
                                                                                                                 nameTextbox.Text,
                                                                                                                 surnameTextbox.Text,
                                                                                                                 specialization,
                                                                                                                 salary,
                                                                                                                 int.Parse(experienceCobmobox.SelectedItem.ToString()),
                                                                                                                 DateTime.Today.ToShortDateString(),
                                                                                                                 false));
                        }

                        MessageBox.Show("Επιτυχής καταχώρηση.",
                                        "Επιτυχία",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Το όνομα χρήστη υπάρχει ήδη. Παρακαλώ συμπληρώστε κάποιο άλλο.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα στοιχεία σωστά. Ο μισθός πρέπει να είνα θετικός ακέραιος αριθμός.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }       
        }

        private void HireForm_Load(object sender, EventArgs e)
        {
            categoryCombobox.Items.AddRange(new string[]
            {
                "Οδηγός λεωφορείων",
                "Υπ. διασφάλισης υπηρεσιών",
                "Υπ. κατανομής δρομολογίων",
            });

            experienceCobmobox.Items.AddRange(Enumerable.Range(0, 30).Select(x => x.ToString()).ToArray());
        }
    }
}
