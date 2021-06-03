
namespace Project.ClientForms
{
    partial class BuyTicketForm
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
            this.buyTicketButton = new System.Windows.Forms.Button();
            this.timeCombobox = new System.Windows.Forms.ComboBox();
            this.lineNumberCombobox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dayLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buyTicketButton
            // 
            this.buyTicketButton.Location = new System.Drawing.Point(15, 277);
            this.buyTicketButton.Margin = new System.Windows.Forms.Padding(6);
            this.buyTicketButton.Name = "buyTicketButton";
            this.buyTicketButton.Size = new System.Drawing.Size(170, 40);
            this.buyTicketButton.TabIndex = 20;
            this.buyTicketButton.Text = "Αγορά εισιτηρίου";
            this.buyTicketButton.UseVisualStyleBackColor = true;
            this.buyTicketButton.Click += new System.EventHandler(this.BuyTicketButton_Click);
            // 
            // timeCombobox
            // 
            this.timeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeCombobox.FormattingEnabled = true;
            this.timeCombobox.Location = new System.Drawing.Point(16, 132);
            this.timeCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.timeCombobox.Name = "timeCombobox";
            this.timeCombobox.Size = new System.Drawing.Size(144, 33);
            this.timeCombobox.TabIndex = 19;
            // 
            // lineNumberCombobox
            // 
            this.lineNumberCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineNumberCombobox.FormattingEnabled = true;
            this.lineNumberCombobox.Location = new System.Drawing.Point(16, 51);
            this.lineNumberCombobox.Margin = new System.Windows.Forms.Padding(6);
            this.lineNumberCombobox.Name = "lineNumberCombobox";
            this.lineNumberCombobox.Size = new System.Drawing.Size(80, 33);
            this.lineNumberCombobox.TabIndex = 18;
            this.lineNumberCombobox.SelectedValueChanged += new System.EventHandler(this.LineNumberCombobox_SelectedValueChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(16, 217);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(341, 31);
            this.dateTimePicker.TabIndex = 17;
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(16, 186);
            this.dayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(65, 25);
            this.dayLabel.TabIndex = 16;
            this.dayLabel.Text = "Ημέρα";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(16, 101);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(49, 25);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.Text = "Ώρα";
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(15, 20);
            this.lineNumberLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(154, 25);
            this.lineNumberLabel.TabIndex = 14;
            this.lineNumberLabel.Text = "Αριθμός γραμμής";
            // 
            // BuyTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.buyTicketButton);
            this.Controls.Add(this.timeCombobox);
            this.Controls.Add(this.lineNumberCombobox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.lineNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuyTicketForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BuyTicketForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyTicketButton;
        private System.Windows.Forms.ComboBox timeCombobox;
        private System.Windows.Forms.ComboBox lineNumberCombobox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label lineNumberLabel;
    }
}