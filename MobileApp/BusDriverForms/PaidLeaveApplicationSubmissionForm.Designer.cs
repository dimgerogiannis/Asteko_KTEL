
namespace Project.BusDriverForms
{
    partial class PaidLeaveApplicationSubmissionForm
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonRichTextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 20);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(169, 25);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Ημερομηνία άδειας";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 48);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(489, 31);
            this.dateTimePicker.TabIndex = 1;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(12, 116);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(285, 25);
            this.reasonLabel.TabIndex = 2;
            this.reasonLabel.Text = "Περιγράψτε το λόγο άδειας (300)";
            // 
            // reasonRichTextbox
            // 
            this.reasonRichTextbox.Location = new System.Drawing.Point(12, 144);
            this.reasonRichTextbox.Name = "reasonRichTextbox";
            this.reasonRichTextbox.Size = new System.Drawing.Size(489, 473);
            this.reasonRichTextbox.TabIndex = 3;
            this.reasonRichTextbox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 623);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PaidLeaveApplicationSubmissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 715);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.reasonRichTextbox);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaidLeaveApplicationSubmissionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PaidLeaveApplicationSubmissionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.RichTextBox reasonRichTextbox;
        private System.Windows.Forms.Button submitButton;
    }
}