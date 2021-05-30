using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class Complaint
    {
        protected string _targetUsername;
        protected string _summary;

        public Complaint(string targetUsername, string summary)
        {
            _targetUsername = targetUsername;
            _summary = summary;
        }
    }
}
