﻿using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChiefForms
{
    public partial class RejectReasonForm : Form
    {
        private Chief _chief;
        private PaidLeaveApplication _application;

        public RejectReasonForm(Chief chief, PaidLeaveApplication application)
        {
            _chief = chief;
            _application = application;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (reasonRichTextbox.Text != "")
            {
                _application.SetAsRejected();
                _application.PossibleRejectionReason = reasonRichTextbox.Text;
                _application.UpdatePaidLeaveApplcationStatus();
                _application.InsertPaidLeaveApplicationRejectionReason();
                this.Close();
            }
            else
            {
                MessageBox.Show("Παρακαλώ εισάγετε το λόγο απόρριψης της αίτησης.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void RejectReasonForm_Load(object sender, EventArgs e)
        {

        }

        private void ReasonRichTextbox_TextChanged(object sender, EventArgs e)
        {
            reasonLabel.Text = $"Αιτιολογία απόρριψης ({200 - reasonRichTextbox.Text.Length})";
        }
    }
}
