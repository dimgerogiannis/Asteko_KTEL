using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class DisciplinaryComment
    {
        private DateTime _datetime;
        private string _summary;
        private string _target;

        public DateTime Datetime => _datetime;
        public string Target => _target;
        public string Summary => _summary;

        public DisciplinaryComment(string targetUsername, 
                                   string summary, 
                                   DateTime datetime)
        {
            _datetime = datetime;
            _summary = summary;
            _target = targetUsername;
        }
    }
}
