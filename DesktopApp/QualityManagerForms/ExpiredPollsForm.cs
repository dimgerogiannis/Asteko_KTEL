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
    public partial class ExpiredPollsForm : Form
    {
        private QualityManager _qualityManager;
        private List<Poll> _polls;
        public ExpiredPollsForm(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void PollResultsPreview_Load(object sender, EventArgs e)
        {
            _polls = _qualityManager.GetExpiredPolls();

            foreach (var poll in _polls)
                titleCombobox.Items.Add(poll.Title);
        }

        private void TitleCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (titleCombobox.SelectedItem != null)
            {
                resultsListview.Items.Clear();

                startLabel.Text = $"Ημερομηνία έναρξης: {_polls[titleCombobox.SelectedIndex].StartingDate.ToString("dd-MM-yyyy")}";
                endLabel.Text = $"Ημερομηνία λήξης: {_polls[titleCombobox.SelectedIndex].EndingDate.ToString("dd-MM-yyyy")}";

                var results = _polls[titleCombobox.SelectedIndex].ExtractStats();
                var totalVotes = 0;
                foreach (var result in results)
                    totalVotes += result.Value;

                foreach (var result in results)
                {
                    resultsListview.Items.Add(new ListViewItem(new string[]
                    {
                        result.Key,
                        result.Value.ToString(),
                        $"{String.Format("{0:0.##}", (100 * (float)result.Value / totalVotes))}%"
                    }));
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (titleCombobox.SelectedItem != null)
            {
                var result = MessageBox.Show("Θέλετε να προσθέσετε κάποιο σχόλιο βελτίωσης;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo, 
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FeedbackForm form = new FeedbackForm(_qualityManager, _polls[titleCombobox.SelectedIndex]);
                    form.ShowDialog();

                    if (form.FeedbackSubmitted)
                    {
                        _polls[titleCombobox.SelectedIndex].DeletePoll();
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε κάποια δημοσκόπηση.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
