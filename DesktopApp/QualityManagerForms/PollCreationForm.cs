using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class PollCreationForm : Form
    {
        private QualityManager _qualityManager;

        public PollCreationForm(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void PollCreationForm_Load(object sender, EventArgs e)
        {
            choicesListview.ContextMenuStrip = contextMenuStrip;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (choiceTextbox.Text == "")
            {
                MessageBox.Show("Παρακαλώ εισάγετε κείμενο για μια επιλογή.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (choicesListview.Items.Count < 4)
            {
                for (int i = 0; i < choicesListview.Items.Count; i++)
                {
                    if (choicesListview.Items[i].Text == choiceTextbox.Text)
                    {
                        MessageBox.Show("Η επιλογή υπάρχει ήδη.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }

                choicesListview.Items.Add(new ListViewItem(choiceTextbox.Text));
            }
            else
            {
                MessageBox.Show("Δεν μπορείτε να εισάγετε πάνω από 4 επιλογές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void CreatePollButton_Click(object sender, EventArgs e)
        {
            if (titleTextbox.Text != "" &&
                DateTime.Parse(startDateTimePicker.Value.ToShortDateString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()) &&
                startDateTimePicker.Value < endDateTimePicker.Value &&
                choicesListview.Items.Count > 0 &&
                questionRichTextbox.Text != "")
            {
                if (_qualityManager.GetPolls().Any(x => x.Title == titleTextbox.Text))
                {
                    MessageBox.Show("Υπάρχει ήδη μια δημοσκόπηση με αυτόν τον τίτλο.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show("Θέλετε να δημιουργήσετε αυτή την δημοσκόπηση;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var poll = new Poll(titleTextbox.Text, startDateTimePicker.Value, endDateTimePicker.Value, questionRichTextbox.Text, false);
                    var choices = new List<string>();
                    for (int i = 0; i < choicesListview.Items.Count; i++)
                        choices.Add(choicesListview.Items[i].Text);

                    _qualityManager.InsertPollInDatabase(poll);
                    _qualityManager.InsertPollChoicesInDatabase(poll, choices);

                    MessageBox.Show("Επιτυχής δημιουργία δημοσκόπησης.", 
                                    "Επιτυχία", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
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

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (choicesListview.SelectedItems.Count == 1)
            {
                choicesListview.SelectedItems[choicesListview.SelectedIndices[0]].Remove();
            }
        }
    }
}
