﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassesFolder
{
    public class BusLine
    {
        private readonly int _number;
        private readonly int _duration;
        private List<string> _stops;

        public int Number => _number;
        public int Duration => _duration;
        public List<string> Stops => _stops;

        public BusLine(int number,
                       int duration,
                       List<string> stops)
        {
            _number = number;
            _duration = duration;
            _stops = stops;
        }

        public List<string> GetAvailableStartingHours()
        {
            List<string> hours = new List<string>();
            TimeSpan time = new TimeSpan(8, 0, 0);
            while (time.Hours != 23)
            {
                hours.Add(time.ToString("hh':'mm"));
                time = time.Add(new TimeSpan(0, _duration, 0));
            }

            hours.Add(time.ToString("hh':'mm"));

            return hours;
        }

        public List<string> GetFirstAndLastStop()
        {
            return new List<string>()
            {
                _stops[0],
                _stops[_stops.Count - 1]
            };
        }

        public void InsertBusLineInDatabase()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"insert into BusLine values (@number, @duration);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", _number);
                cmd.Parameters.AddWithValue("@duration", _duration);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void InsertBusStopsInDatabase()
        {
            try
            {
                foreach (var stop in _stops)
                {
                    using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                    connection.Open();

                    var query = @"insert into Stop (number, stopName) values (@number, @stopName);";
                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@number", _number);
                    cmd.Parameters.AddWithValue("@stopName", stop);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void UpdateStops(List<string> stops)
        {
            var oldStops = _stops.ToList();
            _stops = stops;

            foreach (var oldStop in oldStops)
            {
                DeleteStopFromBusLine(oldStop);
            }

            foreach (var stop in _stops)
            {
                InsertNewStopInDatabase(stop);
            }
        }

        private void InsertNewStopInDatabase(string stop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"insert into Stop (number, stopName) values (@number, @stopName);";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", _number);
                cmd.Parameters.AddWithValue("@stopName", stop);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void DeleteStopFromBusLine(string stop)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from Stop where number = @number and stopName = @stopName;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@number", _number);
                cmd.Parameters.AddWithValue("@stopName", stop);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
