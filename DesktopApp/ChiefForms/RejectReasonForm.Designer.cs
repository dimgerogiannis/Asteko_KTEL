
namespace ChiefForms
{
    partial class RejectReasonForm
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
            this.reasonRichTextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reasonRichTextbox
            // 
            this.reasonRichTextbox.Location = new System.Drawing.Point(12, 47);
            this.reasonRichTextbox.MaxLength = 200;
            this.reasonRichTextbox.Name = "reasonRichTextbox";
            this.reasonRichTextbox.Size = new System.Drawing.Size(545, 282);
            this.reasonRichTextbox.TabIndex = 0;
            this.reasonRichTextbox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 335);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(133, 34);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Καταχώρηση";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(12, 19);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(196, 25);
            this.reasonLabel.TabIndex = 2;
            this.reasonLabel.Text = "Αιτιολογία απόρριψης";
            // 
            // RejectReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(565, 376);
            this.ControlBox = false;
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.reasonRichTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RejectReasonForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox reasonRichTextbox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label reasonLabel;
    }
}