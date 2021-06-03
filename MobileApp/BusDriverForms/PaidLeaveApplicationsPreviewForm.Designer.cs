
namespace Project.BusDriverForms
{
    partial class PaidLeaveApplicationsPreviewForm
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
            this.paidLeaveApplicationsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rejectionReasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // paidLeaveApplicationsListview
            // 
            this.paidLeaveApplicationsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.paidLeaveApplicationsListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paidLeaveApplicationsListview.FullRowSelect = true;
            this.paidLeaveApplicationsListview.HideSelection = false;
            this.paidLeaveApplicationsListview.Location = new System.Drawing.Point(0, 0);
            this.paidLeaveApplicationsListview.Name = "paidLeaveApplicationsListview";
            this.paidLeaveApplicationsListview.Size = new System.Drawing.Size(513, 715);
            this.paidLeaveApplicationsListview.TabIndex = 0;
            this.paidLeaveApplicationsListview.UseCompatibleStateImageBehavior = false;
            this.paidLeaveApplicationsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ημερομηνία άδειας";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Κατάσταση";
            this.columnHeader2.Width = 200;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rejectionReasonToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(312, 101);
            // 
            // rejectionReasonToolStripMenuItem
            // 
            this.rejectionReasonToolStripMenuItem.Name = "rejectionReasonToolStripMenuItem";
            this.rejectionReasonToolStripMenuItem.Size = new System.Drawing.Size(311, 32);
            this.rejectionReasonToolStripMenuItem.Text = "Προβολή λόγου απόρριψης";
            this.rejectionReasonToolStripMenuItem.Click += new System.EventHandler(this.RejectionReasonToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(311, 32);
            this.deleteToolStripMenuItem.Text = "Διαγραφή από ιστορικό";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // PaidLeaveApplicationsPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(513, 715);
            this.Controls.Add(this.paidLeaveApplicationsListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaidLeaveApplicationsPreviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PaidLeaveApplicationsPreviewForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView paidLeaveApplicationsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rejectionReasonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}