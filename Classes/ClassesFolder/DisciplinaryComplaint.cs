using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class DisciplinaryComplaint : Complaint
    {
        private DateTime _datetime;
        public DateTime Datetime => _datetime;

        public string TargetUsername => _targetUsername;
        public string Summary => _summary;

        public DisciplinaryComplaint(string targetUsername, string summary, DateTime datetime) : base(targetUsername, summary)
        {
            _datetime = datetime;
        }
    }
}
