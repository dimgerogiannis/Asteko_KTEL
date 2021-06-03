
namespace Project.ClientForms
{
    partial class PollAttendForm
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
            this.pollQuestionRichTextbox = new System.Windows.Forms.RichTextBox();
            this.firstChoiceRadioButton = new System.Windows.Forms.RadioButton();
            this.secondChoiceRadioButton = new System.Windows.Forms.RadioButton();
            this.thirdChoiceRadioButton = new System.Windows.Forms.RadioButton();
            this.forthChoiceRadioButton = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.pollTitle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pollQuestionRichTextbox
            // 
            this.pollQuestionRichTextbox.Location = new System.Drawing.Point(11, 93);
            this.pollQuestionRichTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.pollQuestionRichTextbox.Name = "pollQuestionRichTextbox";
            this.pollQuestionRichTextbox.Size = new System.Drawing.Size(483, 125);
            this.pollQuestionRichTextbox.TabIndex = 0;
            this.pollQuestionRichTextbox.Text = "";
            // 
            // firstChoiceRadioButton
            // 
            this.firstChoiceRadioButton.AutoSize = true;
            this.firstChoiceRadioButton.Location = new System.Drawing.Point(11, 235);
            this.firstChoiceRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.firstChoiceRadioButton.Name = "firstChoiceRadioButton";
            this.firstChoiceRadioButton.Size = new System.Drawing.Size(44, 29);
            this.firstChoiceRadioButton.TabIndex = 1;
            this.firstChoiceRadioButton.TabStop = true;
            this.firstChoiceRadioButton.Text = "-";
            this.firstChoiceRadioButton.UseVisualStyleBackColor = true;
            // 
            // secondChoiceRadioButton
            // 
            this.secondChoiceRadioButton.AutoSize = true;
            this.secondChoiceRadioButton.Location = new System.Drawing.Point(11, 286);
            this.secondChoiceRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.secondChoiceRadioButton.Name = "secondChoiceRadioButton";
            this.secondChoiceRadioButton.Size = new System.Drawing.Size(44, 29);
            this.secondChoiceRadioButton.TabIndex = 2;
            this.secondChoiceRadioButton.TabStop = true;
            this.secondChoiceRadioButton.Text = "-";
            this.secondChoiceRadioButton.UseVisualStyleBackColor = true;
            // 
            // thirdChoiceRadioButton
            // 
            this.thirdChoiceRadioButton.AutoSize = true;
            this.thirdChoiceRadioButton.Location = new System.Drawing.Point(11, 339);
            this.thirdChoiceRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.thirdChoiceRadioButton.Name = "thirdChoiceRadioButton";
            this.thirdChoiceRadioButton.Size = new System.Drawing.Size(44, 29);
            this.thirdChoiceRadioButton.TabIndex = 3;
            this.thirdChoiceRadioButton.TabStop = true;
            this.thirdChoiceRadioButton.Text = "-";
            this.thirdChoiceRadioButton.UseVisualStyleBackColor = true;
            // 
            // forthChoiceRadioButton
            // 
            this.forthChoiceRadioButton.AutoSize = true;
            this.forthChoiceRadioButton.Location = new System.Drawing.Point(11, 391);
            this.forthChoiceRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.forthChoiceRadioButton.Name = "forthChoiceRadioButton";
            this.forthChoiceRadioButton.Size = new System.Drawing.Size(44, 29);
            this.forthChoiceRadioButton.TabIndex = 4;
            this.forthChoiceRadioButton.TabStop = true;
            this.forthChoiceRadioButton.Text = "-";
            this.forthChoiceRadioButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(11, 442);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(124, 36);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Υποβολή";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // pollTitle
            // 
            this.pollTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pollTitle.FormattingEnabled = true;
            this.pollTitle.Location = new System.Drawing.Point(11, 41);
            this.pollTitle.Name = "pollTitle";
            this.pollTitle.Size = new System.Drawing.Size(483, 33);
            this.pollTitle.TabIndex = 8;
            this.pollTitle.SelectedValueChanged += new System.EventHandler(this.PollTitle_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Τίτλοι δημοσκοπήσεων";
            // 
            // PollAttendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(508, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pollTitle);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.forthChoiceRadioButton);
            this.Controls.Add(this.thirdChoiceRadioButton);
            this.Controls.Add(this.secondChoiceRadioButton);
            this.Controls.Add(this.firstChoiceRadioButton);
            this.Controls.Add(this.pollQuestionRichTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PollAttendForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PollAttendForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox pollQuestionRichTextbox;
        private System.Windows.Forms.RadioButton firstChoiceRadioButton;
        private System.Windows.Forms.RadioButton secondChoiceRadioButton;
        private System.Windows.Forms.RadioButton thirdChoiceRadioButton;
        private System.Windows.Forms.RadioButton forthChoiceRadioButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ComboBox pollTitle;
        private System.Windows.Forms.Label label1;
    }
}