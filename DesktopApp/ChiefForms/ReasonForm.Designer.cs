
namespace ChiefForms
{
    partial class ReasonForm
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
            this.SuspendLayout();
            // 
            // reasonRichTextbox
            // 
            this.reasonRichTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reasonRichTextbox.Location = new System.Drawing.Point(0, 0);
            this.reasonRichTextbox.Name = "reasonRichTextbox";
            this.reasonRichTextbox.Size = new System.Drawing.Size(617, 450);
            this.reasonRichTextbox.TabIndex = 0;
            this.reasonRichTextbox.Text = "";
            // 
            // ReasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(617, 450);
            this.Controls.Add(this.reasonRichTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReasonForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ReasonForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox reasonRichTextbox;
    }
}