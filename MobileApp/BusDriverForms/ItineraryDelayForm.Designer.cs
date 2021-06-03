
namespace Project.BusDriverForms
{
    partial class ItineraryDelayForm
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
            this.delayedLabel = new System.Windows.Forms.Label();
            this.delayedReasonRichtextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delayedLabel
            // 
            this.delayedLabel.AutoSize = true;
            this.delayedLabel.Location = new System.Drawing.Point(12, 30);
            this.delayedLabel.Name = "delayedLabel";
            this.delayedLabel.Size = new System.Drawing.Size(219, 25);
            this.delayedLabel.TabIndex = 0;
            this.delayedLabel.Text = "Λόγος καθυστέρησης (50)";
            // 
            // delayedReasonRichtextbox
            // 
            this.delayedReasonRichtextbox.Location = new System.Drawing.Point(12, 58);
            this.delayedReasonRichtextbox.MaxLength = 50;
            this.delayedReasonRichtextbox.Name = "delayedReasonRichtextbox";
            this.delayedReasonRichtextbox.Size = new System.Drawing.Size(485, 175);
            this.delayedReasonRichtextbox.TabIndex = 1;
            this.delayedReasonRichtextbox.Text = "";
            this.delayedReasonRichtextbox.TextChanged += new System.EventHandler(this.DelayedReasonRichtextbox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 239);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ItineraryDelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(509, 711);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.delayedReasonRichtextbox);
            this.Controls.Add(this.delayedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItineraryDelayForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ItineraryDelayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label delayedLabel;
        private System.Windows.Forms.RichTextBox delayedReasonRichtextbox;
        private System.Windows.Forms.Button submitButton;
    }
}