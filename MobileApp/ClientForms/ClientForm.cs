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

namespace Project.ClientForms
{
    public partial class ClientForm : Form
    {
        private readonly Client _client;

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
            TicketReservationLastMinuteRequestsForm form = new TicketReservationLastMinuteRequestsForm(_client);
            form.ShowDialog();
        }
    }
}
