
namespace ClientForms
{
    partial class TicketReservationLastMinuteRequestsForm
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
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryCombobox = new System.Windows.Forms.ComboBox();
            this.infoListview = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(12, 22);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(99, 25);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = "Κατηγορία";
            // 
            // categoryCombobox
            // 
            this.categoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCombobox.FormattingEnabled = true;
            this.categoryCombobox.Location = new System.Drawing.Point(12, 50);
            this.categoryCombobox.Name = "categoryCombobox";
            this.categoryCombobox.Size = new System.Drawing.Size(488, 33);
            this.categoryCombobox.TabIndex = 1;
            this.categoryCombobox.SelectedIndexChanged += new System.EventHandler(this.CategoryCombobox_SelectedIndexChanged);
            // 
            // infoListview
            // 
            this.infoListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.infoListview.FullRowSelect = true;
            this.infoListview.HideSelection = false;
            this.infoListview.Location = new System.Drawing.Point(12, 98);
            this.infoListview.Name = "infoListview";
            this.infoListview.Size = new System.Drawing.Size(488, 605);
            this.infoListview.TabIndex = 2;
            this.infoListview.UseCompatibleStateImageBehavior = false;
            this.infoListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ημερομηνία ταξιδιού";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Γραμμή";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Κατάσταση";
            this.columnHeader4.Width = 150;
            // 
            // TicketReservationLastMinuteRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(512, 715);
            this.Controls.Add(this.infoListview);
            this.Controls.Add(this.categoryCombobox);
            this.Controls.Add(this.categoryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketReservationLastMinuteRequestsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TicketReservationLastMinuteRequestsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryCombobox;
        private System.Windows.Forms.ListView infoListview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}