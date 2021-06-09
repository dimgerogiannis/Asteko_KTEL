using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class DiscountApplications : Form
    {
        private QualityManager _qualityManager;
        private List<DiscountApplication> _applications;

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
                var cat = "";
                switch (application.Category)
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
                discountListview.Items.Add(new ListViewItem(new string[]
                {
                    application.ApplicantClient.GetFullName(),
                    application.ApplicationDatetime?.ToString("HH:mm:ss dd-MM-yyyy"),
                    application.TaxIdentificationNumber,
                    application.PhoneNumber,
                    cat
                }));
            }

            discountListview.ContextMenuStrip = contextMenuStrip;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (discountListview.SelectedItems.Count == 1)
            {
                var path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{discountListview.Items[discountListview.SelectedIndices[0]].SubItems[0].Text}{Guid.NewGuid()}";
                System.IO.Directory.CreateDirectory(path);
                foreach (var file in _applications[discountListview.SelectedIndices[0]].Files)
                {
                    System.IO.File.WriteAllBytes($@"{path}\{file.FileName}", file.FileContent);
                }

                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε ένα μόνο αίτημα για έκπτωση στις μεταφορές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (discountListview.SelectedItems.Count == 1)
            {
                var result = MessageBox.Show("Θέλετε να αποδεχτήτε την αίτηση;",
                                             "Ερώτηση",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                int index = discountListview.SelectedIndices[0];
                if (result == DialogResult.Yes)
                {
                    
                    var client = _applications[index].ApplicantClient;
                    client.UpdateDiscount(_applications[index].Category);
                    _applications[index].SetAsAccepted();
                }
                else
                {
                    RejectReasonForm form = new RejectReasonForm(_applications[index]);
                    form.ShowDialog();
                }

                discountListview.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Παρακαλώ επιλέξτε ένα μόνο αίτημα για έκπτωση στις μεταφορές.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
