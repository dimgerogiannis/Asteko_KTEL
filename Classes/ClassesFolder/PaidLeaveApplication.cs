using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassesFolder
{
    public class PaidLeaveApplication
    {
        private string _applicantDriver;
        private string _applicationDatetime;
        private string _reason;
        private string _rejectionReason;
        private string _wantedDatetime;
        private Status _status;

        public string ApplicantDriver => _applicantDriver;
        public string ApplicationDatetime => _applicationDatetime; 
        public string Reason => _reason;
        public string RejectionReason
        {
            get { return _rejectionReason; }
            set { _rejectionReason = value; }
        }
        public string WantedDatetime => _wantedDatetime;
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public PaidLeaveApplication(string applicantDriver, 
                                    string applicationDatetime, 
                                    string reason,
                                    string rejectionReason,
                                    string wantedDatetime, 
                                    Status status)
        {
            _applicantDriver = applicantDriver;
            _applicationDatetime = applicationDatetime;
            _reason = reason;
            _rejectionReason = rejectionReason;
            _wantedDatetime = wantedDatetime;
            _status = status;
        }

        public void DeletePaidLeaveApplication()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from PaidLeaveApplication where busDriverUsername = @username and requestedDate = @wantedDatetime;";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", _applicantDriver);
                cmd.Parameters.AddWithValue("@wantedDatetime", DateTime.Parse(_wantedDatetime).ToString("yyyy-MM-dd"));
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
