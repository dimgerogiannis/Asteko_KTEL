using MySql.Data.MySqlClient;
using ClassesFolder;
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
using static ClassesFolder.Enums;

namespace Project.ClientForms
{
    public partial class BuyTicketForm : Form
    {
        private Client _client;
        private List<BusLine> _lines;
        public BuyTicketForm(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void BuyTicketButton_Click(object sender, EventArgs e)
        {
            if (lineNumberCombobox.SelectedItem == null || 
                timeCombobox.SelectedItem == null)
            {
                MessageBox.Show("Παρακαλώ βάλτε γραμμή λεωφορείου και ώρα δρομολογίου.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            var today = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"));
            var selected = DateTime.Parse(dateTimePicker.Value.ToString("dd-MM-yyyy"));
            var databaseDatetimeFormat = dateTimePicker.Value.ToString($"yyyy-MM-dd {timeCombobox.SelectedItem}:00");

            if (selected <= today)
            {
                MessageBox.Show("Παρακαλώ βάλτε σωστή ημερομηνία, δηλαδή από την επόμενη μέρα.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            if (_client.CheckForDuplicateTicket(lineNumberCombobox.SelectedItem.ToString(), databaseDatetimeFormat))
            {
                MessageBox.Show("Έχετε ήδη αγοράσει εισητήριο για αυτό το δρομολόγιο.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            if (_client.ReservationList.Any(x => x.TravelBusLine.Number == int.Parse(lineNumberCombobox.SelectedItem.ToString()) && 
                x.TravelDatetime.ToString("yyyy-MM-dd HH:mm:ss") == databaseDatetimeFormat))
            {
                MessageBox.Show("Έχετε ήδη κάνει κράτηση θέσης για αυτό το δρομολόγιο.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            if (_client.CheckForDuplicateLastMinuteTravelRequest(lineNumberCombobox.SelectedItem.ToString(), 
                databaseDatetimeFormat))
            {
                MessageBox.Show("Έχετε ήδη κάνει αίτημα καθυστερημένης εξυπηρέτησης για αυτό το δρομολόγιο.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var price = _client.FindStandardTicketPrice();

            var lastMinuteDates = GetLastMinuteAvailableDates();

            var reservationDates = GetReservationAvailableDates()
                    .Select(x => x)
                    .Where(x => !lastMinuteDates.Contains(x))
                    .ToList();

            if (!lastMinuteDates.Contains(dateTimePicker.Value.ToString("dd-MM-yyyy")) &&
                !reservationDates.Contains(dateTimePicker.Value.ToString("dd-MM-yyyy")))
            {
                MessageBox.Show($"Παρακαλώ συμπληρώστε σωστή ημερομηνία, δηλαδή στο διάστημα [{DateTime.Now.AddDays(1).ToString("dd-MM-yyyy")}, {reservationDates[reservationDates.Count - 1]}].",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


            if (lastMinuteDates.Contains(dateTimePicker.Value.ToString("dd-MM-yyyy")))
            {
                if (_client.CanAffordCost(price))
                {
                    var itineraries = _client.GetMatchingItineraries(lineNumberCombobox.SelectedItem.ToString(),
                                                                     DateTime.Parse($"{dateTimePicker.Value.ToString("yyyy-MM-dd")} {timeCombobox.SelectedItem}").ToString("yyyy-MM-dd HH:mm:ss"));

                    bool flag = false;
                    foreach (var itinerary in itineraries)
                    {
                        if (itinerary.AvailableSeats > 0)
                        {
                            MessageBox.Show("Βρέθηκε δρομολόγιο με διαθέσιμη θέση.",
                                            "Επιτυχία",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            flag = true;

                            _client.AutomaticTicketPurchase(itinerary);
                            _client.PayForTicket(price);

                            _client.AddToCollection(new Ticket(itinerary, 
                                                               false, 
                                                               false));

                            itinerary.DecrementItinerarySeats();
                            _client.InsertTransactionToDatabase(_client.GetLastTicketID(), price);
                            break;
                        }
                    }

                    if (!flag)
                    {
                        LastMinuteTravelRequest lastMinuteTravelRequest = 
                            new LastMinuteTravelRequest(_client,
                                                        DateTime.Today.ToString("yyyy-MM-dd"),
                                                        DateTime.Parse($"{dateTimePicker.Value.ToString("yyyy-MM-dd")} {timeCombobox.SelectedItem}:00"),
                                                        Functions.GetBusLine(int.Parse(lineNumberCombobox.SelectedItem.ToString())),
                                                        Status.Pending);

                        _client.InsertLastMinuteTravelRequestToDatabase(lastMinuteTravelRequest);

                        MessageBox.Show("Δεν βρέθηκε δρομολόγιο με διαθέσιμη θέση και για αυτό έγινε αίτημα καθυστερημένης εξυπηρέτησης.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Μη επαρκές υπόλοιπο.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else if (reservationDates.Contains(dateTimePicker.Value.ToString("dd-MM-yyyy")))
            {
                // Reservation
                if (_client.MonthlyCard)
                {
                    var result = MessageBox.Show("Θέλετε να προχωρήσετε στην αγορά;", 
                                                 "Ερώτηση", 
                                                 MessageBoxButtons.YesNo, 
                                                 MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        // Do reservation for next week
                        Reservation reservation = new Reservation(_client, 
                                                                  DateTime.Now,
                                                                  DateTime.Parse($"{dateTimePicker.Value.ToShortDateString()} {timeCombobox.SelectedItem}"),
                                                                  Functions.GetBusLine(int.Parse(lineNumberCombobox.SelectedItem.ToString())),
                                                                  0m);
                        
                        _client.InsertReservationToDatabase(reservation, 0m);

                        _client.ReservationList.Add(reservation);

                        MessageBox.Show("Έγινε κράτηση θέσης για την επόμενη εβδομάδα.", 
                                        "Επιτυχία", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                }
                else
                {
                    decimal ticketPrice = _client.CalculateTicketPrice(price);

                    // Έλεγχος αν ο Client μπορεί να αγοράσει εισητήριο
                    if (_client.CanAffordCost(ticketPrice))
                    {
                        var result = MessageBox.Show("Θέλετε να προχωρήσετε στην αγορά;", 
                                                     "Ερώτηση", 
                                                     MessageBoxButtons.YesNo, 
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Ο Client πληρώνει για το εισητίριο
                            _client.PayForTicket(ticketPrice);

                            // Γίνεται reservation για δρομολόγιο της επόμενης εβδομάδας
                            Reservation reservation = new Reservation(_client,
                                                                      DateTime.Now,
                                                                      DateTime.Parse($"{dateTimePicker.Value.ToShortDateString()} {timeCombobox.SelectedItem}"),
                                                                      Functions.GetBusLine(int.Parse(lineNumberCombobox.SelectedItem.ToString())),
                                                                      ticketPrice);

                            _client.PayForTicket(ticketPrice);
                            _client.InsertReservationToDatabase(reservation,
                                                                ticketPrice);

                            _client.ReservationList.Add(reservation);

                            MessageBox.Show("Έγινε κράτηση θέσης για την επόμενη εβδομάδα.", 
                                            "Επιτυχία", 
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Μη επαρκές υπόλοιπο.", 
                                        "Σφάλμα", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void BuyTicketForm_Load(object sender, EventArgs e)
        {
            _lines = Functions.GetBusLines();
            foreach (var line in _lines)
                lineNumberCombobox.Items.Add(line.Number.ToString());
        }

        private void LineNumberCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lineNumberCombobox.SelectedItem != null)
            {
                timeCombobox.Items.Clear();
                foreach (var hour in _lines[int.Parse(lineNumberCombobox.SelectedItem.ToString()) - 1].GetAvailableStartingHours())
                {
                    timeCombobox.Items.Add(hour);
                }                
            }
        }

        /// <summary>
        /// Method that generates all the dates from tomorrow until the last day of the week which is Sunday
        /// </summary>
        /// <returns>A List of strings that contains dates</returns>
        public static List<string> GetLastMinuteAvailableDates()
        {
            List<string> dates = new List<string>();
            if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
            {
                DateTime start = DateTime.Today;
                DateTime end = DateTime.Today;
                start = start.AddDays(1);
                end = end.AddDays(7 - (int)DateTime.Today.DayOfWeek);
                while (start <= end)
                {
                    dates.Add(start.ToString("dd-MM-yyyy"));
                    start = start.AddDays(1);
                }
            }

            return dates;
        }

        /// <summary>
        /// A method that returns all the dates of the current week and the next week
        /// </summary>
        /// <returns>A List of strings which are dates</returns>
        public static List<string> GetReservationAvailableDates()
        {
            List<string> dates = new List<string>();
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today;
            start = start.AddDays(1);
            if (DateTime.Today.DayOfWeek != DayOfWeek.Sunday)
            {
                end = end.AddDays(14 - (int)DateTime.Today.DayOfWeek);
                while (start <= end)
                {
                    dates.Add(start.ToString("dd-MM-yyyy"));
                    start = start.AddDays(1);
                }
            }
            else
            {
                end = end.AddDays(7 - (int)DateTime.Today.DayOfWeek);
                while (start <= end)
                {
                    dates.Add(start.ToString("dd-MM-yyyy"));
                    start = start.AddDays(1);
                }
            }

            return dates;
        }
    }
}
