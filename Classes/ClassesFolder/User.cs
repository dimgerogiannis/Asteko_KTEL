using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class User
    {
        protected string _username;
        protected string _name;
        protected string _surname;
        protected string _property;

        public User(string username, string name, string surname, string property)
        {
            _username = username;
            _name = name;
            _surname = surname;
            _property = property;
        }
    }
}
