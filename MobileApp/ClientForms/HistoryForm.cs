using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassesFolder;

namespace Project.ClientForms
{
    public partial class HistoryForm : Form
    {
        private Client _client;

        public HistoryForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private async void HistoryForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                return Task.Delay(500);
            });

            CheckLastMonthsTransactions();
        }
  
        private void FromDatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            GetHistory();
        }

        private void ToDatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            GetHistory();
        }

        private async void GetHistory()
        {
            historyListview.Items.Clear();

            await Task.Run(() =>
            {
                var transactionList = new List<Transaction>();
                var ticketList = _client.GetTickets(fromDatetimePicker.Value.ToString("yyyy-MM-dd 00:00:00"), ToDatetimePicker.Value.ToString("yyyy-MM-dd 23:59:59"));

                foreach (var ticket in ticketList)
                    transactionList.Add(ticket.GetTransaction(_client));

                this.Invoke(new Action(() =>
                {
                    foreach (var ticket in ticketList)
                    {
                        var transaction = transactionList.Find(x => x.Ticket == ticket);
                        historyListview.Items.Add(new ListViewItem(new string[]
                        {
                            transaction.PurchaseDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                            transaction.Price.ToString(),
                            ticket.CorrespondingItinerary.ItineraryLine.Number.ToString(),
                            ticket.CorrespondingItinerary.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy")
                        }));
                    }
                    ticketNumber.Text = $"Πλήθος εισιτηρίων: {ticketList.Count}";
                    totalTicketCostLabel.Text = $"Συνολικό κόστος εισιτηρίων: {transactionList.Sum(x => x.Price)} Ευρώ";
                }));
            });
        }

        private async void CheckLastMonthsTransactions()
        {
            await Task.Run(() =>
            {
                var transactionList = new List<Transaction>();
                var ticketList = _client.GetTickets(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));

                foreach (var ticket in ticketList)
                    transactionList.Add(ticket.GetTransaction(_client));

                var sum = transactionList.Sum(x => x.Price);

                var montlyCardPrice = _client.GetMonthlyCardPrice();
                if (IsBiggerThan(sum, montlyCardPrice) &&
                    !_client.MonthlyCard)
                {
                    var result = MessageBox.Show($"Τον τελευταίο μήνα αγοράσατε {ticketList.Count} εισιτήρια κόστους {sum} Ευρώ. Θα θέλατε να αγοράσετε μηνιαία κάρτα η οποία κοστίζει μόλις {montlyCardPrice} Ευρώ το μήνα;",
                                                 "Πρόταση",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                }
            });
        }

        private bool IsBiggerThan(decimal lastMonthCost, decimal montlyCardCost)
        {
            return lastMonthCost >= montlyCardCost;
        }
    }
}
