
namespace Project.ClientForms
{
    partial class BusLineInformationForm
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
            this.busLineListComboBox = new System.Windows.Forms.ComboBox();
            this.busLineNumberLabel = new System.Windows.Forms.Label();
            this.busLineStopsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.busLineAvailableItineraryTimeListview = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.durationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // busLineListComboBox
            // 
            this.busLineListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busLineListComboBox.FormattingEnabled = true;
            this.busLineListComboBox.Location = new System.Drawing.Point(12, 52);
            this.busLineListComboBox.Name = "busLineListComboBox";
            this.busLineListComboBox.Size = new System.Drawing.Size(154, 33);
            this.busLineListComboBox.TabIndex = 0;
            this.busLineListComboBox.SelectedValueChanged += new System.EventHandler(this.BusLineListComboBox_SelectedValueChanged);
            // 
            // busLineNumberLabel
            // 
            this.busLineNumberLabel.AutoSize = true;
            this.busLineNumberLabel.Location = new System.Drawing.Point(12, 24);
            this.busLineNumberLabel.Name = "busLineNumberLabel";
            this.busLineNumberLabel.Size = new System.Drawing.Size(154, 25);
            this.busLineNumberLabel.TabIndex = 1;
            this.busLineNumberLabel.Text = "Αριθμός γραμμής";
            // 
            // busLineStopsListview
            // 
            this.busLineStopsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.busLineStopsListview.FullRowSelect = true;
            this.busLineStopsListview.HideSelection = false;
            this.busLineStopsListview.Location = new System.Drawing.Point(12, 102);
            this.busLineStopsListview.Name = "busLineStopsListview";
            this.busLineStopsListview.Size = new System.Drawing.Size(488, 190);
            this.busLineStopsListview.TabIndex = 2;
            this.busLineStopsListview.UseCompatibleStateImageBehavior = false;
            this.busLineStopsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Όνομα στάσης";
            this.columnHeader1.Width = 400;
            // 
            // busLineAvailableItineraryTimeListview
            // 
            this.busLineAvailableItineraryTimeListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.busLineAvailableItineraryTimeListview.FullRowSelect = true;
            this.busLineAvailableItineraryTimeListview.HideSelection = false;
            this.busLineAvailableItineraryTimeListview.Location = new System.Drawing.Point(12, 321);
            this.busLineAvailableItineraryTimeListview.Name = "busLineAvailableItineraryTimeListview";
            this.busLineAvailableItineraryTimeListview.Size = new System.Drawing.Size(488, 187);
            this.busLineAvailableItineraryTimeListview.TabIndex = 2;
            this.busLineAvailableItineraryTimeListview.UseCompatibleStateImageBehavior = false;
            this.busLineAvailableItineraryTimeListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Διαθέσιμες ώρες";
            this.columnHeader2.Width = 400;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(12, 531);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(162, 25);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "Διάρκεια γραμμής:";
            // 
            // BusLineInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 715);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.busLineAvailableItineraryTimeListview);
            this.Controls.Add(this.busLineStopsListview);
            this.Controls.Add(this.busLineNumberLabel);
            this.Controls.Add(this.busLineListComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BusLineInformationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BusLineInformationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox busLineListComboBox;
        private System.Windows.Forms.Label busLineNumberLabel;
        private System.Windows.Forms.ListView busLineStopsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView busLineAvailableItineraryTimeListview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label durationLabel;
    }
}