
namespace ChiefForms
{
    partial class DriverDismissalForm
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
            this.busDriverUsernameLabel = new System.Windows.Forms.Label();
            this.busDriverNameCombobox = new System.Windows.Forms.ComboBox();
            this.historyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // busDriverUsernameLabel
            // 
            this.busDriverUsernameLabel.AutoSize = true;
            this.busDriverUsernameLabel.Location = new System.Drawing.Point(12, 20);
            this.busDriverUsernameLabel.Name = "busDriverUsernameLabel";
            this.busDriverUsernameLabel.Size = new System.Drawing.Size(199, 25);
            this.busDriverUsernameLabel.TabIndex = 0;
            this.busDriverUsernameLabel.Text = "Όνομα χρήστη οδηγού";
            // 
            // busDriverNameCombobox
            // 
            this.busDriverNameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busDriverNameCombobox.FormattingEnabled = true;
            this.busDriverNameCombobox.Location = new System.Drawing.Point(12, 48);
            this.busDriverNameCombobox.Name = "busDriverNameCombobox";
            this.busDriverNameCombobox.Size = new System.Drawing.Size(347, 33);
            this.busDriverNameCombobox.TabIndex = 1;
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(12, 97);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(194, 39);
            this.historyButton.TabIndex = 2;
            this.historyButton.Text = "Προβολή ιστορικού";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // DriverDismissalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(371, 156);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.busDriverNameCombobox);
            this.Controls.Add(this.busDriverUsernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverDismissalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DriverDismissalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label busDriverUsernameLabel;
        private System.Windows.Forms.ComboBox busDriverNameCombobox;
        private System.Windows.Forms.Button historyButton;
    }
}