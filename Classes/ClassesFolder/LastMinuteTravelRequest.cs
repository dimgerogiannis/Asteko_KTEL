using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassesFolder.Enums;

namespace ClassesFolder
{

    public class LastMinuteTravelRequest
    {
        private Client _applicantClient;
        private string _applicationDate;
        private DateTime _wantedDatetime;
        private BusLine _wantedBusLine;
        private Status _status;

        public Client ApplicantClient => _applicantClient;
        public string ApplicationDate => _applicationDate;
        public DateTime TravelDatetime => _wantedDatetime;
        public BusLine TravelBusLine => _wantedBusLine;
        public Status Status => _status;

        public LastMinuteTravelRequest(Client applicantClient, 
                                       string applicationDate, 
                                       DateTime travelDatetime, 
                                       BusLine travelBusLine, 
                                       Status status)
        {
            _applicantClient = applicantClient;
            _applicationDate = applicationDate;
            _wantedDatetime = travelDatetime;
            _wantedBusLine = travelBusLine;
            _status = status;
        }
    }
}
