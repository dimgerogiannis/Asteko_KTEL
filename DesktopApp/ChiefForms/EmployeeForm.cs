using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChiefForms
{
    public partial class EmployeeForm : Form
    {
        private Chief _chief;

        public EmployeeForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            var prop = "";
            foreach (var employee in _chief.GetEmployees())
            {
                switch (employee.Specialization)
                {
                    case Enums.Specialization.BusDriver:
                        prop = "Οδηγώς λεωφορείων";
                        break;
                    case Enums.Specialization.QualityManager:
                        prop = "Υπ. διασφάλισης υπηρεσιών";
                        break;
                    case Enums.Specialization.Distributor:
                        prop = "Υπ. κατανομής δρομολογίων";
                        break;
                    default:
                        prop = "Προϋστάμενος";
                        break;
                }

                employeesListview.Items.Add(new ListViewItem(new string[]
                {
                    employee.Name,
                    employee.Surname,
                    prop,
                    $"{employee.Salary} Ευρώ",
                    $"{employee.Experience} έτη",
                    DateTime.Parse(employee.HireDate).ToString("dd-MM-yyyy")
                }));
            }
        }
    }
}
