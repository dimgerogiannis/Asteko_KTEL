using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFolder
{
    public class QualityManager : Employee
    {

        public QualityManager(string username, 
                              string name, 
                              string surname, 
                              string property, 
                              decimal salary, 
                              int experience, 
                              string hireDate) : base(username, name, surname, property, salary, experience, hireDate)
        {

        }

        public string GetFullName()
        {
            return $"{_name} {_surname}";
        }
    }
}
