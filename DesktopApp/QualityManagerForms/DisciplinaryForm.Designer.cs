
namespace QualityManagerForms
{
    partial class DisciplinaryForm
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
            this.disciplinaryCommentLabel = new System.Windows.Forms.Label();
            this.disciplinaryCommentRichTextbox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // disciplinaryCommentLabel
            // 
            this.disciplinaryCommentLabel.AutoSize = true;
            this.disciplinaryCommentLabel.Location = new System.Drawing.Point(12, 23);
            this.disciplinaryCommentLabel.Name = "disciplinaryCommentLabel";
            this.disciplinaryCommentLabel.Size = new System.Drawing.Size(235, 25);
            this.disciplinaryCommentLabel.TabIndex = 0;
            this.disciplinaryCommentLabel.Text = "Σχόλια συμμόρφωσης (200)";
            // 
            // disciplinaryCommentRichTextbox
            // 
            this.disciplinaryCommentRichTextbox.Location = new System.Drawing.Point(12, 51);
            this.disciplinaryCommentRichTextbox.MaxLength = 200;
            this.disciplinaryCommentRichTextbox.Name = "disciplinaryCommentRichTextbox";
            this.disciplinaryCommentRichTextbox.Size = new System.Drawing.Size(537, 256);
            this.disciplinaryCommentRichTextbox.TabIndex = 1;
            this.disciplinaryCommentRichTextbox.Text = "";
            this.disciplinaryCommentRichTextbox.TextChanged += new System.EventHandler(this.DisciplinaryCommentRichTextbox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 313);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Αποστολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DisciplinaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(561, 357);
            this.ControlBox = false;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.disciplinaryCommentRichTextbox);
            this.Controls.Add(this.disciplinaryCommentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisciplinaryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label disciplinaryCommentLabel;
        private System.Windows.Forms.RichTextBox disciplinaryCommentRichTextbox;
        private System.Windows.Forms.Button submitButton;
    }
}