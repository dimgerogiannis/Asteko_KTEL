using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class DiscountApplications : Form
    {
        private QualityManager _qualityManager;
        private List<DiscountApplication> _applications;
        private int _index;

        public DiscountApplications(QualityManager qualityManager)
        {
            _qualityManager = qualityManager;
            InitializeComponent();
        }

        private void DiscountApplications_Load(object sender, EventArgs e)
        {
            _applications = _qualityManager.GetUncheckedDiscountApplications();
            foreach (var application in _applications)
            {
                namesCombobox.Items.Add(application.ApplicantClient.GetFullName());
            }
        }

        private void NamesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (namesCombobox.SelectedItem != null)
            {
                _index = namesCombobox.SelectedIndex;
                dateLabel.Text = $"Ημερομηνία αίτησης: {_applications[_index].ApplicationDatetime?.ToString("HH:mm:ss dd-MM-yyyy")}";
                taxIDLabel.Text = $"Α.Φ.Μ.: {_applications[_index].TaxIdentificationNumber}";
                phoneLabel.Text = $"Τηλέφωνο: {_applications[_index].PhoneNumber}";

                var cat = "";
                switch (_applications[_index].Category)
                {
                    case Enums.Category.DissabilityIssues:
                        cat = "Άτομο με ειδικές ανάγκες";
                        break;
                    case Enums.Category.LowIncome:
                        cat = "Χαμηλό εισόδημα";
                        break;
                    case Enums.Category.Soldier:
                        cat = "Στρατιώτης";
                        break;
                    case Enums.Category.Student:
                        cat = "Μαθητής";
                        break;
                }

                categoryLabel.Text = $"Κατηγορία: {cat}";

                var path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{namesCombobox.SelectedItem}{Guid.NewGuid()}";
                System.IO.Directory.CreateDirectory(path);
                foreach (var file in _applications[_index].Files)
                {
                    System.IO.File.WriteAllBytes($@"{path}\{file.FileName}", file.FileContent);
                }

                namesCombobox.Enabled = false;
            }
        }

        private void ApproveRejectButton_Click(object sender, EventArgs e)
        {
            if (namesCombobox.SelectedItem != null)
            {
                var result = MessageBox.Show("Θέλετε να αποδεχτήτε την αίτηση;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var client = _applications[namesCombobox.SelectedIndex].ApplicantClient;
                    client.UpdateDiscount(_applications[namesCombobox.SelectedIndex].Category);
                    _applications[namesCombobox.SelectedIndex].SetAsAccepted();
                }
                else
                {
                    RejectReasonForm form = new RejectReasonForm(_applications[namesCombobox.SelectedIndex]);
                    form.ShowDialog();
                }

                dateLabel.Text = "Ημερομηνία αίτησης:";
                taxIDLabel.Text = "Α.Φ.Μ.:";
                phoneLabel.Text = "Τηλέφωνο:";
                categoryLabel.Text = "Κατηγορία:";
                namesCombobox.Enabled = true;
                namesCombobox.Items.RemoveAt(_index);
            }  
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε μια αίτηση;",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
