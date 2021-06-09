using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClientForms
{
    public partial class ReservationLastMinuteRequestsForm : Form
    {
        private Client _client;

        public ReservationLastMinuteRequestsForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void TicketReservationLastMinuteRequestsForm_Load(object sender, EventArgs e)
        {
            categoryCombobox.Items.AddRange(new string[] 
            {
                "Κρατήσεις",
                "Αιτήματα καθυστερημένης εξυπηρέτησης"
            });
        }

        private void CategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryCombobox.SelectedItem != null)
            {
                switch (categoryCombobox.SelectedItem.ToString())
                {
                    case "Κρατήσεις":
                        FillReservations();
                        break;
                    case "Αιτήματα καθυστερημένης εξυπηρέτησης":
                        FillLastMinuteTravelRequests();
                        break;
                }
            }
        }

        private void FillReservations()
        {
            infoListview.Items.Clear();
            foreach (var reservation in _client.ReservationList)
            {
                infoListview.Items.Add(new ListViewItem(new string[]
                {
                    reservation.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                    reservation.TravelBusLine.Number.ToString(),
                    "-"
                }));
            }
        }

        private void FillLastMinuteTravelRequests()
        {
            infoListview.Items.Clear();
            foreach (var lastMinuteTravelRequest in _client.GetLastMinuteTravelRequests())
            {
                Status _status = lastMinuteTravelRequest.Status;
                var status = "Εκκρεμής";

                switch (_status)
                {
                    case Status.Accepted:
                        status = "Εγκρίθηκε";
                        break;
                    case Status.Rejected:
                        status = "Απορρίφθηκε";
                        break;
                }

                infoListview.Items.Add(new ListViewItem(new string[]
                {
                    lastMinuteTravelRequest.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                    lastMinuteTravelRequest.TravelBusLine.Number.ToString(),
                    status
                }));
            }
        }
    }
}
