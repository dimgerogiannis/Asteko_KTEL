using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ChiefForms
{
    public partial class DiscountForm : Form
    {
        private Chief _chief;
        public DiscountForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            categoryCombobox.Items.AddRange(new string[]
            {
                "Μαθητής",
                "Φαντάρος",
                "Χαμηλό εισόδημα",
                "Άτομο με ειδικές ανάγκες"
            });
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (categoryCombobox.SelectedItem != null && percentageTextbox.Text != "")
            {
                int value;
                if (int.TryParse(percentageTextbox.Text, out value) && value >= 0 && value < 100)
                {
                    Category category = Category.Student;
                    switch (percentageTextbox.Text)
                    {
                        case "Μαθητής":
                            category = Category.Student;
                            break;
                        case "Φαντάρος":
                            category = Category.Soldier;
                            break;
                        case "Χαμηλό εισόδημα":
                            category = Category.LowIncome;
                            break;
                        case "Άτομο με ειδικές ανάγκες":
                            category = Category.DissabilityIssues;
                            break;
                    }

                    _chief.SetDiscountCategoryPercentage(category, value);

                    MessageBox.Show("Επιτυχής αλλάγή τιμής.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Παρακαλώ εισάγετε μια τιμή στο διάστημα 0 εως 99.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
