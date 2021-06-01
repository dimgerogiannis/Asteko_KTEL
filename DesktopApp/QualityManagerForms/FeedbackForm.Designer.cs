
namespace QualityManagerForms
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
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.feedbackRichTextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(12, 23);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(156, 25);
            this.feedbackLabel.TabIndex = 0;
            this.feedbackLabel.Text = "Σχόλιο βελτίωσης";
            // 
            // feedbackRichTextbox
            // 
            this.feedbackRichTextbox.Location = new System.Drawing.Point(12, 51);
            this.feedbackRichTextbox.MaxLength = 300;
            this.feedbackRichTextbox.Name = "feedbackRichTextbox";
            this.feedbackRichTextbox.Size = new System.Drawing.Size(526, 319);
            this.feedbackRichTextbox.TabIndex = 1;
            this.feedbackRichTextbox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 376);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Προσθήκη";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.ControlBox = false;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.feedbackRichTextbox);
            this.Controls.Add(this.feedbackLabel);
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

        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.RichTextBox feedbackRichTextbox;
        private System.Windows.Forms.Button submitButton;
    }
}