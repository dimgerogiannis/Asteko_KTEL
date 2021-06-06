using ClassesFolder;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.BusDriverForms
{
    public partial class IncommingComplaintForm : Form
    {
        private BusDriver _busDriver;
        private List<DisciplinaryComment> _complaints;

        public IncommingComplaintForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void IncommingComplaintForm_Load(object sender, EventArgs e)
        {
            _complaints = _busDriver.GetDisciplinaryComments();

            foreach (var complaint in _complaints.OrderByDescending(x => x.Datetime))
                datetimeCombobox.Items.Add(complaint.Datetime.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        private void DatetimeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (datetimeCombobox.SelectedItem != null)
                complaintRichTextbox.Text = _complaints.Find(x => x.Datetime == DateTime.Parse(datetimeCombobox.SelectedItem.ToString())).Comment;
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (datetimeCombobox.SelectedItem != null)
                DeleteDisciplinaryComment(_complaints.Find(x => x.Datetime.ToString("dd-MM-yyyy HH:mm:ss") == datetimeCombobox.SelectedItem.ToString()));
        }

        /// <summary>
        /// Method that deletes Bus driver's disciplinary comment
        /// </summary>
        /// <param name="comment">A disciplinary comment</param>
        private void DeleteDisciplinaryComment(DisciplinaryComment comment)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"delete from DisciplinaryComplaint 
                         where targetUsername = @targetUsername and submittedDatetime = @submittedDatetime";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@targetUsername", comment.TargetDriver.Username);
                cmd.Parameters.AddWithValue("@submittedDatetime", comment.Datetime.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();

                _complaints.Remove(comment);
                datetimeCombobox.Items.RemoveAt(datetimeCombobox.SelectedIndex);
                complaintRichTextbox.Text = "";
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
