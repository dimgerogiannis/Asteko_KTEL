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
    public partial class MonetaryStatsForm : Form
    {
        private Chief _chief;

        public MonetaryStatsForm(Chief chief)
        {
            _chief = chief;
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value < endDateTimePicker.Value)
            {
                var transactions = _chief.GetTransactions(startDateTimePicker.Value.ToString("yyyy-MM-dd"), endDateTimePicker.Value.ToString("yyyy-MM-dd"));
                var employees = _chief.GetEmployees();

                var workMonths = 0;
                var salarySum = 0m;
                foreach (var employee in employees)
                {
                    var time = DateTime.Parse(employee.HireDate) < startDateTimePicker.Value ? startDateTimePicker.Value : DateTime.Parse(employee.HireDate);
                    workMonths = DateDifferenceInMonth(time, DateTime.Now);
                    salarySum += CalculateCosts(employee.Salary, workMonths);
                }

                Dictionary<Employee, List<string>> clientMontlyCards = new Dictionary<Employee, List<string>>();


                var transactionsIncome = 0m;
                foreach (var transaction in transactions)
                {
                    transactionsIncome += transaction.Price;
                }

                ticketIncomeLabel.Text = $"Έσοδα εισητηρίων: {transactionsIncome} Ευρώ";
                salaryExpensesLabel.Text = $"Μισθολογικά έξοδα: {salarySum} Ευρώ";
                profitLabel.Text = $"Κέρδη: {CalculateProfits(transactionsIncome, salarySum)} Ευρώ";
            }
            else
            {
                MessageBox.Show("Παρακαλώ εισάγετε σωστές ημερομηνίες.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private int DateDifferenceInMonth(DateTime start, DateTime end)
        {
            DateTime newStart = new DateTime(start.Year, start.Month, 1);
            DateTime newEnd = new DateTime(end.Year, end.Month, 1);
            int counter = 1;
            while (newStart < newEnd)
            {
                newStart = newStart.AddMonths(1);
                counter++;
            }

            return counter;
        }
    
        private decimal CalculateCosts(decimal salary, int duration)
        {
            return salary * duration;
        }

        private decimal CalculateProfits(decimal earnings, decimal costs)
        {
            return earnings - costs;
        }
    }
}
