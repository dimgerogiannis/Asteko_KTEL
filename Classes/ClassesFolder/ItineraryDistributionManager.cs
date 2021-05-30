using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFolder
{
    public class ItineraryDistributionManager : Employee
    {
        private bool _isResponsibleForWeek;
        public bool IsResponsibleForWeek => _isResponsibleForWeek;

        public ItineraryDistributionManager(string username, 
                                            string name, 
                                            string surname, 
                                            string property, 
                                            decimal salary, 
                                            int experience, 
                                            string hireDate,
                                            bool isResponsibleForWeek) : base(username, name, surname, property, salary, experience, hireDate)
        {
            _isResponsibleForWeek = isResponsibleForWeek;
        }
    }
}
