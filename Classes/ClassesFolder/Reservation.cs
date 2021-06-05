using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class Reservation
    {
        private string _reservingClient;
        private DateTime _reservationDatetime;
        private DateTime _travelDatetime;
        private int _travelBusLine;

        public string ReserveringClient => _reservingClient;
        public DateTime ReservationDatetime => _reservationDatetime;
        public DateTime TravelDatetime => _travelDatetime;
        public int ResBusLine => _travelBusLine;

        public Reservation(string reservingClient, 
                           DateTime reservationDatetime, 
                           DateTime travelDatetime, 
                           int travelBusLine)
        {
            _reservingClient = reservingClient;
            _reservationDatetime = reservationDatetime;
            _travelDatetime = travelDatetime;
            _travelBusLine = travelBusLine;
        }
    }
}
