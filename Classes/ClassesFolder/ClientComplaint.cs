using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class ClientComplaint : Complaint
    {
        private BusDriver _targetDriver;
        private Client _complaintClient;

        private ClientComplaintCategory _category;
        private bool _checked;


        public BusDriver TargetDriver => _targetDriver;
        public Client ComplaintClient => _complaintClient;

        public string Summary => _summary;
        public ClientComplaintCategory Category => _category;
        public bool Checked => _checked;

        public ClientComplaint(BusDriver targetDriver,
                               Client complaintClient,
                               bool gotChecked, 
                               string summary, 
                               ClientComplaintCategory category) : base(summary)
        {
            _targetDriver = targetDriver;
            _complaintClient = complaintClient;
            _category = category;
            _checked = false;
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
    
        public void SetAsChecked()
        {
            try
            {
                _checked = true;
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"update ClientComplaint 
                          set checked = @checked
                          where targetUsername = @targetUsername and clientUsername = @clientUsername;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", _targetDriver.Username);
                cmd.Parameters.AddWithValue("@checked", _checked);
                cmd.Parameters.AddWithValue("@clientUsername", _complaintClient.Username);
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