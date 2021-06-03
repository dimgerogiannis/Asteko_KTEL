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
using static ClassesFolder.Enums;

namespace Project.BusDriverForms
{
    public partial class ItineraryDelayForm : Form
    {
        private BusDriver _busDriver;
        private Itinerary _currentItinerary;
        public ItineraryDelayForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void DelayedReasonRichtextbox_TextChanged(object sender, EventArgs e)
        {
            delayedLabel.Text = $"Λόγος καθυστέρησης ({50 - delayedReasonRichtextbox.Text.Length})";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (delayedReasonRichtextbox.Text != "")
            {
                var result = MessageBox.Show("Θέλετε να δηλώσετε το δρομολόγιο ως καθυστερημένο;", 
                                             "Ερώτηση", 
                                             MessageBoxButtons.YesNo, 
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _currentItinerary.Status = ItineraryStatus.Delayed;
                    _busDriver.SetItineraryAsDelayed(_currentItinerary, delayedReasonRichtextbox.Text);

                    var tickets = _currentItinerary.GetTickets();

                    foreach (var ticket in tickets)
                    {
                        ticket.SetAsDelayed();
                    }

                    ItineraryCompletionWaitingForm form = new ItineraryCompletionWaitingForm(tickets);
                    form.ShowDialog();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε τον λόγο για τον οποίο το δρομολόγιο θα καθυστερήσει.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ItineraryDelayForm_Load(object sender, EventArgs e)
        {
            _currentItinerary = _busDriver.GetCurrentAssignedItinerary();
            if (_currentItinerary == null)
            {
                MessageBox.Show("Δεν πραγματοποιείται δρομολόγιο αυτή τη στιγμή.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
