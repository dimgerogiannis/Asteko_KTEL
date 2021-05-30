using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class BusLine
    {
        private readonly int _number;
        private readonly int _duration;
        private readonly List<string> _stops;

        public int Number => _number;
        public int Duration => _duration;
        public List<string> Stops => _stops;

        public BusLine(int number, int duration, List<string> stops)
        {
            _number = number;
            _duration = duration;
            _stops = stops;
        }
    }
}
