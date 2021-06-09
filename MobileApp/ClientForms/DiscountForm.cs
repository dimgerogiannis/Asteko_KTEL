using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace Project.ClientForms
{
    public partial class DiscountForm : Form
    {
        private Client _client;
        private Dictionary<string, Byte[]> _files;

        public DiscountForm(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void Discount_Load(object sender, EventArgs e)
        {
            nameTextbox.Text = _client.GetFullName();
            nameTextbox.ReadOnly = true;
            ageCombobox.Items.AddRange(Enumerable.Range(5, 100).Select(x => x.ToString()).ToArray());
            categoryCombobox.Items.AddRange(new String[] { "Φοιτητής", "Φαντάρος", "Άτομο με ειδικές ανάγκες", "Χαμηλό εισόδημα" });
        }

        private void SubmitFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse pdf Files",
                Multiselect = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "Pdf Files|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 3)
                {
                    MessageBox.Show("Παρακαλώ επισυνάψτε το πολύ 3 αρχεία!", 
                                    "Σφάλμα",
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                }
                else
                {
                    _files = new Dictionary<string, byte[]>(3);

                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        var bytes = System.IO.File.ReadAllBytes(fileName);
                        if (bytes.Length > 3145728)
                        {
                            MessageBox.Show("Μη επιτρεπτό μέγεθος αρχείου. Παρακαλώ το κάθε αρχείο να είναι το πολύ 3 MB.", 
                                            "Σφάλμα",
                                            MessageBoxButtons.OK, 
                                            MessageBoxIcon.Error);
                            _files.Clear();
                            _files = null;
                            break;
                        }
                        _files.Add(fileName.Split("\\")[fileName.Count(x => x == '\\')], bytes);
                    }
                }
            }
        }

        private void SubmitApplication_Click(object sender, EventArgs e)
        {
            if (nameTextbox.Text != "" && 
                ageCombobox.SelectedItem != null && 
                taxIDTextbox.Text != "" && 
                phoneTextbox.Text != "" &&
                categoryCombobox.SelectedItem != null &&
                _files != null)
            {
                if (_client.CheckForDuplicateDiscountApplication())
                {
                    MessageBox.Show("Έχετε κάνει ήδη αίτηση για έκπτωση στις μεταφορές.", 
                                    "Σφάλμα", 
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                Category category = Category.Student;
                switch (categoryCombobox.SelectedItem.ToString())
                {
                    case "Φαντάρος":
                        category = Category.Soldier;
                        break;
                    case "Άτομο με ειδικές ανάγκες":
                        category = Category.DissabilityIssues;
                        break;
                    case "Χαμηλό εισόδημα":
                        category = Category.LowIncome;
                        break;
                }

                List<File> files = new List<File>(_files.Count());
                foreach (var key in _files.Keys)
                    files.Add(new File(key, _files[key]));

                DiscountApplication application = new DiscountApplication(_client,
                                                                          null,
                                                                          null,
                                                                          category,
                                                                          taxIDTextbox.Text,
                                                                          phoneTextbox.Text,
                                                                          Status.Pending,
                                                                          files);

                var result = MessageBox.Show("Θέλετε να καταχωρήσετε την αίτησή σας;", 
                                             "Ερώτηση", 
                                             MessageBoxButtons.YesNo, 
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _client.InsertDiscountApplicationInDatabase(application);
                    var applicationID = _client.GetDiscountApplicationID();
                    _client.InsertDiscountApplicationFilesInDatabase(applicationID, application.Files);
                    
                    MessageBox.Show("Επιτυχής καταχώρηση αίτησης για έκπτωσης στις μεταφορές.", 
                                    "Επιτυχία", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα πεδία.", 
                                "Σφάλμα", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }
    }
}
