
namespace Project.ClientForms
{
    partial class TicketCollectionForm
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
            this.ticketCollectionListview = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.allTicketsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.allMyTicketsLabel = new System.Windows.Forms.Label();
            this.usableTickets = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ticketCollectionListview
            // 
            this.ticketCollectionListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.ticketCollectionListview.FullRowSelect = true;
            this.ticketCollectionListview.HideSelection = false;
            this.ticketCollectionListview.Location = new System.Drawing.Point(11, 40);
            this.ticketCollectionListview.Margin = new System.Windows.Forms.Padding(2);
            this.ticketCollectionListview.Name = "ticketCollectionListview";
            this.ticketCollectionListview.Size = new System.Drawing.Size(486, 166);
            this.ticketCollectionListview.TabIndex = 0;
            this.ticketCollectionListview.UseCompatibleStateImageBehavior = false;
            this.ticketCollectionListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ημερομηνία δρομολογίου";
            this.columnHeader2.Width = 270;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Γραμμή";
            this.columnHeader3.Width = 120;
            // 
            // allTicketsListview
            // 
            this.allTicketsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4});
            this.allTicketsListview.FullRowSelect = true;
            this.allTicketsListview.HideSelection = false;
            this.allTicketsListview.Location = new System.Drawing.Point(11, 262);
            this.allTicketsListview.Name = "allTicketsListview";
            this.allTicketsListview.Size = new System.Drawing.Size(486, 437);
            this.allTicketsListview.TabIndex = 1;
            this.allTicketsListview.UseCompatibleStateImageBehavior = false;
            this.allTicketsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ημερομηνία δρομολογίου";
            this.columnHeader1.Width = 270;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Γραμμή";
            this.columnHeader4.Width = 120;
            // 
            // allMyTicketsLabel
            // 
            this.allMyTicketsLabel.AutoSize = true;
            this.allMyTicketsLabel.Location = new System.Drawing.Point(11, 234);
            this.allMyTicketsLabel.Name = "allMyTicketsLabel";
            this.allMyTicketsLabel.Size = new System.Drawing.Size(186, 25);
            this.allMyTicketsLabel.TabIndex = 2;
            this.allMyTicketsLabel.Text = "Όλα τα εισιτήριά μου";
            // 
            // usableTickets
            // 
            this.usableTickets.AutoSize = true;
            this.usableTickets.Location = new System.Drawing.Point(11, 9);
            this.usableTickets.Name = "usableTickets";
            this.usableTickets.Size = new System.Drawing.Size(232, 25);
            this.usableTickets.TabIndex = 3;
            this.usableTickets.Text = "Χρησιμοποιήσιμα εισιτήρια";
            // 
            // TicketCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.usableTickets);
            this.Controls.Add(this.allMyTicketsLabel);
            this.Controls.Add(this.allTicketsListview);
            this.Controls.Add(this.ticketCollectionListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketCollectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FutureTickets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ticketCollectionListview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView allTicketsListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label allMyTicketsLabel;
        private System.Windows.Forms.Label usableTickets;
    }
}