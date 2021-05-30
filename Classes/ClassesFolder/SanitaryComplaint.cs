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
        private SanitaryComplaintCategory _category;
        private string _busDriverUsername;

        public string TargetUsername => _targetUsername;
        public string Summary => _summary;

        public SanitaryComplaintCategory Category => _category;
        public string BusDriverUsername => _busDriverUsername;

        public SanitaryComplaint(string targetUsername, string summary, SanitaryComplaintCategory category, string busDriverUsername) : base(targetUsername, summary)
        {
            _category = category;
            _busDriverUsername = busDriverUsername;
        }
    }
}
