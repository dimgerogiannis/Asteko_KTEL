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
        private string _comment;
        private BusDriver _targetDriver;


        public DateTime Datetime => _datetime;
        public string Comment => _comment;
        public BusDriver TargetDriver => _targetDriver;

        public DisciplinaryComment(BusDriver targetDriver, 
                                   string summary, 
                                   DateTime datetime)
        {
            _targetDriver = targetDriver;
            _datetime = datetime;
            _comment = summary;
        }
    }
}
