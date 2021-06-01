
namespace QualityManagerForms
{
    partial class ExpiredPollsForm
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
            this.resultsListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleCombobox = new System.Windows.Forms.ComboBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultsListview
            // 
            this.resultsListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.resultsListview.FullRowSelect = true;
            this.resultsListview.HideSelection = false;
            this.resultsListview.Location = new System.Drawing.Point(12, 162);
            this.resultsListview.Name = "resultsListview";
            this.resultsListview.Size = new System.Drawing.Size(551, 240);
            this.resultsListview.TabIndex = 0;
            this.resultsListview.UseCompatibleStateImageBehavior = false;
            this.resultsListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Επιλογή";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ψήφοι";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ποσοστό";
            this.columnHeader3.Width = 100;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(189, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Τίτλος δημοσκόπησης";
            // 
            // titleCombobox
            // 
            this.titleCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleCombobox.FormattingEnabled = true;
            this.titleCombobox.Location = new System.Drawing.Point(12, 37);
            this.titleCombobox.Name = "titleCombobox";
            this.titleCombobox.Size = new System.Drawing.Size(551, 33);
            this.titleCombobox.TabIndex = 2;
            this.titleCombobox.SelectedValueChanged += new System.EventHandler(this.TitleCombobox_SelectedValueChanged);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(12, 85);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(169, 25);
            this.startLabel.TabIndex = 3;
            this.startLabel.Text = "Ημερομηνία αρχής:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(12, 120);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(164, 25);
            this.endLabel.TabIndex = 3;
            this.endLabel.Text = "Ημερομηνία λήξης:";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 408);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Προσθήκη";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ExpiredPollsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(575, 453);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.titleCombobox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.resultsListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpiredPollsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PollResultsPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resultsListview;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox titleCombobox;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button submitButton;
    }
}