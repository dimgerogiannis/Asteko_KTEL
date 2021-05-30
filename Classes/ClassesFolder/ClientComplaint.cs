using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class ClientComplaint : Complaint
    {
        private ClientComplaintCategory _category;
        private string _clientUsername;

        public string TargetUsername => _targetUsername;
        public string Summary => _summary;

        public ClientComplaintCategory Category => _category;
        public string ClientUsername => _clientUsername;

        public ClientComplaint(string targetUsername, string summary, ClientComplaintCategory category, string clientUsername) : base(targetUsername, summary)
        {
            _category = category;
            _clientUsername = clientUsername;
        }

        public void DeleteClientComplaint()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from ClientComplaint 
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