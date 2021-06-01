using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class FeedbackForm : Form
    {
        private QualityManager _qualityManager;
        private Poll _poll;
        public bool FeedbackSubmitted;

        public FeedbackForm(QualityManager qualityManager, Poll poll)
        {
            _qualityManager = qualityManager;
            _poll = poll;
            InitializeComponent();
        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            FeedbackSubmitted = false;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (feedbackRichTextbox.Text != "")
            {
                var result = MessageBox.Show("Θέλετε να καταχωρήσετε τα σχόλια βελτίωσης;", 
                                             "Ερώτηση", 
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Feedback feedback = new Feedback(feedbackRichTextbox.Text);
                    _qualityManager.InsertFeedbackInDatabase(feedback);
                    MessageBox.Show("Επιτυχής καταχώρηση.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    FeedbackSubmitted = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το σχόλιο βελτίωσης.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }
    }
}
