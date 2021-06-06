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
        private BusDriver _targetDriver;

        public BusDriver TargetDriver => _targetDriver;

        public DismissalPetition(BusDriver targetDriver)
        {
            _targetDriver = targetDriver;
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
                cmd.Parameters.AddWithValue("@targetUsername", _targetDriver.Username);
                cmd.Parameters.AddWithValue("@checked", false);

                using MySqlDataReader reader = cmd.ExecuteReader();

                List<ClientComplaint> complaints = new List<ClientComplaint>();

                while (reader.Read())
                {
                    complaints.Add(new ClientComplaint(Functions.GetBusDriverByUsername(reader.GetString(0)),
                                                       Functions.GetClientByUsername(reader.GetString(3)),
                                                       false, 
                                                       reader.GetString(1),
                                                       Enums.ClientComplaintCategoryFromDatabaseToEnumEquivalant(reader.GetString(2))));
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
                cmd.Parameters.AddWithValue("@targetUsername", _targetDriver.Username);
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
