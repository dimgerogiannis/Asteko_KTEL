
namespace Project.ClientForms
{
    partial class ClientComplaintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.complaintListLabel = new System.Windows.Forms.Label();
            this.complaintListCombobox = new System.Windows.Forms.ComboBox();
            this.describeRichTextbox = new System.Windows.Forms.RichTextBox();
            this.describeLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // complaintListLabel
            // 
            this.complaintListLabel.AutoSize = true;
            this.complaintListLabel.Location = new System.Drawing.Point(8, 25);
            this.complaintListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.complaintListLabel.Name = "complaintListLabel";
            this.complaintListLabel.Size = new System.Drawing.Size(208, 25);
            this.complaintListLabel.TabIndex = 0;
            this.complaintListLabel.Text = "Κατηγορίες παραπόνων";
            // 
            // complaintListCombobox
            // 
            this.complaintListCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.complaintListCombobox.FormattingEnabled = true;
            this.complaintListCombobox.Location = new System.Drawing.Point(12, 54);
            this.complaintListCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.complaintListCombobox.Name = "complaintListCombobox";
            this.complaintListCombobox.Size = new System.Drawing.Size(483, 33);
            this.complaintListCombobox.TabIndex = 1;
            // 
            // describeRichTextbox
            // 
            this.describeRichTextbox.Location = new System.Drawing.Point(12, 141);
            this.describeRichTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.describeRichTextbox.MaxLength = 300;
            this.describeRichTextbox.Name = "describeRichTextbox";
            this.describeRichTextbox.Size = new System.Drawing.Size(483, 284);
            this.describeRichTextbox.TabIndex = 2;
            this.describeRichTextbox.Text = "";
            this.describeRichTextbox.TextChanged += new System.EventHandler(this.DescribeRichTextbox_TextChanged);
            // 
            // describeLabel
            // 
            this.describeLabel.AutoSize = true;
            this.describeLabel.Location = new System.Drawing.Point(8, 114);
            this.describeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.describeLabel.Name = "describeLabel";
            this.describeLabel.Size = new System.Drawing.Size(455, 25);
            this.describeLabel.TabIndex = 3;
            this.describeLabel.Text = "Περιγράψτε με λίγα λόγια τον λόγο καταγγελίας. (300)";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 431);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(122, 38);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ClientComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.describeLabel);
            this.Controls.Add(this.describeRichTextbox);
            this.Controls.Add(this.complaintListCombobox);
            this.Controls.Add(this.complaintListLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientComplaintForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ClientComplaint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label complaintListLabel;
        private System.Windows.Forms.ComboBox complaintListCombobox;
        private System.Windows.Forms.RichTextBox describeRichTextbox;
        private System.Windows.Forms.Label describeLabel;
        private System.Windows.Forms.Button submitButton;
    }
}