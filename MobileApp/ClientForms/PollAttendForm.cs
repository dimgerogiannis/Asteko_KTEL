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

namespace Project.ClientForms
{
    public partial class PollAttendForm : Form
    {
        private Client _client;
        public PollAttendForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void PollAttendForm_Load(object sender, EventArgs e)
        {          
            foreach (var poll in _client.AvailablePolls)
                pollTitle.Items.Add(poll.Title);
        }

        private void PollTitle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (pollTitle.SelectedItem != null)
            {
                var poll = _client.AvailablePolls.Find(x => x.Title == pollTitle.SelectedItem.ToString());
                pollQuestionRichTextbox.Text = poll.Question;

                var choices = poll.Choices.Select(x => x.Key).ToArray();

                switch (choices.Length)
                {
                    case 1:
                        firstChoiceRadioButton.Text = choices[0];
                        secondChoiceRadioButton.Enabled = false;
                        thirdChoiceRadioButton.Enabled = false;
                        forthChoiceRadioButton.Enabled = false;
                        break;
                    case 2:
                        firstChoiceRadioButton.Text = choices[0];
                        secondChoiceRadioButton.Text = choices[1];
                        thirdChoiceRadioButton.Enabled = false;
                        forthChoiceRadioButton.Enabled = false;
                        break;
                    case 3:
                        firstChoiceRadioButton.Text = choices[0];
                        secondChoiceRadioButton.Text = choices[1];
                        thirdChoiceRadioButton.Text = choices[2];
                        forthChoiceRadioButton.Enabled = false;
                        break;
                    case 4:
                        firstChoiceRadioButton.Text = choices[0];
                        secondChoiceRadioButton.Text = choices[1];
                        thirdChoiceRadioButton.Text = choices[2];
                        forthChoiceRadioButton.Text = choices[3];
                        break;
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (pollTitle.SelectedItem != null && 
               (firstChoiceRadioButton.Checked || 
                secondChoiceRadioButton.Checked || 
                thirdChoiceRadioButton.Checked || 
                forthChoiceRadioButton.Checked))
            {
                var poll = _client.AvailablePolls.Find(x => x.Title == pollTitle.SelectedItem.ToString());

                if (firstChoiceRadioButton.Checked)
                {
                    poll.IncreaseVotes(firstChoiceRadioButton.Text, _client);
                }
                else if (secondChoiceRadioButton.Checked)
                {
                    poll.IncreaseVotes(secondChoiceRadioButton.Text, _client);
                }
                else if (thirdChoiceRadioButton.Checked)
                {
                    poll.IncreaseVotes(thirdChoiceRadioButton.Text, _client);
                }
                else
                {
                    poll.IncreaseVotes(forthChoiceRadioButton.Text, _client);
                }

                MessageBox.Show("Επιτυχής καταχώρηση ψήφου!", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _client.SetPollAsUnavailable(_client.AvailablePolls.Find(x => x.Title == pollTitle.SelectedItem.ToString()));
                pollTitle.Items.Remove(pollTitle.SelectedItem);

                pollQuestionRichTextbox.Text = "";
                firstChoiceRadioButton.Text = "-";
                secondChoiceRadioButton.Text = "-";
                thirdChoiceRadioButton.Text = "-";
                forthChoiceRadioButton.Text = "-";
            }
        }
    }
}
