
namespace Project.BusDriverForms
{
    partial class IncommingComplaintForm
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
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.datetimeCombobox = new System.Windows.Forms.ComboBox();
            this.complaintRichTextbox = new System.Windows.Forms.RichTextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.Location = new System.Drawing.Point(12, 20);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(109, 25);
            this.datetimeLabel.TabIndex = 0;
            this.datetimeLabel.Text = "Ημερονηνία";
            // 
            // datetimeCombobox
            // 
            this.datetimeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.datetimeCombobox.FormattingEnabled = true;
            this.datetimeCombobox.Location = new System.Drawing.Point(12, 48);
            this.datetimeCombobox.Name = "datetimeCombobox";
            this.datetimeCombobox.Size = new System.Drawing.Size(273, 33);
            this.datetimeCombobox.TabIndex = 1;
            this.datetimeCombobox.SelectedIndexChanged += new System.EventHandler(this.DatetimeCombobox_SelectedIndexChanged);
            // 
            // complaintRichTextbox
            // 
            this.complaintRichTextbox.Location = new System.Drawing.Point(12, 106);
            this.complaintRichTextbox.Name = "complaintRichTextbox";
            this.complaintRichTextbox.Size = new System.Drawing.Size(489, 555);
            this.complaintRichTextbox.TabIndex = 2;
            this.complaintRichTextbox.Text = "";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 669);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 34);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Διαγραφή";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // IncommingComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 715);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.complaintRichTextbox);
            this.Controls.Add(this.datetimeCombobox);
            this.Controls.Add(this.datetimeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncommingComplaintForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.IncommingComplaintForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label datetimeLabel;
        private System.Windows.Forms.ComboBox datetimeCombobox;
        private System.Windows.Forms.RichTextBox complaintRichTextbox;
        private System.Windows.Forms.Button deleteButton;
    }
}