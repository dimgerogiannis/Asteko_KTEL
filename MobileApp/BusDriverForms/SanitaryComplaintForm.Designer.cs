
namespace Project.BusDriverForms
{
    partial class SanitaryComplaintForm
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
            this.violationTypeLabel = new System.Windows.Forms.Label();
            this.violationsCombobox = new System.Windows.Forms.ComboBox();
            this.clientFullNameLabel = new System.Windows.Forms.Label();
            this.clientFullNameLabelCombobox = new System.Windows.Forms.ComboBox();
            this.violationDescriptionLabel = new System.Windows.Forms.Label();
            this.violationDescriptionRichTextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // violationTypeLabel
            // 
            this.violationTypeLabel.AutoSize = true;
            this.violationTypeLabel.Location = new System.Drawing.Point(12, 132);
            this.violationTypeLabel.Name = "violationTypeLabel";
            this.violationTypeLabel.Size = new System.Drawing.Size(159, 25);
            this.violationTypeLabel.TabIndex = 0;
            this.violationTypeLabel.Text = "Είδος παραβίασης";
            // 
            // violationsCombobox
            // 
            this.violationsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.violationsCombobox.FormattingEnabled = true;
            this.violationsCombobox.Location = new System.Drawing.Point(12, 160);
            this.violationsCombobox.Name = "violationsCombobox";
            this.violationsCombobox.Size = new System.Drawing.Size(485, 33);
            this.violationsCombobox.TabIndex = 1;
            // 
            // clientFullNameLabel
            // 
            this.clientFullNameLabel.AutoSize = true;
            this.clientFullNameLabel.Location = new System.Drawing.Point(12, 25);
            this.clientFullNameLabel.Name = "clientFullNameLabel";
            this.clientFullNameLabel.Size = new System.Drawing.Size(219, 25);
            this.clientFullNameLabel.TabIndex = 2;
            this.clientFullNameLabel.Text = "Ονοματεπώνυμο επιβάτη";
            // 
            // clientFullNameLabelCombobox
            // 
            this.clientFullNameLabelCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientFullNameLabelCombobox.FormattingEnabled = true;
            this.clientFullNameLabelCombobox.Location = new System.Drawing.Point(12, 53);
            this.clientFullNameLabelCombobox.Name = "clientFullNameLabelCombobox";
            this.clientFullNameLabelCombobox.Size = new System.Drawing.Size(485, 33);
            this.clientFullNameLabelCombobox.TabIndex = 3;
            // 
            // violationDescriptionLabel
            // 
            this.violationDescriptionLabel.AutoSize = true;
            this.violationDescriptionLabel.Location = new System.Drawing.Point(12, 223);
            this.violationDescriptionLabel.Name = "violationDescriptionLabel";
            this.violationDescriptionLabel.Size = new System.Drawing.Size(420, 25);
            this.violationDescriptionLabel.TabIndex = 0;
            this.violationDescriptionLabel.Text = "Περιγραφή παραβίασης μέτρων προστασίας (300)";
            // 
            // violationDescriptionRichTextbox
            // 
            this.violationDescriptionRichTextbox.Location = new System.Drawing.Point(12, 251);
            this.violationDescriptionRichTextbox.MaxLength = 300;
            this.violationDescriptionRichTextbox.Name = "violationDescriptionRichTextbox";
            this.violationDescriptionRichTextbox.Size = new System.Drawing.Size(489, 263);
            this.violationDescriptionRichTextbox.TabIndex = 4;
            this.violationDescriptionRichTextbox.Text = "";
            this.violationDescriptionRichTextbox.TextChanged += new System.EventHandler(this.ViolationDescriptionRichTextbox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 529);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // SanitaryComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 711);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.violationDescriptionRichTextbox);
            this.Controls.Add(this.clientFullNameLabelCombobox);
            this.Controls.Add(this.clientFullNameLabel);
            this.Controls.Add(this.violationsCombobox);
            this.Controls.Add(this.violationDescriptionLabel);
            this.Controls.Add(this.violationTypeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SanitaryComplaintForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SanitaryComplaintForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label violationTypeLabel;
        private System.Windows.Forms.ComboBox violationsCombobox;
        private System.Windows.Forms.Label clientFullNameLabel;
        private System.Windows.Forms.ComboBox clientFullNameLabelCombobox;
        private System.Windows.Forms.Label violationDescriptionLabel;
        private System.Windows.Forms.RichTextBox violationDescriptionRichTextbox;
        private System.Windows.Forms.Button submitButton;
    }
}