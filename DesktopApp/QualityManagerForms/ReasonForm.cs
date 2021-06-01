using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QualityManagerForms
{
    public partial class ReasonForm : Form
    {
        private string _reason;

        public ReasonForm(string reason)
        {
            _reason = reason;
            InitializeComponent();
        }

        private void ReasonForm_Load(object sender, EventArgs e)
        {
            reasonRichTextbox.Text = _reason;
        }
    }
}
