using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassesFolder
{
    public class Poll
    {
        private string _title;
        private DateTime _startingDate;
        private DateTime _endingDate;
        private string _question;
        private Dictionary<string, int> _choices;
        private bool _expired;

        public string Title => _title;
        public DateTime StartingDate => _startingDate;
        public DateTime EndingDate => _endingDate;
        public string Question => _question;
        public Dictionary<string, int> Choices => _choices;
        public bool Expired => _expired;

        public Poll(string title, 
            DateTime startingDate, 
            DateTime endingDate,
            string question,
            bool expired)
        {
            _title = title;
            _startingDate = startingDate;
            _endingDate = endingDate;
            _question = question;
            _expired = expired;

            GetPollChoices();
        }

        private void GetPollChoices()
        {
            try
            {
                _choices = new Dictionary<string, int>();

                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select pollChoiceID, choice
                          from pollchoice
                          where title = @title;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", _title);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _choices.Add(reader.GetString(1), reader.GetInt32(0));
                }
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

        public Dictionary<string, int> ExtractStats()
        {
            try
            {
                Dictionary<string, int> results = new Dictionary<string, int>();
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();

                var query = @"select PollChoice.choice, count(*) from poll
                          inner join PollChoice on Poll.title = PollChoice.title
                          inner join PollVote on PollVote.PollChoiceID = PollChoice.PollChoiceID
                          where Poll.title = @title
                          group by PollVote.PollChoiceID;";

                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", _title);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    results[reader.GetString(0)] = reader.GetInt32(1);
                }

                return results;
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

        public void IncrementPollChoice(int pollChoiceID, string clientUsername)
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"insert into PollVote values (@pollChoiceID, @clientUsername)";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pollChoiceID", pollChoiceID);
                cmd.Parameters.AddWithValue("@clientUsername", clientUsername);
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

        public void DeletePoll()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionInfo.ConnectionString);
                connection.Open();
                var query = @"delete from poll
                          where title = @title";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", _title);
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
