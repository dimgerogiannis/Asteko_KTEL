using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class DiscountApplication
    {
        private string _applicantUsername;
#nullable enable
        private DateTime? _applicationDatetime;
        private string? _possibleRejectionReason;
#nullable enable
        private Category _category;
        private string _taxIdentificationNumber;
        private string _phoneNumber;
        private Status _status;
        private List<File>? _files;

        public string ApplicantUsername => _applicantUsername;

        public DateTime? ApplicationDatetime => _applicationDatetime;
        public string? PossibleRejectionReason => _possibleRejectionReason;

        public Category Category => _category;
        public string TaxIdentificationNumber => _taxIdentificationNumber;
        public string PhoneNumber => _phoneNumber;
        public Status Status => _status;
#nullable enable
        public List<File>? Files => _files;

        public DiscountApplication(string applicantUsername, DateTime? applicationDatetime, string? possibleRejectionReason ,Category category, string taxIdentificationNumber, string phoneNumber, Status status, List<File>? files)
        {
            _applicantUsername = applicantUsername;
            _applicationDatetime = applicationDatetime;
            _possibleRejectionReason = possibleRejectionReason;
            _category = category;
            _taxIdentificationNumber = taxIdentificationNumber;
            _phoneNumber = phoneNumber;
            _status = status;
            _files = files;
        }

        public void SetAsAccepted()
        {
            _status = Status.Accepted;

            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update discountapplication
                          set status = @status
                          where clientUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@status", _status);
                cmd.Parameters.AddWithValue("@username", ApplicantUsername);
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

        public void SetAsRejected(string reason)
        {
            _status = Status.Rejected;
            _possibleRejectionReason = reason;
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update discountapplication
                          set status = @status, possibleRejectionReason = @reason
                          where clientUsername = @username;";

                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@status", _status);
                cmd.Parameters.AddWithValue("@username", ApplicantUsername);
                cmd.Parameters.AddWithValue("@reason", _possibleRejectionReason);
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
