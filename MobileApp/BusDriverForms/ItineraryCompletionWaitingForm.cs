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

namespace Project.BusDriverForms
{
    public partial class ItineraryCompletionWaitingForm : Form
    {
        private List<Ticket> _tickets;

        public ItineraryCompletionWaitingForm(List<Ticket> tickets)
        {
            _tickets = tickets;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Θέλετε να δηλώσετε ότι το δρομολόγιο ολοκληρώθηκε;",
                                         "Ερώτηση",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (var ticket in _tickets)
                {
                    ticket.UnsetDelayed();
                    ticket.SetAsUsed();
                }

                MessageBox.Show("Το δρομολόγιο τέθηκε ως ολοκληρωμένο.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
