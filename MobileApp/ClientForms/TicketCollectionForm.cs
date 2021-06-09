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
    public partial class TicketCollectionForm : Form
    {
        private Client _client;
        public TicketCollectionForm(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void FutureTickets_Load(object sender, EventArgs e)
        {
            _client.InitializeTicketList();
            _client.UsableTicketList = new List<Ticket>();

            _client.TicketList = _client
                .TicketList
                .Select(x => x)
                .Where(y => y.Used == false)
                .ToList();

            SortByDatetimeOfItinerary();

            foreach (var ticket in _client.TicketList)
            {
                DateTime end = ticket.CorrespondingItinerary.TravelDatetime.Add(new TimeSpan(0, 
                                                                                             0, 
                                                                                             ticket.CorrespondingItinerary.ItineraryLine.Duration, 
                                                                                             0, 
                                                                                             0));
                if (CanBeUsed(ticket.CorrespondingItinerary.TravelDatetime, end))
                {
                    _client.UsableTicketList.Add(ticket);
                    ticketCollectionListview.Items.Add(new ListViewItem(new string[] 
                    { 
                        ticket.CorrespondingItinerary.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"),
                        ticket.CorrespondingItinerary.ResponsibleBus.ID.ToString() 
                    }));
                }
            }
       
            foreach (var ticket in _client.TicketList)
            {
                allTicketsListview.Items.Add(new ListViewItem(new string[]
                {
                        ticket.CorrespondingItinerary.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss"),
                        ticket.CorrespondingItinerary.ResponsibleBus.ID.ToString()
                }));
            }
        }

        private void SortByDatetimeOfItinerary()
        {
            _client.TicketList = _client
                .TicketList
                .OrderBy(x => x.CorrespondingItinerary.TravelDatetime)
                .ToList();
        }

        private bool CanBeUsed(DateTime start, DateTime end)
        {
            return start <= DateTime.Now && DateTime.Now <= end;
        }
    }
}
