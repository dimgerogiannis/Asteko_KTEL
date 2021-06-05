using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public enum Status
    {
        Pending,
        Accepted,
        Rejected
    };

    public class LastMinuteTravelRequest
    {
        private string _clientUsername;
        private string _applicationDate;
        private DateTime _travelDatetime;
        private int _travelBusLine;
        private Status _status;

        public string ClientUsername => _clientUsername;
        public string ApplicationDate => _applicationDate;
        public DateTime TravelDatetime => _travelDatetime;
        public int TravelBusLine => _travelBusLine;
        public Status Status => _status;

        public LastMinuteTravelRequest(string clientUsername, 
                                       string applicationDate, 
                                       DateTime travelDatetime, 
                                       int travelBusLine, 
                                       Status status)
        {
            _clientUsername = clientUsername;
            _applicationDate = applicationDate;
            _travelDatetime = travelDatetime;
            _travelBusLine = travelBusLine;
            _status = status;
        }
    }
}
