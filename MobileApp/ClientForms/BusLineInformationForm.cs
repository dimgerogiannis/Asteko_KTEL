using MySql.Data.MySqlClient;
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
using System.Diagnostics;

namespace Project.ClientForms
{
    public partial class BusLineInformationForm : Form
    {
        private List<BusLine> _busLines;
        public BusLineInformationForm()
        {
            InitializeComponent();
        }

        private void BusLineInformationForm_Load(object sender, EventArgs e)
        {
            _busLines = new List<BusLine>();
            GetBusLinesInfo();
            busLineListComboBox.Items.AddRange(_busLines.Select(x => x.Number.ToString()).ToArray());
        }

        private void GetBusLinesInfo()
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"select number, duration
                          from BusLine;";
            using var cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                _busLines.Add(new BusLine(reader.GetInt32(0), reader.GetInt32(1), GetBusLineStops(2)));
            }
        }

        private List<string> GetBusLineStops(int number)
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"select stopName 
                          from stop 
                          where number = @number;";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@number", number);
            using MySqlDataReader reader = cmd.ExecuteReader();

            List<string> stops = new List<string>();

            while (reader.Read())
            {
                stops.Add(reader.GetString(0));
            }

            return stops;
        }

        private void BusLineListComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (busLineListComboBox.SelectedItem != null)
            {
                var line = _busLines.Find(x => x.Number == int.Parse(busLineListComboBox.SelectedItem.ToString()));
                durationLabel.Text = $"Διάρκεια γραμμής: {line.Duration} λεπτά";
                busLineStopsListview.Items.Clear();
                busLineAvailableItineraryTimeListview.Items.Clear();

                foreach (var name in line.Stops)
                    busLineStopsListview.Items.Add(new ListViewItem(name));

                var timeSpan = new TimeSpan(8, 0, 0);
                
                while (timeSpan.Hours != 23)
                {
                    busLineAvailableItineraryTimeListview.Items.Add(new ListViewItem(timeSpan.ToString("hh':'mm")));
                    timeSpan = timeSpan.Add(new TimeSpan(0, _busLines[busLineListComboBox.SelectedIndex].Duration, 0));
                }

                busLineAvailableItineraryTimeListview.Items.Add(new ListViewItem(timeSpan.ToString("hh':'mm")));
            }
        }
    }
}
