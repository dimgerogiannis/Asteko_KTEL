
namespace ChiefForms
{
    partial class MonetaryStatsForm
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
            this.startDate = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endLabel = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.calculateButton = new System.Windows.Forms.Button();
            this.ticketIncomeLabel = new System.Windows.Forms.Label();
            this.salaryExpensesLabel = new System.Windows.Forms.Label();
            this.profitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.AutoSize = true;
            this.startDate.Location = new System.Drawing.Point(22, 18);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(180, 25);
            this.startDate.TabIndex = 0;
            this.startDate.Text = "Ημερομηνία έναρξης";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(22, 57);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(336, 31);
            this.startDateTimePicker.TabIndex = 1;
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(22, 117);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(160, 25);
            this.endLabel.TabIndex = 2;
            this.endLabel.Text = "Ημερομηνία λήξης";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(22, 145);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(336, 31);
            this.endDateTimePicker.TabIndex = 3;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(22, 196);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(139, 34);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Υπολογισμός";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ticketIncomeLabel
            // 
            this.ticketIncomeLabel.AutoSize = true;
            this.ticketIncomeLabel.Location = new System.Drawing.Point(22, 266);
            this.ticketIncomeLabel.Name = "ticketIncomeLabel";
            this.ticketIncomeLabel.Size = new System.Drawing.Size(166, 25);
            this.ticketIncomeLabel.TabIndex = 5;
            this.ticketIncomeLabel.Text = "Έσοδα εισητηρίων:";
            // 
            // salaryExpensesLabel
            // 
            this.salaryExpensesLabel.AutoSize = true;
            this.salaryExpensesLabel.Location = new System.Drawing.Point(22, 303);
            this.salaryExpensesLabel.Name = "salaryExpensesLabel";
            this.salaryExpensesLabel.Size = new System.Drawing.Size(177, 25);
            this.salaryExpensesLabel.TabIndex = 6;
            this.salaryExpensesLabel.Text = "Μισθολογικά έξοδα:";
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Location = new System.Drawing.Point(22, 340);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(66, 25);
            this.profitLabel.TabIndex = 7;
            this.profitLabel.Text = "Κέρδη:";
            // 
            // MonetaryStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(381, 375);
            this.Controls.Add(this.profitLabel);
            this.Controls.Add(this.salaryExpensesLabel);
            this.Controls.Add(this.ticketIncomeLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.startDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonetaryStatsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startDate;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label ticketIncomeLabel;
        private System.Windows.Forms.Label salaryExpensesLabel;
        private System.Windows.Forms.Label profitLabel;
    }
}