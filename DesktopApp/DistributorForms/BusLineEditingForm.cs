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
    public partial class BusLineEditingForm : Form
    {
        private ItineraryDistributionManager _distributor;
        private List<BusLine> _busLines;

        public BusLineEditingForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void AddStopButton_Click(object sender, EventArgs e)
        {
            if (stopNameListview.SelectedItems.Count == 1)
            {
                int index = stopNameListview.SelectedIndices[0];
                List<string> stops = new List<string>();

                for (int i = 0; i < stopNameListview.Items.Count; i++)
                {
                    if (stopNameListview.Items[i].Text != stopNameTextbox.Text)
                    {
                        stops.Add(stopNameListview.Items[i].Text);
                        if (i == index)
                            stops.Add(stopNameTextbox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Η στάση που θέλετε να προσθέσετε υπάρχει ήδη στις στάσεις της γραμμής.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }

                }

                stopNameListview.Items.Clear();
                foreach (var stop in stops)
                    stopNameListview.Items.Add(new ListViewItem(stop));
            }
        }

        private void BusLineEditingForm_Load(object sender, EventArgs e)
        {
            stopNameListview.ContextMenuStrip = contextMenuStrip;
            _busLines = _distributor.GetBusLines();

            foreach (var busLine in _busLines)
                busLineNumberCombobox.Items.Add(busLine.Number.ToString());
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stopNameListview.SelectedItems.Count == 1)
                stopNameListview.Items.RemoveAt(stopNameListview.SelectedIndices[0]);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (stopNameListview.Items.Count > 2)
            {
                List<string> stops = new List<string>();
                for (int i = 0; i < stopNameListview.Items.Count; i++)
                    stops.Add(stopNameListview.Items[i].Text);

                _busLines[busLineNumberCombobox.SelectedIndex].UpdateStops(stops);

                MessageBox.Show("Επιτυχής ενημέρωση.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Μια γραμή πρέπει να περιέχει τουλάχιστον 3 στάσεις.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BusLineNumberCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (busLineNumberCombobox.SelectedItem != null)
            {
                stopNameListview.Items.Clear();

                foreach (var stops in _busLines[busLineNumberCombobox.SelectedIndex].Stops)
                    stopNameListview.Items.Add(new ListViewItem(stops));
            }
        }
    }
}
