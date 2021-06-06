using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class Reservation
    {
        private Client _reservingClient;
        private DateTime _reservationDatetime;
        private DateTime _travelDatetime;
        private BusLine _travelBusLine;
        private decimal _chargedPrice;

        public Client ReserveringClient => _reservingClient;
        public DateTime ReservationDatetime => _reservationDatetime;
        public DateTime TravelDatetime => _travelDatetime;
        public BusLine TravelBusLine => _travelBusLine;
        public decimal ChargedPrice => _chargedPrice;

        public Reservation(Client reservingClient, 
                           DateTime reservationDatetime, 
                           DateTime travelDatetime, 
                           BusLine travelBusLine,
                           decimal chargedPrice)
        {
            _reservingClient = reservingClient;
            _reservationDatetime = reservationDatetime;
            _travelDatetime = travelDatetime;
            _travelBusLine = travelBusLine;
            _chargedPrice = chargedPrice;
        }
    }
}
