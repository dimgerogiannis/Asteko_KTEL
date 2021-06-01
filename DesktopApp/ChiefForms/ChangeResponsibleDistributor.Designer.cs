
namespace ChiefForms
{
    partial class ChangeResponsibleDistributor
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
            this.distributorLabel = new System.Windows.Forms.Label();
            this.distributorCombobox = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // distributorLabel
            // 
            this.distributorLabel.AutoSize = true;
            this.distributorLabel.Location = new System.Drawing.Point(12, 24);
            this.distributorLabel.Name = "distributorLabel";
            this.distributorLabel.Size = new System.Drawing.Size(310, 25);
            this.distributorLabel.TabIndex = 0;
            this.distributorLabel.Text = "Υπεύθυνος κατανομής δρομολογίων";
            // 
            // distributorCombobox
            // 
            this.distributorCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distributorCombobox.FormattingEnabled = true;
            this.distributorCombobox.Location = new System.Drawing.Point(12, 52);
            this.distributorCombobox.Name = "distributorCombobox";
            this.distributorCombobox.Size = new System.Drawing.Size(376, 33);
            this.distributorCombobox.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 115);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(128, 34);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Καταχώρηση";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ChangeResponsibleDistributor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(400, 173);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.distributorCombobox);
            this.Controls.Add(this.distributorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeResponsibleDistributor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChangeResponsibleDistributor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label distributorLabel;
        private System.Windows.Forms.ComboBox distributorCombobox;
        private System.Windows.Forms.Button submitButton;
    }
}