
namespace QualityManagerForms
{
    partial class ClientComplaintReviewForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameCombobox = new System.Windows.Forms.ComboBox();
            this.infoListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinaryCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(134, 25);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Όνομα οδηγού";
            // 
            // nameCombobox
            // 
            this.nameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameCombobox.FormattingEnabled = true;
            this.nameCombobox.Location = new System.Drawing.Point(12, 49);
            this.nameCombobox.Name = "nameCombobox";
            this.nameCombobox.Size = new System.Drawing.Size(446, 33);
            this.nameCombobox.TabIndex = 1;
            this.nameCombobox.SelectedIndexChanged += new System.EventHandler(this.NameCombobox_SelectedIndexChanged);
            // 
            // infoListview
            // 
            this.infoListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.infoListview.FullRowSelect = true;
            this.infoListview.HideSelection = false;
            this.infoListview.Location = new System.Drawing.Point(12, 107);
            this.infoListview.Name = "infoListview";
            this.infoListview.Size = new System.Drawing.Size(514, 248);
            this.infoListview.TabIndex = 3;
            this.infoListview.UseCompatibleStateImageBehavior = false;
            this.infoListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Κατηγορία";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Όνομα επιβάτη";
            this.columnHeader2.Width = 250;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem,
            this.disciplinaryCommentToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(326, 68);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.summaryToolStripMenuItem.Text = "Προβολή επιπλέον σχολίων";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.SummaryToolStripMenuItem_Click);
            // 
            // disciplinaryCommentToolStripMenuItem
            // 
            this.disciplinaryCommentToolStripMenuItem.Name = "disciplinaryCommentToolStripMenuItem";
            this.disciplinaryCommentToolStripMenuItem.Size = new System.Drawing.Size(325, 32);
            this.disciplinaryCommentToolStripMenuItem.Text = "Προσθήκη σχολίου επίπληξης";
            this.disciplinaryCommentToolStripMenuItem.Click += new System.EventHandler(this.DisciplinaryCommentToolStripMenuItem_Click);
            // 
            // ClientComplaintReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(538, 367);
            this.Controls.Add(this.infoListview);
            this.Controls.Add(this.nameCombobox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientComplaintReviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ClientComplaintReviewForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox nameCombobox;
        private System.Windows.Forms.ListView infoListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinaryCommentToolStripMenuItem;
    }
}