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
    public partial class InputForm : Form
    {
        private Chief _chief;
        private string _text;
        private string _category;
        public InputForm(Chief chief, string text, string category)
        {
            _chief = chief;
            _text = text;
            _category = category;
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            textLabel.Text = _text;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {    
            if (_category == "Νέα τιμή μηνιαίας κάρτας")
            {
                int value;
                if (int.TryParse(inputTextbox.Text, out value) && value > 0)
                {
                    _chief.SetNewMonthlyCardPrice(value);
                    MessageBox.Show("Επιτυχής αλλαγή.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Παρακαλώ εισάγετε μια θετική ακέραια τιμή.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                decimal value;
                if (decimal.TryParse(inputTextbox.Text, out value) && value > 0)
                {
                    _chief.SetNewTicketPrice(value);
                    MessageBox.Show("Επιτυχής αλλαγή.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Παρακαλώ εισάγετε μια θετική δεκαδική τιμή μέχρι 2 δεκαδικά ψηφία.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
