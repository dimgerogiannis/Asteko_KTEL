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
    public class PaidLeaveApplication
    {
        private string _applicantDriver;
        private string _applicationDatetime;
        private string _reason;
        private string _possibleRejectionReason;
        private string _wantedDatetime;
        private Status _status;

        public string ApplicantDriver => _applicantDriver;
        public string ApplicationDatetime => _applicationDatetime; 
        public string Reason => _reason;
        public string PossibleRejectionReason
        {
            get { return _possibleRejectionReason; }
            set { _possibleRejectionReason = value; }
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
            _possibleRejectionReason = rejectionReason;
            _wantedDatetime = wantedDatetime;
            _status = status;
        }

        public void SetAsAccepted()
        {
            _status = Status.Accepted;

        }

        public void SetAsRejected()
        {
            _status = Status.Rejected;

        }

        public void UpdatePaidLeaveApplcationStatus()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update PaidLeaveApplication
                              set status = @status
                              where busDriverUsername = @username and requestedDate = @requestedDate;";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@status", _status == Status.Rejected ? "rejected" : "accepted");
                cmd.Parameters.AddWithValue("@username", _applicantDriver);
                cmd.Parameters.AddWithValue("@requestedDate", DateTime.Parse(_wantedDatetime).ToString("yyyy-MM-dd"));
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

        public void InsertPaidLeaveApplicationRejectionReason()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"update PaidLeaveApplication
                              set rejectionReason = @rejectionReason
                              where busDriverUsername = @username and requestedDate = @requestedDate;";
                using var cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@rejectionReason", _possibleRejectionReason);
                cmd.Parameters.AddWithValue("@username", _applicantDriver);
                cmd.Parameters.AddWithValue("@requestedDate", DateTime.Parse(_wantedDatetime).ToString("yyyy-MM-dd"));
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
