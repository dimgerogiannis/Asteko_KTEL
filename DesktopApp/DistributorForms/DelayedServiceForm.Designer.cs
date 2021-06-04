
namespace DistributorForms
{
    partial class DelayedServiceForm
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
            this.lastMinuteApplications = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lastMinuteApplications
            // 
            this.lastMinuteApplications.HideSelection = false;
            this.lastMinuteApplications.Location = new System.Drawing.Point(12, 12);
            this.lastMinuteApplications.Name = "lastMinuteApplications";
            this.lastMinuteApplications.Size = new System.Drawing.Size(776, 362);
            this.lastMinuteApplications.TabIndex = 0;
            this.lastMinuteApplications.UseCompatibleStateImageBehavior = false;
            // 
            // DelayedServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 642);
            this.Controls.Add(this.lastMinuteApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelayedServiceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DelayedServiceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lastMinuteApplications;
    }
}