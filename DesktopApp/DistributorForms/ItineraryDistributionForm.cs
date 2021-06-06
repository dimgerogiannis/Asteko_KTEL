using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace DistributorForms
{
    public partial class ItineraryDistributionForm : Form
    {
        private ItineraryDistributionManager _distributor;

        private List<Reservation> _reservations;
        private Dictionary<string, List<Reservation>> _dictionary;

        private List<BusLine> _busLines;
        private int _busLineIndex;
        private List<Bus> _buses;
        private List<BusDriver> _busDrivers;
        private string _date;
        private string _hour;

        public ItineraryDistributionForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void ItineraryDistributionForm_Load(object sender, EventArgs e)
        {
            _busLines = _distributor.GetBusLines();
            _dictionary = new Dictionary<string, List<Reservation>>();
            _reservations = _distributor.GetReservations();

            foreach (var reservation in _reservations)
            {
                var key = $"{reservation.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy")}{reservation.TravelBusLine}";
                if (!_dictionary.ContainsKey(key))
                {
                    _dictionary.Add(key, new List<Reservation>());
                    _dictionary[key].Add(reservation);
                }
                else
                {
                    _dictionary[key].Add(reservation);
                }
            }

            FillReservationListview();

            busLineNumberCombobox.Items.AddRange(_distributor.GetBusLines().Select(x => x.Number.ToString()).ToArray());
            sizeCombobox.Items.AddRange(new string[] { "Μεγάλο", "Μεσαίο", "Μικρό" });
        }

        private void FillReservationListview()
        {
            rereservationsListview.Items.Clear();

            foreach (var key in _dictionary.Keys)
            {
                var item = _dictionary[key];

                if (item.Count == 0)
                    continue;

                rereservationsListview.Items.Add(new ListViewItem(new string[]
                {
                    item[0].TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                    item[0].TravelBusLine.ToString(),
                    _dictionary[key].Count.ToString()
                }));
            }
        }

        private void ProgrammingButton_Click(object sender, EventArgs e)
        {
            if (busLineNumberCombobox.SelectedItem != null &&
                availableStartingHoursCombobox.SelectedItem != null &&
                sizeCombobox.SelectedItem != null
                )
            {
                recommendedBusesListview.Items.Clear();
                recommendedDriversListview.Items.Clear();


                _busLineIndex = busLineNumberCombobox.SelectedIndex;

                if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (!GetReservationAvailableDates().Contains(dateTimePicker.Value.ToString("dd-MM-yyyy")))
                    {
                        MessageBox.Show($"Μη επιτρεπτή ημερομηνία.",
                                        "Σφάλμα",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }

                var lastMinuteDates = GetLastMinuteAvailableDates();
                var reservationDates = GetReservationAvailableDates()
                    .Select(x => x)
                    .Where(x => !lastMinuteDates.Contains(x))
                    .ToList();


                var targetDate = dateTimePicker.Value.ToString("dd-MM-yyyy");
                var targetDatetime = $"{targetDate} {availableStartingHoursCombobox.SelectedIndex}:00";

                var busDrivers = _distributor.GetBusDrivers();
                var duration = _busLines.Find(x => x.Number == busLineNumberCombobox.SelectedIndex).Duration;

                busDrivers = busDrivers
                    .Select(x => x)
                    .Where(x => !x.IsOnPaidLeave(dateTimePicker.Value.ToString("yyyy-MM-dd")) && 
                                x.IsAvailableOnHour(dateTimePicker.Value.ToString("yyyy-MM-dd"), 
                                                    availableStartingHoursCombobox.SelectedItem.ToString(),
                                                    duration) &&
                                !x.IsLedToOverWorking(duration, dateTimePicker.Value.ToString("yyyy-MM-dd")))
                    .ToList();

                var buses = _distributor.GetBuses();

                buses = buses
                    .Select(x => x)
                    .Where(x => x.IsAvailableOnHour(dateTimePicker.Value.ToString("yyyy-MM-dd"),
                                                    availableStartingHoursCombobox.SelectedItem.ToString(),
                                                    duration))
                    .ToList();

                var startStop = _busLines[busLineNumberCombobox.SelectedIndex].Stops[0];
                var endStop = _busLines[busLineNumberCombobox.SelectedIndex].Stops[_busLines[busLineNumberCombobox.SelectedIndex].Stops.Count - 1];


                var recBusDrivers = busDrivers
                    .Select(x => x)
                    .Where(x => x.IsRecommended(dateTimePicker.Value.ToString("yyyy-MM-dd"), availableStartingHoursCombobox.SelectedItem.ToString(), startStop, endStop, duration))
                    .ToList();


                var recBuses = buses
                    .Select(x => x)
                    .Where(x => x.IsRecommended(dateTimePicker.Value.ToString("yyyy-MM-dd"), availableStartingHoursCombobox.SelectedItem.ToString(), startStop, endStop, duration))
                    .ToList();

                _hour = availableStartingHoursCombobox.SelectedItem.ToString();
                _date = dateTimePicker.Value.ToString("yyyy-MM-dd");

                if (recBusDrivers.Count > 0 && recBuses.Count > 0)
                {
                    var result = MessageBox.Show("Εντοπίσαμε κάποιες προτάσεις για οδηγούς και λεωφορεία. Θα θέλατε να τις δείτε;",
                                                 "Ερώτηση",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _busDrivers = recBusDrivers.OrderBy(x => x.GetAvailableWorkingHours(dateTimePicker.Value.ToString("yyyy-MM-dd"))).ToList();
                        foreach (var busDriver in _busDrivers)
                        {
                            recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                            {
                                $"{busDriver.Name} {busDriver.Surname}",
                                (busDriver.GetAvailableWorkingHours(dateTimePicker.Value.ToString("yyyy-MM-dd"))).ToString("#.##")
                            }));
                        }

                        _buses = recBuses;

                        foreach (var bus in recBuses)
                        {
                            int size = -1;
                            switch (bus.Size)
                            {
                                case Enums.BusSize.SMALL:
                                    size = 2;
                                    break;
                                case Enums.BusSize.MEDIUM:
                                    size = 3;
                                    break;
                                case Enums.BusSize.LARGE:
                                    size = 5;
                                    break;
                            }

                            recommendedBusesListview.Items.Add(new ListViewItem(new string[]
                            {
                                bus.ID.ToString(),
                                size.ToString()
                            }));
                        }

                        return;
                    }
                }

                busDrivers = busDrivers
                    .Select(x => x)
                    .Where(x => x.MeetsRequirements(dateTimePicker.Value.ToString("yyyy-MM-dd"),
                                                      availableStartingHoursCombobox.SelectedItem.ToString(),
                                                      duration))
                    .ToList();

                if (sizeCombobox.SelectedItem != null)
                {
                    BusSize size = BusSize.SMALL;
                    switch (sizeCombobox.SelectedItem.ToString())
                    {
                        case "Μεγάλο":
                            size = BusSize.LARGE;
                            break;
                        case "Μεσαίο":
                            size = BusSize.MEDIUM;
                            break;
                    }

                    buses = buses
                        .Select(x => x)
                        .Where(x => x.MeetsRequirements(dateTimePicker.Value.ToString("yyyy-MM-dd"), availableStartingHoursCombobox.SelectedItem.ToString(), duration) &&
                                    x.Size == size)
                        .ToList();
                }

                _busDrivers = busDrivers.OrderByDescending(x => x.GetAvailableWorkingHours(dateTimePicker.Value.ToString("yyyy-MM-dd"))).ToList();
                foreach (var busDriver in _busDrivers)
                {
                    recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                    {
                                $"{busDriver.Name} {busDriver.Surname}",
                                (busDriver.GetAvailableWorkingHours(dateTimePicker.Value.ToString("yyyy-MM-dd"))).ToString("#.##")
                    }));
                }

                _buses = buses;
                foreach (var bus in buses)
                {
                    int size = -1;
                    switch (bus.Size)
                    {
                        case Enums.BusSize.SMALL:
                            size = 2;
                            break;
                        case Enums.BusSize.MEDIUM:
                            size = 3;
                            break;
                        case Enums.BusSize.LARGE:
                            size = 5;
                            break;
                    }

                    recommendedBusesListview.Items.Add(new ListViewItem(new string[]
                    {
                                bus.ID.ToString(),
                                size.ToString()
                    }));
                }

            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }

        //


        //


        private void BusLineNumberCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            availableStartingHoursCombobox.Items.Clear();

            if (busLineNumberCombobox.SelectedItem != null)
            {
                var busLine = _busLines.Find(x => x.Number == int.Parse(busLineNumberCombobox.SelectedItem.ToString()));

                TimeSpan timeSpan = new TimeSpan(8, 0, 0);
                while (timeSpan.Hours != 23)
                {
                    availableStartingHoursCombobox.Items.Add(timeSpan.ToString("hh':'mm"));
                    timeSpan = timeSpan.Add(new TimeSpan(0, busLine.Duration, 0));
                }
                availableStartingHoursCombobox.Items.Add(timeSpan.ToString("hh':'mm"));
            }
        }

        private void CreateItineraryButton_Click(object sender, EventArgs e)
        {
            if (recommendedBusesListview.CheckedItems.Count == 1 &&
                recommendedDriversListview.CheckedItems.Count == 1)
            {          
                DateTime targetDatetime = DateTime.Parse($"{_date} {_hour}:00");
                string targetDatetimeAsString = DateTime.Parse($"{_date} {_hour}:00").ToString("HH:mm:ss dd-MM-yyyy");

                string busDriverUsername = _busDrivers[recommendedDriversListview.CheckedIndices[0]].Username;
                BusLine busLine = _busLines[_busLineIndex];
                Bus bus = _buses.Find(x => x.ID == int.Parse(recommendedBusesListview.Items[recommendedBusesListview.CheckedIndices[0]].SubItems[0].Text));

                int size = 5;
                switch (bus.Size)
                {
                    case BusSize.SMALL:
                        size = 2;
                        break;
                    case BusSize.MEDIUM:
                        size = 3;
                        break;
                }


                Itinerary itinerary = new Itinerary(_distributor.GetMaxItineraryID(),
                                                    targetDatetime,
                                                    busDriverUsername,
                                                    busLine,
                                                    bus,
                                                    ItineraryStatus.NoDelayed, 
                                                    size);

                _distributor.InsertItineraryInDatabase(itinerary);

                int index = GetReservationIndex(targetDatetime);
                if (index != -1)
                {
                    var clients = _reservations
                        .Select(x => x)
                        .Where(x => x.TravelDatetime == targetDatetime)
                        .OrderBy(x => x.ReservationDatetime)
                        .ToList();

                    var servedClients = clients
                        .Take(size)
                        .ToList();

                    foreach (var servedClient in servedClients)
                    {
                        var client = _distributor.GetClient(servedClient.ReserveringClient);
                        var ticket = new Ticket(itinerary, false, false, client.Username);

                        client.AddToCollection(ticket);
                        client.AutomaticTicketPurchase(_distributor.GetMaxItineraryID());
                        client.InsertTransactionToDatabase(_distributor.GetClientsLastTicketID(client.Username),
                                                           _distributor.GetReservationPrice(client.Username, 
                                                                                            targetDatetime.ToString("yyyy-MM-dd HH:mm:ss"), busLine.Number));

                        _distributor.DeleteReservation(servedClient);
                         _reservations.Remove(servedClient);
                        _dictionary[$"{targetDatetimeAsString}{servedClient.TravelBusLine}"].Remove(servedClient);
                    }

                    FillReservationListview();
                }

                recommendedBusesListview.Items.Clear();
                recommendedDriversListview.Items.Clear();

                MessageBox.Show("Επιτυχής καταχώρηση δρομολογίου.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε οδηγό και λεωφορείο.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public int GetReservationIndex(DateTime targetDatetime)
        {
            for (int i = 0; i < rereservationsListview.Items.Count; i++)
            {
                if (rereservationsListview.Items[i].SubItems[0].Text == targetDatetime.ToString("HH:mm:ss dd-MM-yyyy"))
                {
                    return i;
                }
            }

            return -1;
        }

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

        private void BusLineNumberCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            recommendedBusesListview.Items.Clear();
            recommendedDriversListview.Items.Clear();
        }
    }
}
