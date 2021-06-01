
namespace ChiefForms
{
    partial class ComplaintHistory
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
            this.complaintsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.fireButton = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // complaintsListview
            // 
            this.complaintsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.complaintsListview.FullRowSelect = true;
            this.complaintsListview.HideSelection = false;
            this.complaintsListview.Location = new System.Drawing.Point(12, 12);
            this.complaintsListview.Name = "complaintsListview";
            this.complaintsListview.Size = new System.Drawing.Size(762, 335);
            this.complaintsListview.TabIndex = 0;
            this.complaintsListview.UseCompatibleStateImageBehavior = false;
            this.complaintsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Όνομα χρήστη οδηγού";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Κατηγορία";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Όνομα χρήστη επιβάτη";
            this.columnHeader3.Width = 250;
            // 
            // fireButton
            // 
            this.fireButton.Location = new System.Drawing.Point(12, 353);
            this.fireButton.Name = "fireButton";
            this.fireButton.Size = new System.Drawing.Size(175, 34);
            this.fireButton.TabIndex = 1;
            this.fireButton.Text = "Απόλυση οδηγού";
            this.fireButton.UseVisualStyleBackColor = true;
            this.fireButton.Click += new System.EventHandler(this.FireButton_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reasonToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(259, 36);
            // 
            // reasonToolStripMenuItem
            // 
            this.reasonToolStripMenuItem.Name = "reasonToolStripMenuItem";
            this.reasonToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
            this.reasonToolStripMenuItem.Text = "Προβολή αιτιολογίας";
            this.reasonToolStripMenuItem.Click += new System.EventHandler(this.ReasonToolStripMenuItem_Click);
            // 
            // ComplaintHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(786, 394);
            this.Controls.Add(this.fireButton);
            this.Controls.Add(this.complaintsListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComplaintHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ComplaintHistory_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView complaintsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button fireButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reasonToolStripMenuItem;
    }
}