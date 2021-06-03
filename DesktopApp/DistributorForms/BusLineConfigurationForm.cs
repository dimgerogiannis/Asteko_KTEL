using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistributorForms
{
    public partial class BusLineConfigurationForm : Form
    {
        private ItineraryDistributionManager _distributor;

        public BusLineConfigurationForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stopNamesListview.SelectedItems.Count == 1)
            {
                stopNamesListview.Items.RemoveAt(stopNamesListview.SelectedIndices[0]);
            }
        }

        private void BusLineConfigurationForm_Load(object sender, EventArgs e)
        {
            stopNamesListview.ContextMenuStrip = base.ContextMenuStrip;
            durationCombobox.Items.AddRange(new string[]
            {
                20.ToString(),
                30.ToString(),
                40.ToString(),
                60.ToString()
            });
        }

        private void RemoveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (stopNamesListview.SelectedItems.Count == 1)
            {
                stopNamesListview.Items.RemoveAt(stopNamesListview.SelectedIndices[0]);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (busLineNumberTextbox.Text != "" &&
                durationCombobox.SelectedItem != null &&
                stopNamesListview.Items.Count > 2)
            {
                int number;
                if (!int.TryParse(busLineNumberTextbox.Text, out number))
                {
                    MessageBox.Show("Παρακαλώ εισάγετε ένα θετικό μη μηδενικό ακέραιο στο πεδίο \"αριθμός γραμμής\"",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                if (_distributor.CheckDuplicateBusLineNumber(number))
                {
                    MessageBox.Show($"Υπάρχει ήδη γραμμή με τον αριθμό {number}. Παρακαλώ βάλτε κάποιο άλλο αριθμό.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                List<string> stops = new List<string>();
                for (int i = 0; i < stopNamesListview.Items.Count; i++)
                {
                    stops.Add(stopNamesListview.Items[i].Text);
                }

                BusLine busLine = new BusLine(number,
                                              int.Parse(durationCombobox.SelectedItem.ToString()), 
                                              stops);

                busLine.InsertBusLineInDatabase();
                busLine.InsertBusStopsInDatabase();

                MessageBox.Show("Επιτυχής καταχώρηση.", 
                                "Επιτυχία", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                busLineNumberTextbox.Text = "";
                stopNameTextbox.Text = "";
                stopNamesListview.Items.Clear();
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα απαιτούμενα πεδία και τουλάχιστον 3 στάσεις.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void SubmitStopButton_Click(object sender, EventArgs e)
        {
            if (stopNameTextbox.Text != "")
            {
                for (int i = 0; i < stopNamesListview.Items.Count; i++)
                {
                    if (stopNamesListview.Items[i].Text == stopNameTextbox.Text)
                    {
                        MessageBox.Show("Το όνομα στάσης υπάρχει ήδη στις στα ονόματα στάσεων που έχετε προσθέσει.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }

                stopNamesListview.Items.Add(new ListViewItem(stopNameTextbox.Text));
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το πεδίο \"Όνομα στάσης\".",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
