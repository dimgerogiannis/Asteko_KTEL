
namespace DistributorForms
{
    partial class FeedbackForm
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
            this.number = new System.Windows.Forms.Label();
            this.numberCombobox = new System.Windows.Forms.ComboBox();
            this.feedbackRichTextbox = new System.Windows.Forms.RichTextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Location = new System.Drawing.Point(12, 24);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(241, 25);
            this.number.TabIndex = 0;
            this.number.Text = "Αριθμοί οδηγιών βελτίωσης";
            // 
            // numberCombobox
            // 
            this.numberCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberCombobox.FormattingEnabled = true;
            this.numberCombobox.Location = new System.Drawing.Point(12, 52);
            this.numberCombobox.Name = "numberCombobox";
            this.numberCombobox.Size = new System.Drawing.Size(102, 33);
            this.numberCombobox.TabIndex = 1;
            this.numberCombobox.SelectedIndexChanged += new System.EventHandler(this.NumberCombobox_SelectedIndexChanged);
            // 
            // feedbackRichTextbox
            // 
            this.feedbackRichTextbox.Location = new System.Drawing.Point(12, 103);
            this.feedbackRichTextbox.Name = "feedbackRichTextbox";
            this.feedbackRichTextbox.Size = new System.Drawing.Size(474, 206);
            this.feedbackRichTextbox.TabIndex = 2;
            this.feedbackRichTextbox.Text = "";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 315);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 34);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Διαγραφή";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(498, 359);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.feedbackRichTextbox);
            this.Controls.Add(this.numberCombobox);
            this.Controls.Add(this.number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbackForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FeedbackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label number;
        private System.Windows.Forms.ComboBox numberCombobox;
        private System.Windows.Forms.RichTextBox feedbackRichTextbox;
        private System.Windows.Forms.Button deleteButton;
    }
}