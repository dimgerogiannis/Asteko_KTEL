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
            int salary;

            if (usernameTextbox.Text != "" &&
                passwordTextbox.Text != "" &&
                nameTextbox.Text != "" &&
                surnameTextbox.Text != "" &&
                int.TryParse(salaryTextbox.Text, out salary) &&
                salary > 0 &&
                experienceCobmobox.SelectedItem != null &&
                categoryCombobox.SelectedItem != null)
            {
                var category = categoryCombobox.SelectedItem.ToString();

                if (category == "Οδηγός λεωφορείων")
                {
                    if (!_chief.CheckDuplicateUsername(usernameTextbox.Text))
                    {
                        _chief.InsertUserInDatabase(usernameTextbox.Text,
                                                    passwordTextbox.Text,
                                                    nameTextbox.Text,
                                                    surnameTextbox.Text,
                                                    "bus_driver");

                        _chief.InsertEmployeeInDatabase(usernameTextbox.Text,
                                                            salary,
                                                            int.Parse(experienceCobmobox.SelectedItem.ToString()));

                        _chief.InsertBusDriverInInDatabase(usernameTextbox.Text);

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
                        string prop = "";
                        switch (categoryCombobox.SelectedItem.ToString()) 
                        {
                            case "Υπ. διασφάλισης υπηρεσιών":
                                prop = "quality_manager";
                                break;
                            case "Υπ. κατανομής δρομολογίων":
                                prop = "itinerary_distributor";
                                break;
                        }

                        _chief.InsertUserInDatabase(usernameTextbox.Text,
                                                    passwordTextbox.Text,
                                                    nameTextbox.Text,
                                                    surnameTextbox.Text,
                                                    prop);

                        _chief.InsertEmployeeInDatabase(usernameTextbox.Text,
                                                          salary,
                                                          int.Parse(experienceCobmobox.SelectedItem.ToString()));

                        if (prop == "quality_manager")
                        {
                            _chief.InsertQualityManagerInInDatabase(usernameTextbox.Text);
                        }
                        else
                        {
                            _chief.InsertItineraryDistributionManagerInInDatabase(usernameTextbox.Text);
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
