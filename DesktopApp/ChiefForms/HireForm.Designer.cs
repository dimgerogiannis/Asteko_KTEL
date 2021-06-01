
namespace ChiefForms
{
    partial class HireForm
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.surnameTextbox = new System.Windows.Forms.TextBox();
            this.experienceLabel = new System.Windows.Forms.Label();
            this.experienceCobmobox = new System.Windows.Forms.ComboBox();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.salaryTextbox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 20);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(132, 25);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Όνομα χρήστη";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 99);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(81, 25);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Κωδικός";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 178);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(67, 25);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Όνομα";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(12, 257);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(87, 25);
            this.surnameLabel.TabIndex = 3;
            this.surnameLabel.Text = "Επώνυμο";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(12, 48);
            this.usernameTextbox.MaxLength = 30;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(373, 31);
            this.usernameTextbox.TabIndex = 4;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(12, 127);
            this.passwordTextbox.MaxLength = 32;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(373, 31);
            this.passwordTextbox.TabIndex = 5;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(12, 206);
            this.nameTextbox.MaxLength = 20;
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(373, 31);
            this.nameTextbox.TabIndex = 6;
            // 
            // surnameTextbox
            // 
            this.surnameTextbox.Location = new System.Drawing.Point(12, 285);
            this.surnameTextbox.MaxLength = 20;
            this.surnameTextbox.Name = "surnameTextbox";
            this.surnameTextbox.Size = new System.Drawing.Size(373, 31);
            this.surnameTextbox.TabIndex = 7;
            // 
            // experienceLabel
            // 
            this.experienceLabel.AutoSize = true;
            this.experienceLabel.Location = new System.Drawing.Point(12, 496);
            this.experienceLabel.Name = "experienceLabel";
            this.experienceLabel.Size = new System.Drawing.Size(123, 25);
            this.experienceLabel.TabIndex = 8;
            this.experienceLabel.Text = "Προϋπηρεσία";
            // 
            // experienceCobmobox
            // 
            this.experienceCobmobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.experienceCobmobox.FormattingEnabled = true;
            this.experienceCobmobox.Location = new System.Drawing.Point(12, 524);
            this.experienceCobmobox.Name = "experienceCobmobox";
            this.experienceCobmobox.Size = new System.Drawing.Size(132, 33);
            this.experienceCobmobox.TabIndex = 9;
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Location = new System.Drawing.Point(12, 336);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(73, 25);
            this.salaryLabel.TabIndex = 10;
            this.salaryLabel.Text = "Μισθός";
            // 
            // salaryTextbox
            // 
            this.salaryTextbox.Location = new System.Drawing.Point(12, 364);
            this.salaryTextbox.Name = "salaryTextbox";
            this.salaryTextbox.Size = new System.Drawing.Size(132, 31);
            this.salaryTextbox.TabIndex = 11;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 581);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(12, 415);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(99, 25);
            this.categoryLabel.TabIndex = 13;
            this.categoryLabel.Text = "Κατηγορία";
            // 
            // categoryCombobox
            // 
            this.categoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCombobox.FormattingEnabled = true;
            this.categoryCombobox.Location = new System.Drawing.Point(12, 443);
            this.categoryCombobox.Name = "categoryCombobox";
            this.categoryCombobox.Size = new System.Drawing.Size(373, 33);
            this.categoryCombobox.TabIndex = 14;
            // 
            // HireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(397, 635);
            this.Controls.Add(this.categoryCombobox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.salaryTextbox);
            this.Controls.Add(this.salaryLabel);
            this.Controls.Add(this.experienceCobmobox);
            this.Controls.Add(this.experienceLabel);
            this.Controls.Add(this.surnameTextbox);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HireForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HireForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.TextBox surnameTextbox;
        private System.Windows.Forms.Label experienceLabel;
        private System.Windows.Forms.ComboBox experienceCobmobox;
        private System.Windows.Forms.Label salaryLabel;
        private System.Windows.Forms.TextBox salaryTextbox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryCombobox;
    }
}