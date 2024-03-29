﻿using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class DisciplinaryForm : Form
    {
        private QualityManager _qualityManager;
        private ClientComplaint _complaint;

        public DisciplinaryForm(QualityManager qualityManager, ClientComplaint complaint)
        {
            _qualityManager = qualityManager;
            _complaint = complaint;
            InitializeComponent();
        }

        private void DisciplinaryCommentRichTextbox_TextChanged(object sender, EventArgs e)
        {
            disciplinaryCommentLabel.Text = $"Σχόλιο συμμόρφωσης ({200 - disciplinaryCommentRichTextbox.Text.Length})";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (disciplinaryCommentRichTextbox.Text != "")
            {
                _qualityManager.InsertDisciplinaryCommentInDatabase(new DisciplinaryComment(_complaint.TargetDriver,
                                                                                            disciplinaryCommentRichTextbox.Text,
                                                                                            DateTime.Now));
                _complaint.SetAsChecked();

                MessageBox.Show("Επιτυχής καταχώρηση.",
                                "Επιτυχία",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε το σχόλιο συμμόρφωσης.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
