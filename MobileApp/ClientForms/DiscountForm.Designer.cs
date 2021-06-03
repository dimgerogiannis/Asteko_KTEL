
namespace Project.ClientForms
{
    partial class DiscountForm
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
            this.submitApplication = new System.Windows.Forms.Button();
            this.submitFiles = new System.Windows.Forms.Button();
            this.categoryCombobox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.phoneTextbox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.taxIDTextbox = new System.Windows.Forms.TextBox();
            this.taxIDLabel = new System.Windows.Forms.Label();
            this.ageCombobox = new System.Windows.Forms.ComboBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitApplication
            // 
            this.submitApplication.Location = new System.Drawing.Point(11, 593);
            this.submitApplication.Margin = new System.Windows.Forms.Padding(6);
            this.submitApplication.Name = "submitApplication";
            this.submitApplication.Size = new System.Drawing.Size(252, 44);
            this.submitApplication.TabIndex = 35;
            this.submitApplication.Text = "Υποβολή αίτησης";
            this.submitApplication.UseVisualStyleBackColor = true;
            this.submitApplication.Click += new System.EventHandler(this.SubmitApplication_Click);
            // 
            // submitFiles
            // 
            this.submitFiles.Location = new System.Drawing.Point(11, 537);
            this.submitFiles.Margin = new System.Windows.Forms.Padding(6);
            this.submitFiles.Name = "submitFiles";
            this.submitFiles.Size = new System.Drawing.Size(251, 44);
            this.submitFiles.TabIndex = 34;
            this.submitFiles.Text = "Επισύναψη δικαιολογιτικών";
            this.submitFiles.UseVisualStyleBackColor = true;
            this.submitFiles.Click += new System.EventHandler(this.SubmitFiles_Click);
            // 
            // categoryCombobox
            // 
            this.categoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCombobox.FormattingEnabled = true;
            this.categoryCombobox.Location = new System.Drawing.Point(11, 479);
            this.categoryCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.categoryCombobox.Name = "categoryCombobox";
            this.categoryCombobox.Size = new System.Drawing.Size(482, 33);
            this.categoryCombobox.TabIndex = 33;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(11, 448);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(99, 25);
            this.categoryLabel.TabIndex = 32;
            this.categoryLabel.Text = "Κατηγορία";
            // 
            // phoneTextbox
            // 
            this.phoneTextbox.Location = new System.Drawing.Point(11, 372);
            this.phoneTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.phoneTextbox.MaxLength = 10;
            this.phoneTextbox.Name = "phoneTextbox";
            this.phoneTextbox.Size = new System.Drawing.Size(174, 31);
            this.phoneTextbox.TabIndex = 31;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(11, 341);
            this.phoneLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(207, 25);
            this.phoneLabel.TabIndex = 30;
            this.phoneLabel.Text = "Τηλέφωνο επικοινωνίας";
            // 
            // taxIDTextbox
            // 
            this.taxIDTextbox.Location = new System.Drawing.Point(11, 266);
            this.taxIDTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.taxIDTextbox.MaxLength = 15;
            this.taxIDTextbox.Name = "taxIDTextbox";
            this.taxIDTextbox.Size = new System.Drawing.Size(252, 31);
            this.taxIDTextbox.TabIndex = 29;
            // 
            // taxIDLabel
            // 
            this.taxIDLabel.AutoSize = true;
            this.taxIDLabel.Location = new System.Drawing.Point(11, 235);
            this.taxIDLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.taxIDLabel.Name = "taxIDLabel";
            this.taxIDLabel.Size = new System.Drawing.Size(276, 25);
            this.taxIDLabel.TabIndex = 28;
            this.taxIDLabel.Text = "Αριθμός φορολογικού μητρώου";
            // 
            // ageCombobox
            // 
            this.ageCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ageCombobox.FormattingEnabled = true;
            this.ageCombobox.Location = new System.Drawing.Point(11, 160);
            this.ageCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.ageCombobox.Name = "ageCombobox";
            this.ageCombobox.Size = new System.Drawing.Size(132, 33);
            this.ageCombobox.TabIndex = 27;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(11, 129);
            this.ageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(64, 25);
            this.ageLabel.TabIndex = 26;
            this.ageLabel.Text = "Ηλικία";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(11, 53);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(6);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(482, 31);
            this.nameTextbox.TabIndex = 25;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(11, 22);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(150, 25);
            this.nameLabel.TabIndex = 24;
            this.nameLabel.Text = "Ονοματεπώνυμο";
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.submitApplication);
            this.Controls.Add(this.submitFiles);
            this.Controls.Add(this.categoryCombobox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.phoneTextbox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.taxIDTextbox);
            this.Controls.Add(this.taxIDLabel);
            this.Controls.Add(this.ageCombobox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Discount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitApplication;
        private System.Windows.Forms.Button submitFiles;
        private System.Windows.Forms.ComboBox categoryCombobox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.TextBox phoneTextbox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox taxIDTextbox;
        private System.Windows.Forms.Label taxIDLabel;
        private System.Windows.Forms.ComboBox ageCombobox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label nameLabel;
    }
}