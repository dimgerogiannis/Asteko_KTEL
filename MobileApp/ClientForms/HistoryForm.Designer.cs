
namespace Project.ClientForms
{
    partial class HistoryForm
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
            this.fromDatetimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDatetimePicker = new System.Windows.Forms.DateTimePicker();
            this.startingDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.historyListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.totalTicketCostLabel = new System.Windows.Forms.Label();
            this.ticketNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromDatetimePicker
            // 
            this.fromDatetimePicker.Location = new System.Drawing.Point(12, 44);
            this.fromDatetimePicker.Name = "fromDatetimePicker";
            this.fromDatetimePicker.Size = new System.Drawing.Size(488, 31);
            this.fromDatetimePicker.TabIndex = 0;
            this.fromDatetimePicker.ValueChanged += new System.EventHandler(this.FromDatetimePicker_ValueChanged);
            // 
            // ToDatetimePicker
            // 
            this.ToDatetimePicker.Location = new System.Drawing.Point(12, 119);
            this.ToDatetimePicker.Name = "ToDatetimePicker";
            this.ToDatetimePicker.Size = new System.Drawing.Size(488, 31);
            this.ToDatetimePicker.TabIndex = 1;
            this.ToDatetimePicker.ValueChanged += new System.EventHandler(this.ToDatetimePicker_ValueChanged);
            // 
            // startingDateLabel
            // 
            this.startingDateLabel.AutoSize = true;
            this.startingDateLabel.Location = new System.Drawing.Point(12, 16);
            this.startingDateLabel.Name = "startingDateLabel";
            this.startingDateLabel.Size = new System.Drawing.Size(169, 25);
            this.startingDateLabel.TabIndex = 2;
            this.startingDateLabel.Text = "Αρχική ημερομηνία";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Τελική ημερομηνία";
            // 
            // historyListview
            // 
            this.historyListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.historyListview.FullRowSelect = true;
            this.historyListview.HideSelection = false;
            this.historyListview.Location = new System.Drawing.Point(12, 169);
            this.historyListview.Name = "historyListview";
            this.historyListview.Size = new System.Drawing.Size(488, 411);
            this.historyListview.TabIndex = 3;
            this.historyListview.UseCompatibleStateImageBehavior = false;
            this.historyListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ημερομηνία αγοράς";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Τιμή";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Γραμμή";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ημερομηνία δρομολογίου";
            this.columnHeader4.Width = 190;
            // 
            // totalTicketCostLabel
            // 
            this.totalTicketCostLabel.AutoSize = true;
            this.totalTicketCostLabel.Location = new System.Drawing.Point(12, 629);
            this.totalTicketCostLabel.Name = "totalTicketCostLabel";
            this.totalTicketCostLabel.Size = new System.Drawing.Size(244, 25);
            this.totalTicketCostLabel.TabIndex = 5;
            this.totalTicketCostLabel.Text = "Συνολικό κόστος εισιτηρίων:";
            // 
            // ticketNumber
            // 
            this.ticketNumber.AutoSize = true;
            this.ticketNumber.Location = new System.Drawing.Point(12, 594);
            this.ticketNumber.Name = "ticketNumber";
            this.ticketNumber.Size = new System.Drawing.Size(170, 25);
            this.ticketNumber.TabIndex = 6;
            this.ticketNumber.Text = "Πλήθος εισιτηρίων:";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(512, 668);
            this.Controls.Add(this.ticketNumber);
            this.Controls.Add(this.totalTicketCostLabel);
            this.Controls.Add(this.historyListview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startingDateLabel);
            this.Controls.Add(this.ToDatetimePicker);
            this.Controls.Add(this.fromDatetimePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDatetimePicker;
        private System.Windows.Forms.DateTimePicker ToDatetimePicker;
        private System.Windows.Forms.Label startingDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView historyListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label totalTicketCostLabel;
        private System.Windows.Forms.Label ticketNumber;
    }
}