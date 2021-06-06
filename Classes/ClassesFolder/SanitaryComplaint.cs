using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class SanitaryComplaint : Complaint
    {
        private Client _targetClient;
        private BusDriver _complaintDriver;
        private SanitaryComplaintCategory _category;


        public Client TargetClient;
        public BusDriver ComplaintDriver;
        public string Summary => _summary;
        public SanitaryComplaintCategory Category => _category;

        public SanitaryComplaint(Client targetClient,
                                 BusDriver complaintDriver,
                                 string summary, 
                                 SanitaryComplaintCategory category) : base(summary)
        {
            _targetClient = targetClient;
            _complaintDriver = complaintDriver;
            _category = category;
        }
    }
}
