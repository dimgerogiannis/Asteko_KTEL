
namespace Project.ClientForms
{
    partial class MyApplicationsForm
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateCombobox = new System.Windows.Forms.ComboBox();
            this.rejectionReasonLabel = new System.Windows.Forms.Label();
            this.rejectionReasonRichTextbox = new System.Windows.Forms.RichTextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(11, 100);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(187, 25);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Κατάσταση αίτησης: -";
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(11, 16);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(195, 25);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Ημερομηνία υποβολής";
            // 
            // dateCombobox
            // 
            this.dateCombobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateCombobox.FormattingEnabled = true;
            this.dateCombobox.Location = new System.Drawing.Point(16, 43);
            this.dateCombobox.Margin = new System.Windows.Forms.Padding(2);
            this.dateCombobox.Name = "dateCombobox";
            this.dateCombobox.Size = new System.Drawing.Size(264, 33);
            this.dateCombobox.TabIndex = 0;
            this.dateCombobox.SelectedValueChanged += new System.EventHandler(this.DateCombobox_SelectedValueChanged);
            // 
            // rejectionReasonLabel
            // 
            this.rejectionReasonLabel.AutoSize = true;
            this.rejectionReasonLabel.Location = new System.Drawing.Point(7, 188);
            this.rejectionReasonLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rejectionReasonLabel.Name = "rejectionReasonLabel";
            this.rejectionReasonLabel.Size = new System.Drawing.Size(264, 25);
            this.rejectionReasonLabel.TabIndex = 3;
            this.rejectionReasonLabel.Text = "Αιτιολογία απόρριψης αίτησης";
            // 
            // rejectionReasonRichTextbox
            // 
            this.rejectionReasonRichTextbox.Location = new System.Drawing.Point(11, 215);
            this.rejectionReasonRichTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.rejectionReasonRichTextbox.Name = "rejectionReasonRichTextbox";
            this.rejectionReasonRichTextbox.Size = new System.Drawing.Size(480, 225);
            this.rejectionReasonRichTextbox.TabIndex = 4;
            this.rejectionReasonRichTextbox.Text = "";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(11, 445);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(187, 37);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Διαγραφή αίτησης";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MyApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dateCombobox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.rejectionReasonRichTextbox);
            this.Controls.Add(this.rejectionReasonLabel);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MyApplications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ComboBox dateCombobox;
        private System.Windows.Forms.Label rejectionReasonLabel;
        private System.Windows.Forms.RichTextBox rejectionReasonRichTextbox;
        private System.Windows.Forms.Button deleteButton;
    }
}