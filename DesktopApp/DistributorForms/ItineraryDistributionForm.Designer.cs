
namespace DistributorForms
{
    partial class ItineraryDistributionForm
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
            this.rereservationsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.programmingButton = new System.Windows.Forms.Button();
            this.busLineNumberLabel = new System.Windows.Forms.Label();
            this.busLineNumberCombobox = new System.Windows.Forms.ComboBox();
            this.availableStartingHoursLabel = new System.Windows.Forms.Label();
            this.availableStartingHoursCombobox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.recommendedDriversListview = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.recommendedBusesListview = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeCombobox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createItineraryButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rereservationsListview
            // 
            this.rereservationsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.rereservationsListview.FullRowSelect = true;
            this.rereservationsListview.HideSelection = false;
            this.rereservationsListview.Location = new System.Drawing.Point(14, 12);
            this.rereservationsListview.Name = "rereservationsListview";
            this.rereservationsListview.Size = new System.Drawing.Size(922, 353);
            this.rereservationsListview.TabIndex = 0;
            this.rereservationsListview.UseCompatibleStateImageBehavior = false;
            this.rereservationsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ημερομηνία";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Γραμμή";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Αριθμός κρατήσεων";
            this.columnHeader3.Width = 200;
            // 
            // programmingButton
            // 
            this.programmingButton.Location = new System.Drawing.Point(17, 711);
            this.programmingButton.Name = "programmingButton";
            this.programmingButton.Size = new System.Drawing.Size(186, 34);
            this.programmingButton.TabIndex = 1;
            this.programmingButton.Text = "Προγραμματισμός";
            this.programmingButton.UseVisualStyleBackColor = true;
            this.programmingButton.Click += new System.EventHandler(this.ProgrammingButton_Click);
            // 
            // busLineNumberLabel
            // 
            this.busLineNumberLabel.AutoSize = true;
            this.busLineNumberLabel.Location = new System.Drawing.Point(17, 393);
            this.busLineNumberLabel.Name = "busLineNumberLabel";
            this.busLineNumberLabel.Size = new System.Drawing.Size(154, 25);
            this.busLineNumberLabel.TabIndex = 2;
            this.busLineNumberLabel.Text = "Αριθμός γραμμής";
            // 
            // busLineNumberCombobox
            // 
            this.busLineNumberCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busLineNumberCombobox.FormattingEnabled = true;
            this.busLineNumberCombobox.Location = new System.Drawing.Point(17, 421);
            this.busLineNumberCombobox.Name = "busLineNumberCombobox";
            this.busLineNumberCombobox.Size = new System.Drawing.Size(154, 33);
            this.busLineNumberCombobox.TabIndex = 3;
            this.busLineNumberCombobox.SelectedIndexChanged += new System.EventHandler(this.BusLineNumberCombobox_SelectedIndexChanged);
            this.busLineNumberCombobox.SelectedValueChanged += new System.EventHandler(this.BusLineNumberCombobox_SelectedValueChanged);
            // 
            // availableStartingHoursLabel
            // 
            this.availableStartingHoursLabel.AutoSize = true;
            this.availableStartingHoursLabel.Location = new System.Drawing.Point(14, 472);
            this.availableStartingHoursLabel.Name = "availableStartingHoursLabel";
            this.availableStartingHoursLabel.Size = new System.Drawing.Size(331, 25);
            this.availableStartingHoursLabel.TabIndex = 4;
            this.availableStartingHoursLabel.Text = "Διαθέσιμες ώρες έναρξης δρομολογίου";
            // 
            // availableStartingHoursCombobox
            // 
            this.availableStartingHoursCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availableStartingHoursCombobox.FormattingEnabled = true;
            this.availableStartingHoursCombobox.Location = new System.Drawing.Point(17, 500);
            this.availableStartingHoursCombobox.Name = "availableStartingHoursCombobox";
            this.availableStartingHoursCombobox.Size = new System.Drawing.Size(154, 33);
            this.availableStartingHoursCombobox.TabIndex = 5;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(17, 557);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(224, 25);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "Ημερομηνία δρομολογίου";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(17, 585);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(331, 31);
            this.dateTimePicker.TabIndex = 8;
            // 
            // recommendedDriversListview
            // 
            this.recommendedDriversListview.CheckBoxes = true;
            this.recommendedDriversListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.recommendedDriversListview.FullRowSelect = true;
            this.recommendedDriversListview.HideSelection = false;
            this.recommendedDriversListview.Location = new System.Drawing.Point(14, 763);
            this.recommendedDriversListview.Name = "recommendedDriversListview";
            this.recommendedDriversListview.Size = new System.Drawing.Size(458, 179);
            this.recommendedDriversListview.TabIndex = 9;
            this.recommendedDriversListview.UseCompatibleStateImageBehavior = false;
            this.recommendedDriversListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Όνομα οδηγού";
            this.columnHeader4.Width = 220;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Διαθέσιμα λεπτά εργασίας";
            this.columnHeader5.Width = 230;
            // 
            // recommendedBusesListview
            // 
            this.recommendedBusesListview.CheckBoxes = true;
            this.recommendedBusesListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.recommendedBusesListview.FullRowSelect = true;
            this.recommendedBusesListview.HideSelection = false;
            this.recommendedBusesListview.Location = new System.Drawing.Point(478, 763);
            this.recommendedBusesListview.Name = "recommendedBusesListview";
            this.recommendedBusesListview.Size = new System.Drawing.Size(458, 179);
            this.recommendedBusesListview.TabIndex = 10;
            this.recommendedBusesListview.UseCompatibleStateImageBehavior = false;
            this.recommendedBusesListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Αναγνωριστικό λεωφωρείου";
            this.columnHeader6.Width = 250;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Πλήθος θέσεων";
            this.columnHeader7.Width = 200;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(17, 633);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(189, 25);
            this.sizeLabel.TabIndex = 11;
            this.sizeLabel.Text = "Μέγεθος λεωφορείου";
            // 
            // sizeCombobox
            // 
            this.sizeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCombobox.FormattingEnabled = true;
            this.sizeCombobox.Location = new System.Drawing.Point(17, 661);
            this.sizeCombobox.Name = "sizeCombobox";
            this.sizeCombobox.Size = new System.Drawing.Size(193, 33);
            this.sizeCombobox.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.createItineraryButton);
            this.panel1.Controls.Add(this.recommendedBusesListview);
            this.panel1.Controls.Add(this.programmingButton);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.rereservationsListview);
            this.panel1.Controls.Add(this.dateLabel);
            this.panel1.Controls.Add(this.sizeCombobox);
            this.panel1.Controls.Add(this.availableStartingHoursCombobox);
            this.panel1.Controls.Add(this.sizeLabel);
            this.panel1.Controls.Add(this.availableStartingHoursLabel);
            this.panel1.Controls.Add(this.recommendedDriversListview);
            this.panel1.Controls.Add(this.busLineNumberCombobox);
            this.panel1.Controls.Add(this.busLineNumberLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 998);
            this.panel1.TabIndex = 13;
            // 
            // createItineraryButton
            // 
            this.createItineraryButton.Location = new System.Drawing.Point(14, 948);
            this.createItineraryButton.Name = "createItineraryButton";
            this.createItineraryButton.Size = new System.Drawing.Size(125, 34);
            this.createItineraryButton.TabIndex = 13;
            this.createItineraryButton.Text = "Δημιουργία";
            this.createItineraryButton.UseVisualStyleBackColor = true;
            this.createItineraryButton.Click += new System.EventHandler(this.CreateItineraryButton_Click);
            // 
            // ItineraryDistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(957, 1006);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItineraryDistributionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ItineraryDistributionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView rereservationsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button programmingButton;
        private System.Windows.Forms.Label busLineNumberLabel;
        private System.Windows.Forms.ComboBox busLineNumberCombobox;
        private System.Windows.Forms.Label availableStartingHoursLabel;
        private System.Windows.Forms.ComboBox availableStartingHoursCombobox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ListView recommendedDriversListview;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView recommendedBusesListview;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ComboBox sizeCombobox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button createItineraryButton;
    }
}