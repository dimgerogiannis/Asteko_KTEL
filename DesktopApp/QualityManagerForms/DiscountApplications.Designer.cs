
namespace QualityManagerForms
{
    partial class DiscountApplications
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
            this.namesLabel = new System.Windows.Forms.Label();
            this.namesCombobox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.taxIDLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.approveRejectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namesLabel
            // 
            this.namesLabel.AutoSize = true;
            this.namesLabel.Location = new System.Drawing.Point(12, 19);
            this.namesLabel.Name = "namesLabel";
            this.namesLabel.Size = new System.Drawing.Size(170, 25);
            this.namesLabel.TabIndex = 0;
            this.namesLabel.Text = "Ονόματα επιβατών";
            // 
            // namesCombobox
            // 
            this.namesCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.namesCombobox.FormattingEnabled = true;
            this.namesCombobox.Location = new System.Drawing.Point(12, 47);
            this.namesCombobox.Name = "namesCombobox";
            this.namesCombobox.Size = new System.Drawing.Size(426, 33);
            this.namesCombobox.TabIndex = 1;
            this.namesCombobox.SelectedIndexChanged += new System.EventHandler(this.NamesCombobox_SelectedIndexChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 99);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(182, 25);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Ημερομηνία αίτησης:";
            // 
            // taxIDLabel
            // 
            this.taxIDLabel.AutoSize = true;
            this.taxIDLabel.Location = new System.Drawing.Point(12, 144);
            this.taxIDLabel.Name = "taxIDLabel";
            this.taxIDLabel.Size = new System.Drawing.Size(70, 25);
            this.taxIDLabel.TabIndex = 3;
            this.taxIDLabel.Text = "Α.Φ.Μ.:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(12, 189);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(100, 25);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "Τηλέφωνο:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(12, 234);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(103, 25);
            this.categoryLabel.TabIndex = 5;
            this.categoryLabel.Text = "Κατηγορία:";
            // 
            // approveRejectButton
            // 
            this.approveRejectButton.Location = new System.Drawing.Point(12, 271);
            this.approveRejectButton.Name = "approveRejectButton";
            this.approveRejectButton.Size = new System.Drawing.Size(122, 34);
            this.approveRejectButton.TabIndex = 6;
            this.approveRejectButton.Text = "Επεξεργασία";
            this.approveRejectButton.UseVisualStyleBackColor = true;
            this.approveRejectButton.Click += new System.EventHandler(this.ApproveRejectButton_Click);
            // 
            // DiscountApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(450, 317);
            this.Controls.Add(this.approveRejectButton);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.taxIDLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.namesCombobox);
            this.Controls.Add(this.namesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscountApplications";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DiscountApplications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namesLabel;
        private System.Windows.Forms.ComboBox namesCombobox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label taxIDLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Button approveRejectButton;
    }
}