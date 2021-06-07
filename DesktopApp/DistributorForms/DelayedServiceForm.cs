using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace DistributorForms
{
    public partial class DelayedServiceForm : Form
    {
        private ItineraryDistributionManager _distributor;
        private List<LastMinuteTravelRequest> _requests;
        private List<Client> _clients;

        private List<Bus> _buses;
        private List<BusDriver> _busDrivers;
        private List<BusLine> _busLines;

        private int _selectedRequestIndex;
        private int _selectedBusLine;
        private string _selectedTravelDatetime;

        public DelayedServiceForm(ItineraryDistributionManager distributor)
        {
            _distributor = distributor;
            InitializeComponent();
        }

        private void DelayedServiceForm_Load(object sender, EventArgs e)
        {
            _requests = _distributor
                .GetLastMinuteTravelRequests()
                .OrderBy(x=> x.TravelDatetime)
                .OrderBy(y => y.TravelBusLine.Number)
                .OrderBy(y => y.ApplicationDate)
                .ToList();

            _busLines = _distributor.GetBusLines();

            _clients = new List<Client>();
            foreach (var request in _requests)
                _clients.Add(_distributor.GetClient(request.ApplicantClient.Username));

            DisplayLastMinuteTravelRequests();
        }

        private void DisplayLastMinuteTravelRequests()
        {
            lastMinuteListview.Items.Clear();
            foreach (var request in _requests)
            {
                lastMinuteListview.Items.Add(new ListViewItem(new string[]
                {
                    request.ApplicationDate,
                    request.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                    request.TravelBusLine.Number.ToString(),
                    _clients.Find(x => x.Username == request.ApplicantClient.Username).GetFullName()
                }));
            }
        }

        private void ProgrammingButton_Click(object sender, EventArgs e)
        {
            if (lastMinuteListview.CheckedItems.Count != 1)
            {
                MessageBox.Show("Παρακαλώ επιλέξτε ένα μόνο αίτημα καθυστερημένης εξυπηρέτησης.",
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            recommendedBusesListview.Items.Clear();
            recommendedDriversListview.Items.Clear();

            _busDrivers = _distributor.GetBusDrivers();
            _buses = _distributor.GetBuses();

            var selectedListviewItem = lastMinuteListview.CheckedItems[0];
            var selectedClient = _distributor.GetClient(_clients[lastMinuteListview.CheckedIndices[0]].Username);

            _selectedRequestIndex = lastMinuteListview.CheckedIndices[0];
            _selectedBusLine = int.Parse(selectedListviewItem.SubItems[2].Text);

            if (selectedClient.CanAffordCost(selectedClient.FindStandardTicketPrice()))
            {
                var result = MessageBox.Show($"Αποδέχεστε το αίτημα καθυστερημένης εξυπηρέτησης για τον πελάτη {selectedClient.GetFullName()};",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _selectedTravelDatetime = DateTime.Parse(selectedListviewItem.SubItems[1].Text).ToString("yyyy-MM-dd HH:mm:ss");
                    var date = selectedListviewItem.SubItems[1].Text.Split(" ")[1];
                    var time = selectedListviewItem.SubItems[1].Text.Split(" ")[0];
                    time = time.Substring(0, time.LastIndexOf(":"));
                    FindAvailableBusDriversAndBuses(_selectedBusLine, date, time);
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Ο πελάτης δεν έχει επαρκές υπόλοιπο στον λογαριασμό του για την αγορά του εισιτηρίου, παρακαλώ επιλέξτε κάποιο άλλο αίτημα.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        public void FindAvailableBusDriversAndBuses(int reqLine, string reqDate, string startingHour)
        {
            // reqDate = dd-MM-yyyy
            var selectedListviewItem = lastMinuteListview.Items[lastMinuteListview.CheckedIndices[0]];

            var databaseDateFormat = DateTime.Parse(reqDate).ToString("yyyy-MM-dd");

            _busDrivers = _distributor.GetBusDrivers();
            var duration = _busLines.Find(x => x.Number == int.Parse(selectedListviewItem.SubItems[2].Text)).Duration;

            _busDrivers = _busDrivers
                    .Select(x => x)
                    .Where(x => !x.IsOnPaidLeave(databaseDateFormat) && x.IsAvailableOnHour(databaseDateFormat, startingHour, duration) && !x.IsLedToOverWorking(duration, databaseDateFormat))
                    .ToList();

            _buses = _buses
                .Select(x => x)
                .Where(x => x.IsAvailableOnHour(databaseDateFormat, startingHour, duration))
                .ToList();

            var firstAndLastStop = _busLines[reqLine].GetFirstAndLastStop();

            var startStop = firstAndLastStop[0];
            var endStop = firstAndLastStop[1];

            var recBusDrivers = _busDrivers
                    .Select(x => x)
                    .Where(x => x.IsRecommended(databaseDateFormat, startingHour, startStop, endStop, duration))
                    .ToList();

            var recBuses = _buses
                .Select(x => x)
                .Where(x => x.IsRecommended(databaseDateFormat, startingHour, startStop, endStop, duration))
                .ToList();


            if (recBusDrivers.Count > 0 && recBuses.Count > 0)
            {
                var result = MessageBox.Show("Εντοπίσαμε κάποιες προτάσεις για οδηγούς και λεωφορεία. Θα θέλατε να τις δείτε;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _busDrivers = recBusDrivers
                        .OrderByDescending(x => x.GetAvailableWorkingHours(databaseDateFormat))
                        .ToList();

                    foreach (var busDriver in _busDrivers)
                    {
                        recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                        {
                            $"{busDriver.Name} {busDriver.Surname}",
                            (busDriver.GetAvailableWorkingHours(databaseDateFormat)).ToString("#.##")
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

            _busDrivers = _busDrivers
                .Select(x => x)
                .Where(x => x.MeetsRequirements(databaseDateFormat, startingHour, duration))
                .ToList();         

            _busDrivers = _busDrivers
                .OrderBy(x => x.GetAvailableWorkingHours(databaseDateFormat))
                .ToList();

            foreach (var busDriver in _busDrivers)
            {
                recommendedDriversListview.Items.Add(new ListViewItem(new string[]
                {
                    $"{busDriver.Name} {busDriver.Surname}",
                    (busDriver.GetAvailableWorkingHours(databaseDateFormat)).ToString("#.##")
                }));
            }

            foreach (var bus in _buses)
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

        public List<LastMinuteTravelRequest> GetMatchingLastMinuteTravelRequests()
        {
            return _requests
                .Select(x => x)
                .Where(x => x.TravelBusLine.Number == _selectedBusLine && x.TravelDatetime == DateTime.Parse(_selectedTravelDatetime))
                .ToList();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (recommendedBusesListview.CheckedItems.Count == 1 &&
                recommendedDriversListview.CheckedItems.Count == 1)
            {
                int availableSeats = int.Parse(recommendedBusesListview.Items[recommendedBusesListview.CheckedIndices[0]].SubItems[1].Text);

                Itinerary itinerary = new Itinerary(_distributor.FindMaxItineraryID() + 1,
                                                    DateTime.Parse(_selectedTravelDatetime),
                                                    _busDrivers[recommendedDriversListview.CheckedIndices[0]],
                                                    _busLines[_selectedBusLine],
                                                    _buses.Find(x => x.ID == int.Parse(recommendedBusesListview.Items[recommendedBusesListview.CheckedIndices[0]].SubItems[0].Text)),
                                                    ItineraryStatus.NoDelayed,
                                                    availableSeats);

                _distributor.InsertItineraryInDatabase(itinerary);

                var client = _distributor.GetClient(_requests[_selectedRequestIndex].ApplicantClient.Username);

                Ticket ticket = new Ticket(itinerary, 
                                           false, 
                                           false);

                client.AddToCollection(ticket);
                client.AutomaticTicketPurchase(itinerary);
                client.InsertTransactionToDatabase(_distributor.GetClientsLastTicketID(client.Username), 
                                                   client.FindStandardTicketPrice());
                itinerary.DecrementItinerarySeats();
                
                client.DeleteLastMinuteTravelRequest(_requests[_selectedRequestIndex]);
                _requests.RemoveAt(_selectedRequestIndex);
                int counter = 1;

                var requests = _requests
                    .Select(x => x)
                    .Where(x => x.TravelBusLine.Number == _selectedBusLine && x.TravelDatetime == DateTime.Parse(_selectedTravelDatetime))
                    .Take(--availableSeats)
                    .ToList();

                foreach (var request in requests)
                {
                    client = request.ApplicantClient;

                    ticket = new Ticket(itinerary, 
                                        false, 
                                        false);

                    client.AddToCollection(ticket);
                    client.AutomaticTicketPurchase(itinerary);
                    client.InsertTransactionToDatabase(_distributor.GetClientsLastTicketID(client.Username), 
                                                       client.FindStandardTicketPrice());
                    itinerary.DecrementItinerarySeats();
                    client.DeleteLastMinuteTravelRequest(request);
                    _requests.Remove(request);
                    counter++;
                }

                recommendedBusesListview.Items.Clear();
                recommendedDriversListview.Items.Clear();
                DisplayLastMinuteTravelRequests();

                MessageBox.Show($"Επιτυχής καταχώρηση δρομολογιού και εξυπηρέτηση {counter} αιτήσεων καθυστερημένης εξυπηρέτησης.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε κάποιον οδηγό και κάποιο λεωφορείο για να δημιουργήσετε ένα δρομολόγιο.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
