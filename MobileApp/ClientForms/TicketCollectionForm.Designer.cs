
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
            this.SuspendLayout();
            // 
            // ticketCollectionListview
            // 
            this.ticketCollectionListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.ticketCollectionListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketCollectionListview.FullRowSelect = true;
            this.ticketCollectionListview.HideSelection = false;
            this.ticketCollectionListview.Location = new System.Drawing.Point(0, 0);
            this.ticketCollectionListview.Margin = new System.Windows.Forms.Padding(2);
            this.ticketCollectionListview.Name = "ticketCollectionListview";
            this.ticketCollectionListview.Size = new System.Drawing.Size(508, 711);
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
            // TicketCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
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

        }

        #endregion

        private System.Windows.Forms.ListView ticketCollectionListview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}