﻿using ClassesFolder;
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
            _reservations = _distributor
                .GetReservations()
                .OrderBy(x => x.TravelBusLine.Number)
                .ThenBy(x => x.ReservationDatetime)
                .ToList();

            foreach (var reservation in _reservations)
            {
                var key = $"{reservation.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy")}{reservation.TravelBusLine.Number}";
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

            if (rereservationsListview.Items.Count == 0)
                exitButton.Enabled = true;
            else
                exitButton.Enabled = false;
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
                    item[0].TravelBusLine.Number.ToString(),
                    _dictionary[key].Count.ToString()
                }));
            }

            if (rereservationsListview.Items.Count == 0)
                exitButton.Enabled = true;
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
                var duration = _busLines.Find(x => x.Number == int.Parse(busLineNumberCombobox.SelectedItem.ToString())).Duration;
                
                _hour = availableStartingHoursCombobox.SelectedItem.ToString();
                _date = dateTimePicker.Value.ToString("yyyy-MM-dd");

                busDrivers = busDrivers
                    .Select(x => x)
                    .Where(x => !x.IsOnPaidLeave(_date) && 
                                x.IsAvailableOnHour(_date, 
                                                    _hour,
                                                    duration) &&
                                !x.IsLedToOverWorking(duration, _date))
                    .ToList();

                var buses = _distributor.GetBuses();

                buses = buses
                    .Select(x => x)
                    .Where(x => x.IsAvailableOnHour(_date,
                                                    _hour,
                                                    duration))
                    .ToList();

                var firstAndLastStop = _busLines[busLineNumberCombobox.SelectedIndex].GetFirstAndLastStop();

                var startStop = firstAndLastStop[0];
                var endStop = firstAndLastStop[1];

                var recBusDrivers = busDrivers
                    .Select(x => x)
                    .Where(x => x.IsRecommended(_date, _hour, startStop, endStop, duration))
                    .ToList();


                var recBuses = buses
                    .Select(x => x)
                    .Where(x => x.IsRecommended(_date, _hour, startStop, endStop, duration))
                    .ToList();


                if (recBusDrivers.Count > 0 && recBuses.Count > 0)
                {
                    var result = MessageBox.Show("Εντοπίσαμε κάποιες προτάσεις για οδηγούς και λεωφορεία. Θα θέλατε να τις δείτε;",
                                                 "Ερώτηση",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _busDrivers = recBusDrivers.OrderBy(x => x.GetAvailableWorkingHours(_date)).ToList();
                        foreach (var busDriver in _busDrivers)
                        {
                            recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                            {
                                $"{busDriver.Name} {busDriver.Surname}",
                                (busDriver.GetAvailableWorkingHours(_date)).ToString("#.##")
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
                    .Where(x => x.MeetsRequirements(_date,
                                                    _hour,
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
                        .Where(x => x.MeetsRequirements(_date, _hour, duration) &&
                                    x.Size == size)
                        .ToList();
                }

                _busDrivers = busDrivers
                    .OrderByDescending(x => x.GetAvailableWorkingHours(_date))
                    .ToList();
                foreach (var busDriver in _busDrivers)
                {
                    recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                    {
                                $"{busDriver.Name} {busDriver.Surname}",
                                (busDriver.GetAvailableWorkingHours(_date)).ToString("#.##")
                    }));
                }

                _buses = buses;
                foreach (var bus in buses)
                {
                    int size = -1;
                    switch (bus.Size)
                    {
                        case BusSize.SMALL:
                            size = 2;
                            break;
                        case BusSize.MEDIUM:
                            size = 3;
                            break;
                        case BusSize.LARGE:
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

        private void BusLineNumberCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            availableStartingHoursCombobox.Items.Clear();

            if (busLineNumberCombobox.SelectedItem != null)
            {
                var busLine = _busLines.Find(x => x.Number == int.Parse(busLineNumberCombobox.SelectedItem.ToString()));

                foreach (var hour in busLine.GetAvailableStartingHours())
                {
                    availableStartingHoursCombobox.Items.Add(hour);
                }
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

                Itinerary itinerary = new Itinerary(_distributor.GetMaxItineraryID() + 1,
                                                    targetDatetime,
                                                    Functions.GetBusDriverByUsername(busDriverUsername),
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
                        .Take(itinerary.GetMaxSeats())
                        .ToList();

                    foreach (var servedClient in servedClients)
                    {
                        var client = servedClient.ReservingClient;
                        var ticket = new Ticket(itinerary, false, false);

                        client.AddToCollection(ticket);
                        client.AutomaticTicketPurchase(itinerary);
                        client.InsertTransactionToDatabase(client.GetLastTicketID(),
                                                           servedClient.ChargedPrice);
                        itinerary.DecreaseAvailableSeats();


                        _distributor.DeleteReservation(servedClient);
                         _reservations.Remove(servedClient);
                        _dictionary[$"{targetDatetimeAsString}{servedClient.TravelBusLine.Number}"].Remove(servedClient);
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
        private void BusLineNumberCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            recommendedBusesListview.Items.Clear();
            recommendedDriversListview.Items.Clear();
        }

        /// <summary>
        /// Method that finds the index of the first reservation from the listview, that corresponds to the selected datetime and busline
        /// </summary>
        /// <param name="targetDatetime">The datetime of the reservation</param>
        /// <returns>An integer index</returns>
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

        /// <summary>
        /// Returns the the remaining dates of the current week starting from tomorrow
        /// </summary>
        /// <returns>A List of string dates</returns>
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
        /// Returns the remaining dates of the current and the next week starting from tomorrow
        /// </summary>
        /// <returns>A List of string dates</returns>
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
