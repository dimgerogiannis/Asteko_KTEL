
namespace ChiefForms
{
    partial class PaidLeaveRequestsForm
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
            this.components = new System.ComponentModel.Container();
            this.applicationsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptOrRejectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationsListview
            // 
            this.applicationsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.applicationsListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationsListview.FullRowSelect = true;
            this.applicationsListview.HideSelection = false;
            this.applicationsListview.Location = new System.Drawing.Point(0, 0);
            this.applicationsListview.Name = "applicationsListview";
            this.applicationsListview.Size = new System.Drawing.Size(681, 496);
            this.applicationsListview.TabIndex = 0;
            this.applicationsListview.UseCompatibleStateImageBehavior = false;
            this.applicationsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Όνομα οδηγού";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ημερομηνία αίτησης";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ημερομηνία άδειας";
            this.columnHeader4.Width = 200;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reasonToolStripMenuItem,
            this.acceptOrRejectToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(259, 68);
            // 
            // reasonToolStripMenuItem
            // 
            this.reasonToolStripMenuItem.Name = "reasonToolStripMenuItem";
            this.reasonToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
            this.reasonToolStripMenuItem.Text = "Προβολή αιτιολογίας";
            this.reasonToolStripMenuItem.Click += new System.EventHandler(this.ReasonToolStripMenuItem_Click);
            // 
            // acceptOrRejectToolStripMenuItem
            // 
            this.acceptOrRejectToolStripMenuItem.Name = "acceptOrRejectToolStripMenuItem";
            this.acceptOrRejectToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
            this.acceptOrRejectToolStripMenuItem.Text = "Έγκριση/απόρριψη";
            this.acceptOrRejectToolStripMenuItem.Click += new System.EventHandler(this.AcceptOrRejectToolStripMenuItem_Click);
            // 
            // PaidLeaveRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(681, 496);
            this.Controls.Add(this.applicationsListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaidLeaveRequestsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PaidLeaveRequestsForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView applicationsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reasonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acceptOrRejectToolStripMenuItem;
    }
}