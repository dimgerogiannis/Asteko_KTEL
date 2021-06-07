using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Employee : User
    {
        protected decimal _salary;
        protected int _experience;
        protected string _hireDate;

        public decimal Salary => _salary;
        public int Experience => _experience;
        public string HireDate => _hireDate;

        public Employee(string username,
                        string name,
                        string surname,
                        Specialization property,
                        decimal salary,
                        int experience,
                        string hireDate) : base(username, name, surname, property)
        {
            _salary = salary;
            _experience = experience;
            _hireDate = hireDate;
        }

    }
}
