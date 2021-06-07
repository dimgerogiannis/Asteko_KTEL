
namespace DistributorForms
{
    partial class DelayedServiceForm
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
            this.lastMinuteListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.recommendedBusesListview = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.programmingButton = new System.Windows.Forms.Button();
            this.recommendedDriversListview = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lastMinuteListview
            // 
            this.lastMinuteListview.CheckBoxes = true;
            this.lastMinuteListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lastMinuteListview.FullRowSelect = true;
            this.lastMinuteListview.HideSelection = false;
            this.lastMinuteListview.Location = new System.Drawing.Point(12, 12);
            this.lastMinuteListview.Name = "lastMinuteListview";
            this.lastMinuteListview.Size = new System.Drawing.Size(933, 362);
            this.lastMinuteListview.TabIndex = 0;
            this.lastMinuteListview.UseCompatibleStateImageBehavior = false;
            this.lastMinuteListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ημερομηνία υποβολής";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ημερομηνία δρομολογίου";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Γραμμή";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ονοματαεπώνυμο επιβάτη";
            this.columnHeader4.Width = 300;
            // 
            // recommendedBusesListview
            // 
            this.recommendedBusesListview.CheckBoxes = true;
            this.recommendedBusesListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.recommendedBusesListview.FullRowSelect = true;
            this.recommendedBusesListview.HideSelection = false;
            this.recommendedBusesListview.Location = new System.Drawing.Point(476, 442);
            this.recommendedBusesListview.Name = "recommendedBusesListview";
            this.recommendedBusesListview.Size = new System.Drawing.Size(469, 179);
            this.recommendedBusesListview.TabIndex = 21;
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
            // programmingButton
            // 
            this.programmingButton.Location = new System.Drawing.Point(12, 391);
            this.programmingButton.Name = "programmingButton";
            this.programmingButton.Size = new System.Drawing.Size(186, 34);
            this.programmingButton.TabIndex = 13;
            this.programmingButton.Text = "Προγραμματισμός";
            this.programmingButton.UseVisualStyleBackColor = true;
            this.programmingButton.Click += new System.EventHandler(this.ProgrammingButton_Click);
            // 
            // recommendedDriversListview
            // 
            this.recommendedDriversListview.CheckBoxes = true;
            this.recommendedDriversListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8});
            this.recommendedDriversListview.FullRowSelect = true;
            this.recommendedDriversListview.HideSelection = false;
            this.recommendedDriversListview.Location = new System.Drawing.Point(12, 442);
            this.recommendedDriversListview.Name = "recommendedDriversListview";
            this.recommendedDriversListview.Size = new System.Drawing.Size(458, 179);
            this.recommendedDriversListview.TabIndex = 20;
            this.recommendedDriversListview.UseCompatibleStateImageBehavior = false;
            this.recommendedDriversListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Όνομα οδηγού";
            this.columnHeader5.Width = 220;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Διαθέσιμα λεπτά εργασίας";
            this.columnHeader8.Width = 230;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 627);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(189, 34);
            this.createButton.TabIndex = 24;
            this.createButton.Text = "Δημιουργία";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DelayedServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(957, 670);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.recommendedBusesListview);
            this.Controls.Add(this.programmingButton);
            this.Controls.Add(this.recommendedDriversListview);
            this.Controls.Add(this.lastMinuteListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelayedServiceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DelayedServiceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lastMinuteListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView recommendedBusesListview;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button programmingButton;
        private System.Windows.Forms.ListView recommendedDriversListview;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button createButton;
    }
}