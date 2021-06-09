using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassesFolder;
using ClientForms;
using MySql.Data.MySqlClient;
using static ClassesFolder.Enums;

namespace Project.ClientForms
{
    public partial class ClientForm : Form
    {
        private readonly Client _client;
        private Dictionary<Itinerary, string> _delayedItineraries;

        public ClientForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.Text = $"Καλωσόρισες {_client.GetFullName()}";
            _client.InitializeTicketList();
            currentBoughtTicketsLabel.Text = $"Αγορασμένα εισιτηρία: {_client.TicketList.Select(x => x).Where(y => y.Used == false).Count()}";
            currentBoughtTicketsLabel.Location = new Point(this.Width / 2 - currentBoughtTicketsLabel.Width / 2,
                                                           currentBoughtTicketsLabel.Height);

            currentMoneyLabel.Text = $"{_client.Balance} Ευρώ";
            timer.Start();
        }

        private void BuyTicketButton_Click(object sender, EventArgs e)
        {
            _client.FindInformation();
            currentMoneyLabel.Text = $"{_client.Balance} Ευρώ";
            BuyTicketForm form = new BuyTicketForm(_client);
            form.ShowDialog();
        }

        private void DiscountApplicationButton_Click(object sender, EventArgs e)
        {
            DiscountForm form = new DiscountForm(_client);
            form.ShowDialog();
        }

        private void MyTicketsButton_Click(object sender, EventArgs e)
        {
            TicketCollectionForm form = new TicketCollectionForm(_client);
            form.ShowDialog();
        }

        private void ComplaintButton_Click(object sender, EventArgs e)
        {
            ClientComplaintForm form = new ClientComplaintForm(_client);
            form.ShowDialog();
        }

        private void PollButton_Click(object sender, EventArgs e)
        {
            PollAttendForm form = new PollAttendForm(_client);
            form.ShowDialog();
        }

        private void MyApplicationsButton_Click(object sender, EventArgs e)
        {
            MyApplicationsForm form = new MyApplicationsForm(_client);
            form.ShowDialog();
        }

        private void HistoryPreviewButton_Click(object sender, EventArgs e)
        {
            HistoryForm form = new HistoryForm(_client);
            form.ShowDialog();
        }

        private void BusLineInformationButton_Click(object sender, EventArgs e)
        {
            BusLineInformationForm form = new BusLineInformationForm();
            form.ShowDialog();
        }

        private void TicketReservationLastMinuteButton_Click(object sender, EventArgs e)
        {
            ReservationLastMinuteRequestsForm form = new ReservationLastMinuteRequestsForm(_client);
            form.ShowDialog();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            var result = await Task.Run(() =>
            {
                return GetCurrentItineraries();
            });

            lock (this)
            {
                _delayedItineraries = result;
            }

            if (_delayedItineraries.Count > 0)
            {
                delayedPictureBox.Image = MobileApp.Properties.Resources.bell;
            }
            else
            {
                delayedPictureBox.Image = null;
            }
        }

        public Dictionary<Itinerary, string> GetCurrentItineraries()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select itinerary.itineraryID, status, travelDatetime, busDriverUsername, busLineNumber, busID , availableSeats, lateReason
                              from itinerary
                              inner join ticket on ticket.itineraryID = itinerary.itineraryID
                              inner join busdriver on busdriver.username = itinerary.busDriverUsername
                              where clientUsername = @clientUsername and Itinerary.status = @delayed
                              order by itinerary.itineraryID desc limit 1;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clientUsername", _client.Username);
                cmd.Parameters.AddWithValue("@delayed", "delayed");
                using MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<Itinerary, string> current = new Dictionary<Itinerary, string>();

                while (reader.Read())
                {
                    int itineraryID = reader.GetInt32(0);

                    string status = reader.GetString(1);

                    ItineraryStatus enumStatus = status == "no_delayed" ? ItineraryStatus.NoDelayed : ItineraryStatus.Delayed;

                    DateTime travelDatetime = reader.GetDateTime(2);

                    string busDriverUsername = reader.GetString(3);

                    int busLineNumber = reader.GetInt32(4);

                    int busID = reader.GetInt32(5);
                    int availableSeats = reader.GetInt32(6);

                    current.Add(new Itinerary(itineraryID,
                                              travelDatetime,
                                              Functions.GetBusDriverByUsername(busDriverUsername),
                                              Functions.GetBusLine(busLineNumber),
                                              Functions.GetBus(busID),
                                              enumStatus,
                                              availableSeats), 
                                              reader.GetString(7));
                }

                return current;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }

        private void DelayedPictureBox_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            lock (this)
            {
                foreach (var itinerary in _delayedItineraries.Keys)
                {
                    sb.Append($"Το δρομολόγιο στις {itinerary.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy")} για την γραμμή {itinerary.ItineraryLine.Number} θα καθυστερήσει " +
                        $"για τον εξής λόγο: {_delayedItineraries[itinerary]}\n");
                }

            }

            if (sb.Length > 0)
                MessageBox.Show(sb.ToString(), "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
