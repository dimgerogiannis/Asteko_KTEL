using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistributorForms
{
    public partial class FeedbackForm : Form
    {
        private ItineraryDistributionManager _distributor;
        private List<Feedback> _feedbacks;

        public FeedbackForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void NumberCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numberCombobox.SelectedItem != null)
            {
                feedbackRichTextbox.Text = _feedbacks[numberCombobox.SelectedIndex].FeedbackText;
            }
        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            _feedbacks = _distributor.GetFeedbacks();
            numberCombobox.Items.AddRange(Enumerable.Range(1, _feedbacks.Count).Select(x => x.ToString()).ToArray());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (numberCombobox.SelectedItem != null)
            {
                _distributor.DeleteFeedback(_feedbacks[numberCombobox.SelectedIndex]);
                _feedbacks.RemoveAt(numberCombobox.SelectedIndex);
                feedbackRichTextbox.Text = "";
                numberCombobox.Items.Clear();
                numberCombobox.Items.AddRange(Enumerable.Range(1, _feedbacks.Count).Select(x => x.ToString()).ToArray());
                MessageBox.Show("Επιτυχής διαγραφή.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε κάποιο σχόλιο βελτίωσης.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
