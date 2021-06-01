using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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

        public string GetFullName()
        {
            return $"{_name} {_surname}";
        }

        public List<Feedback> GetFeedbacks()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select feedbackText
                          from Feedback;";

                using var cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();

                List<Feedback> feedbacks = new List<Feedback>();

                while (reader.Read())
                {
                    feedbacks.Add(new Feedback(reader.GetString(0)));
                }

                return feedbacks;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }
    
        public void DeleteFeedback(Feedback feedback)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from Feedback
                          where feedbackText = @feedbackText;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@feedbackText", feedback.FeedbackText);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Προκλήθηκε σφάλμα κατά την σύνδεση με τον server. Η εφαρμογή θα τερματιστεί!",
                                 "Σφάλμα",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    
    }
}
