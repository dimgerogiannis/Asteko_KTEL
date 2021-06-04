using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class DismissalPetition
    {
        private string _targetUsername;

        public string TargetUserame => _targetUsername;

        public DismissalPetition(string targetUsername)
        {
            _targetUsername = targetUsername;
        }

        public List<ClientComplaint> GetComplaintHistory()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select targetUsername, summary, category, clientUsername 
                         from ClientComplaint
                         where targetUsername = @targetUsername and checked = @checked";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", _targetUsername);
                cmd.Parameters.AddWithValue("@checked", false);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<ClientComplaint> complaints = new List<ClientComplaint>();

                while (reader.Read())
                {
                    ClientComplaintCategory category = ClientComplaintCategory.AggresiveBehaviour;
                    switch (reader.GetString(2))
                    {
                        case "rude_bus_driver":
                            category = ClientComplaintCategory.AggresiveBehaviour;
                            break;
                        case "late_for_no_reason":
                            category = ClientComplaintCategory.LateForNoReason;
                            break;
                        case "aggresive_behavior":
                            category = ClientComplaintCategory.AggresiveBehaviour;
                            break;
                        case "aggresive_driving":
                            category = ClientComplaintCategory.CarelessDriving;
                            break;
                        case "driving_rules_violation":
                            category = ClientComplaintCategory.DrivingRuleViolation;
                            break;
                    }

                    complaints.Add(new ClientComplaint(reader.GetString(0), false, reader.GetString(1), category, reader.GetString(3)));
                }

                return complaints;               
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
    
        public void DeleteDismissalPetition()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from DismissalPetition
                              where targetUsername = @targetUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", _targetUsername);
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
