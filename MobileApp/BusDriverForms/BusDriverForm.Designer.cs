
namespace Project.BusDriverForms
{
    partial class BusDriverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusDriverForm));
            this.weekScheduleButton = new System.Windows.Forms.Button();
            this.monthSalaryLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.onLeaveApplicationsButton = new System.Windows.Forms.Button();
            this.lateItineraryDeclareButton = new System.Windows.Forms.Button();
            this.incommingComplaintsButton = new System.Windows.Forms.Button();
            this.healthViolationButton = new System.Windows.Forms.Button();
            this.onLeaveApplicationPreviewButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // weekScheduleButton
            // 
            this.weekScheduleButton.Location = new System.Drawing.Point(119, 144);
            this.weekScheduleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.weekScheduleButton.Name = "weekScheduleButton";
            this.weekScheduleButton.Size = new System.Drawing.Size(273, 59);
            this.weekScheduleButton.TabIndex = 1;
            this.weekScheduleButton.Text = "Επισκόπηση εβδομαδιαίου προγράμματος";
            this.weekScheduleButton.UseVisualStyleBackColor = true;
            this.weekScheduleButton.Click += new System.EventHandler(this.WeekScheduleButton_Click);
            // 
            // monthSalaryLabel
            // 
            this.monthSalaryLabel.AutoSize = true;
            this.monthSalaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.monthSalaryLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthSalaryLabel.Location = new System.Drawing.Point(4, 15);
            this.monthSalaryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.monthSalaryLabel.Name = "monthSalaryLabel";
            this.monthSalaryLabel.Size = new System.Drawing.Size(140, 22);
            this.monthSalaryLabel.TabIndex = 9;
            this.monthSalaryLabel.Text = "Μηνιαίος μισθός";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.salaryLabel);
            this.panel1.Controls.Add(this.monthSalaryLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 104);
            this.panel1.TabIndex = 9;
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.salaryLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.salaryLabel.Location = new System.Drawing.Point(197, 52);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(115, 37);
            this.salaryLabel.TabIndex = 10;
            this.salaryLabel.Text = "- Ευρώ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(195, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // onLeaveApplicationsButton
            // 
            this.onLeaveApplicationsButton.Location = new System.Drawing.Point(119, 220);
            this.onLeaveApplicationsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.onLeaveApplicationsButton.Name = "onLeaveApplicationsButton";
            this.onLeaveApplicationsButton.Size = new System.Drawing.Size(273, 59);
            this.onLeaveApplicationsButton.TabIndex = 2;
            this.onLeaveApplicationsButton.Text = "Υποβολή αίτησης άδειας";
            this.onLeaveApplicationsButton.UseVisualStyleBackColor = true;
            this.onLeaveApplicationsButton.Click += new System.EventHandler(this.OnLeaveApplicationsButton_Click);
            // 
            // lateItineraryDeclareButton
            // 
            this.lateItineraryDeclareButton.Location = new System.Drawing.Point(119, 296);
            this.lateItineraryDeclareButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lateItineraryDeclareButton.Name = "lateItineraryDeclareButton";
            this.lateItineraryDeclareButton.Size = new System.Drawing.Size(273, 59);
            this.lateItineraryDeclareButton.TabIndex = 3;
            this.lateItineraryDeclareButton.Text = "Δήλωση καθυστέρησης δρομολογίου";
            this.lateItineraryDeclareButton.UseVisualStyleBackColor = true;
            this.lateItineraryDeclareButton.Click += new System.EventHandler(this.LateItineraryDeclareButton_Click);
            // 
            // incommingComplaintsButton
            // 
            this.incommingComplaintsButton.Location = new System.Drawing.Point(119, 372);
            this.incommingComplaintsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.incommingComplaintsButton.Name = "incommingComplaintsButton";
            this.incommingComplaintsButton.Size = new System.Drawing.Size(273, 59);
            this.incommingComplaintsButton.TabIndex = 4;
            this.incommingComplaintsButton.Text = "Παρατηρήσεις";
            this.incommingComplaintsButton.UseVisualStyleBackColor = true;
            this.incommingComplaintsButton.Click += new System.EventHandler(this.IncommingComplaintsButton_Click);
            // 
            // healthViolationButton
            // 
            this.healthViolationButton.Location = new System.Drawing.Point(119, 448);
            this.healthViolationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.healthViolationButton.Name = "healthViolationButton";
            this.healthViolationButton.Size = new System.Drawing.Size(273, 59);
            this.healthViolationButton.TabIndex = 5;
            this.healthViolationButton.Text = "Καταγγελία παραβίασης υγειονομικών πρωτοκόλλων";
            this.healthViolationButton.UseVisualStyleBackColor = true;
            this.healthViolationButton.Click += new System.EventHandler(this.HealthViolationButton_Click);
            // 
            // onLeaveApplicationPreviewButton
            // 
            this.onLeaveApplicationPreviewButton.Location = new System.Drawing.Point(119, 524);
            this.onLeaveApplicationPreviewButton.Name = "onLeaveApplicationPreviewButton";
            this.onLeaveApplicationPreviewButton.Size = new System.Drawing.Size(273, 59);
            this.onLeaveApplicationPreviewButton.TabIndex = 11;
            this.onLeaveApplicationPreviewButton.Text = "Προβολή αιτήσεων άδειας";
            this.onLeaveApplicationPreviewButton.UseVisualStyleBackColor = true;
            this.onLeaveApplicationPreviewButton.Click += new System.EventHandler(this.OnLeaveApplicationPreviewButton_Click);
            // 
            // BusDriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(509, 711);
            this.Controls.Add(this.onLeaveApplicationPreviewButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.healthViolationButton);
            this.Controls.Add(this.incommingComplaintsButton);
            this.Controls.Add(this.lateItineraryDeclareButton);
            this.Controls.Add(this.onLeaveApplicationsButton);
            this.Controls.Add(this.weekScheduleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusDriverForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Καλωσόρισες";
            this.Load += new System.EventHandler(this.BusDriverForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button weekScheduleButton;
        private System.Windows.Forms.Label monthSalaryLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label salaryLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button onLeaveApplicationsButton;
        private System.Windows.Forms.Button lateItineraryDeclareButton;
        private System.Windows.Forms.Button incommingComplaintsButton;
        private System.Windows.Forms.Button healthViolationButton;
        private System.Windows.Forms.Button onLeaveApplicationPreviewButton;
    }
}