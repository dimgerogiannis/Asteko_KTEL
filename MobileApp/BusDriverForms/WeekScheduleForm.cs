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
    public partial class WeekScheduleForm : Form
    {
        private BusDriver _busDriver;

        public WeekScheduleForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void WeekScheduleForm_Load(object sender, EventArgs e)
        {
            var itineraries = _busDriver.GetCurrentWeekItineraries();

            foreach (var itinerary in itineraries.OrderBy(x => x.TravelDatetime))
            {
                scheduleListview.Items.Add(new ListViewItem(new string[]
                {
                    itinerary.TravelDatetime.ToString("HH:mm:ss dd-MM-yyyy"),
                    itinerary.ItineraryLine.Number.ToString(),
                    itinerary.ItineraryLine.Duration.ToString(),
                    itinerary.ResponsibleBus.Id.ToString()
                }));
            }
        }
    }
}
