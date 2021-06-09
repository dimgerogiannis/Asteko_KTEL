
namespace Project.ClientForms
{
    partial class ClientForm
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
            this.historyPreviewButton = new System.Windows.Forms.Button();
            this.complaintButton = new System.Windows.Forms.Button();
            this.pollButton = new System.Windows.Forms.Button();
            this.myTicketsButton = new System.Windows.Forms.Button();
            this.discountApplicationButton = new System.Windows.Forms.Button();
            this.buyTicketButton = new System.Windows.Forms.Button();
            this.currentBoughtTicketsLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.myApplicationsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.currentMoneyLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.busLineInformationButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ticketReservationLastMinuteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // historyPreviewButton
            // 
            this.historyPreviewButton.Location = new System.Drawing.Point(118, 147);
            this.historyPreviewButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.historyPreviewButton.Name = "historyPreviewButton";
            this.historyPreviewButton.Size = new System.Drawing.Size(273, 44);
            this.historyPreviewButton.TabIndex = 3;
            this.historyPreviewButton.Text = "Ανασκόπηση ιστορικού";
            this.historyPreviewButton.UseVisualStyleBackColor = true;
            this.historyPreviewButton.Click += new System.EventHandler(this.HistoryPreviewButton_Click);
            // 
            // complaintButton
            // 
            this.complaintButton.BackColor = System.Drawing.SystemColors.Control;
            this.complaintButton.Location = new System.Drawing.Point(118, 489);
            this.complaintButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.complaintButton.Name = "complaintButton";
            this.complaintButton.Size = new System.Drawing.Size(273, 44);
            this.complaintButton.TabIndex = 8;
            this.complaintButton.Text = "Έκφραση παραπόνων";
            this.complaintButton.UseVisualStyleBackColor = false;
            this.complaintButton.Click += new System.EventHandler(this.ComplaintButton_Click);
            // 
            // pollButton
            // 
            this.pollButton.Location = new System.Drawing.Point(118, 432);
            this.pollButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pollButton.Name = "pollButton";
            this.pollButton.Size = new System.Drawing.Size(273, 44);
            this.pollButton.TabIndex = 7;
            this.pollButton.Text = "Συμμετοχή σε polls";
            this.pollButton.UseVisualStyleBackColor = true;
            this.pollButton.Click += new System.EventHandler(this.PollButton_Click);
            // 
            // myTicketsButton
            // 
            this.myTicketsButton.Location = new System.Drawing.Point(118, 375);
            this.myTicketsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myTicketsButton.Name = "myTicketsButton";
            this.myTicketsButton.Size = new System.Drawing.Size(273, 44);
            this.myTicketsButton.TabIndex = 6;
            this.myTicketsButton.Text = "Τα εισιτήριά μου";
            this.myTicketsButton.UseVisualStyleBackColor = true;
            this.myTicketsButton.Click += new System.EventHandler(this.MyTicketsButton_Click);
            // 
            // discountApplicationButton
            // 
            this.discountApplicationButton.Location = new System.Drawing.Point(118, 204);
            this.discountApplicationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.discountApplicationButton.Name = "discountApplicationButton";
            this.discountApplicationButton.Size = new System.Drawing.Size(273, 44);
            this.discountApplicationButton.TabIndex = 4;
            this.discountApplicationButton.Text = "Υποβολή αίτησης έκπτωσης";
            this.discountApplicationButton.UseVisualStyleBackColor = true;
            this.discountApplicationButton.Click += new System.EventHandler(this.DiscountApplicationButton_Click);
            // 
            // buyTicketButton
            // 
            this.buyTicketButton.Location = new System.Drawing.Point(118, 90);
            this.buyTicketButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buyTicketButton.Name = "buyTicketButton";
            this.buyTicketButton.Size = new System.Drawing.Size(273, 44);
            this.buyTicketButton.TabIndex = 2;
            this.buyTicketButton.Text = "Δήλωση πρόθεσης μεταφοράς";
            this.buyTicketButton.UseVisualStyleBackColor = true;
            this.buyTicketButton.Click += new System.EventHandler(this.BuyTicketButton_Click);
            // 
            // currentBoughtTicketsLabel
            // 
            this.currentBoughtTicketsLabel.AutoSize = true;
            this.currentBoughtTicketsLabel.BackColor = System.Drawing.SystemColors.Highlight;
            this.currentBoughtTicketsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.currentBoughtTicketsLabel.Location = new System.Drawing.Point(150, 22);
            this.currentBoughtTicketsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentBoughtTicketsLabel.Name = "currentBoughtTicketsLabel";
            this.currentBoughtTicketsLabel.Size = new System.Drawing.Size(209, 25);
            this.currentBoughtTicketsLabel.TabIndex = 1;
            this.currentBoughtTicketsLabel.Text = "Αγορασμένα εισιτηρία: -";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.moneyLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.moneyLabel.Location = new System.Drawing.Point(4, 15);
            this.moneyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(210, 26);
            this.moneyLabel.TabIndex = 9;
            this.moneyLabel.Text = "Χρηματικό υπόλοιπο";
            // 
            // myApplicationsButton
            // 
            this.myApplicationsButton.Location = new System.Drawing.Point(118, 261);
            this.myApplicationsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myApplicationsButton.Name = "myApplicationsButton";
            this.myApplicationsButton.Size = new System.Drawing.Size(273, 44);
            this.myApplicationsButton.TabIndex = 5;
            this.myApplicationsButton.Text = "Οι αιτήσεις μου";
            this.myApplicationsButton.UseVisualStyleBackColor = true;
            this.myApplicationsButton.Click += new System.EventHandler(this.MyApplicationsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.currentMoneyLabel);
            this.panel1.Controls.Add(this.moneyLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 104);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(382, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 104);
            this.panel2.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::MobileApp.Properties.Resources.plus2;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // currentMoneyLabel
            // 
            this.currentMoneyLabel.AutoSize = true;
            this.currentMoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentMoneyLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentMoneyLabel.Location = new System.Drawing.Point(12, 55);
            this.currentMoneyLabel.Name = "currentMoneyLabel";
            this.currentMoneyLabel.Size = new System.Drawing.Size(115, 37);
            this.currentMoneyLabel.TabIndex = 10;
            this.currentMoneyLabel.Text = "- Ευρώ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MobileApp.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // busLineInformationButton
            // 
            this.busLineInformationButton.Location = new System.Drawing.Point(118, 546);
            this.busLineInformationButton.Name = "busLineInformationButton";
            this.busLineInformationButton.Size = new System.Drawing.Size(273, 44);
            this.busLineInformationButton.TabIndex = 11;
            this.busLineInformationButton.Text = "Πληροφορίες γραμμών";
            this.busLineInformationButton.UseVisualStyleBackColor = true;
            this.busLineInformationButton.Click += new System.EventHandler(this.BusLineInformationButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(118, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 70);
            this.panel3.TabIndex = 12;
            // 
            // ticketReservationLastMinuteButton
            // 
            this.ticketReservationLastMinuteButton.Location = new System.Drawing.Point(118, 318);
            this.ticketReservationLastMinuteButton.Name = "ticketReservationLastMinuteButton";
            this.ticketReservationLastMinuteButton.Size = new System.Drawing.Size(273, 44);
            this.ticketReservationLastMinuteButton.TabIndex = 13;
            this.ticketReservationLastMinuteButton.Text = "Κρατήσεις-Αιτήματα";
            this.ticketReservationLastMinuteButton.UseVisualStyleBackColor = true;
            this.ticketReservationLastMinuteButton.Click += new System.EventHandler(this.TicketReservationLastMinuteButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(509, 711);
            this.Controls.Add(this.ticketReservationLastMinuteButton);
            this.Controls.Add(this.currentBoughtTicketsLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.busLineInformationButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myApplicationsButton);
            this.Controls.Add(this.historyPreviewButton);
            this.Controls.Add(this.complaintButton);
            this.Controls.Add(this.pollButton);
            this.Controls.Add(this.myTicketsButton);
            this.Controls.Add(this.discountApplicationButton);
            this.Controls.Add(this.buyTicketButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Καλωσόρισες";
            this.Load += new System.EventHandler(this.Client_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button historyPreviewButton;
        private System.Windows.Forms.Button complaintButton;
        private System.Windows.Forms.Button pollButton;
        private System.Windows.Forms.Button myTicketsButton;
        private System.Windows.Forms.Button discountApplicationButton;
        private System.Windows.Forms.Button buyTicketButton;
        private System.Windows.Forms.Label currentBoughtTicketsLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Button myApplicationsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label currentMoneyLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button busLineInformationButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ticketReservationLastMinuteButton;
    }
}