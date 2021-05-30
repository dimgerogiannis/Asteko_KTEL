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
        private int _id;
        private string _qualityManagerUsername;
        private string _targetUsername;

        public int ID => _id;
        public string QualityManagerUsername => _qualityManagerUsername;
        public string TargetUserame => _targetUsername;

        public DismissalPetition(int ID, string qualityManagerUsername, string targetUsername)
        {
            _id = ID;
            _qualityManagerUsername = qualityManagerUsername;
            _targetUsername = targetUsername;
        }

        public List<ClientComplaint> GetComplaintHistory()
        {
            using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
            connection.Open();

            var query = @"select targetUsername, summary, category, clientUsername 
                         from ClientComplaint
                         where targetUsername = @targetUsername;";

            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@targetUsername", _targetUsername);
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

                complaints.Add(new ClientComplaint(reader.GetString(0), reader.GetString(1), category, reader.GetString(3)));
            }

            return complaints;
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
