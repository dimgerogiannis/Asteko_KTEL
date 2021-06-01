
namespace QualityManagerForms
{
    partial class PollCreationForm
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
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextbox = new System.Windows.Forms.TextBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.choiceLabel = new System.Windows.Forms.Label();
            this.choicesListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChoiceLabel = new System.Windows.Forms.Label();
            this.choiceTextbox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.createPollButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.questionRichTextbox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 22);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(63, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Τίτλος";
            // 
            // titleTextbox
            // 
            this.titleTextbox.Location = new System.Drawing.Point(12, 50);
            this.titleTextbox.MaxLength = 80;
            this.titleTextbox.Name = "titleTextbox";
            this.titleTextbox.Size = new System.Drawing.Size(612, 31);
            this.titleTextbox.TabIndex = 1;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(12, 104);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(180, 25);
            this.startDateLabel.TabIndex = 2;
            this.startDateLabel.Text = "Ημερομηνία έναρξης";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(12, 175);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(160, 25);
            this.endDateLabel.TabIndex = 3;
            this.endDateLabel.Text = "Ημερομηνία λήξης";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(12, 132);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(385, 31);
            this.startDateTimePicker.TabIndex = 2;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(12, 203);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(385, 31);
            this.endDateTimePicker.TabIndex = 3;
            // 
            // choiceLabel
            // 
            this.choiceLabel.AutoSize = true;
            this.choiceLabel.Location = new System.Drawing.Point(12, 372);
            this.choiceLabel.Name = "choiceLabel";
            this.choiceLabel.Size = new System.Drawing.Size(82, 25);
            this.choiceLabel.TabIndex = 6;
            this.choiceLabel.Text = "Επιλογές";
            // 
            // choicesListview
            // 
            this.choicesListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.choicesListview.HideSelection = false;
            this.choicesListview.Location = new System.Drawing.Point(12, 400);
            this.choicesListview.Name = "choicesListview";
            this.choicesListview.Size = new System.Drawing.Size(612, 185);
            this.choicesListview.TabIndex = 6;
            this.choicesListview.UseCompatibleStateImageBehavior = false;
            this.choicesListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Επιλογή";
            this.columnHeader1.Width = 600;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(241, 69);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.deleteToolStripMenuItem.Text = "Διαγραφή";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // addChoiceLabel
            // 
            this.addChoiceLabel.AutoSize = true;
            this.addChoiceLabel.Location = new System.Drawing.Point(12, 254);
            this.addChoiceLabel.Name = "addChoiceLabel";
            this.addChoiceLabel.Size = new System.Drawing.Size(173, 25);
            this.addChoiceLabel.TabIndex = 9;
            this.addChoiceLabel.Text = "Προσθήκη επιλογής";
            // 
            // choiceTextbox
            // 
            this.choiceTextbox.Location = new System.Drawing.Point(12, 282);
            this.choiceTextbox.MaxLength = 50;
            this.choiceTextbox.Name = "choiceTextbox";
            this.choiceTextbox.Size = new System.Drawing.Size(385, 31);
            this.choiceTextbox.TabIndex = 4;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 319);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(112, 34);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Προσθήκη";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // createPollButton
            // 
            this.createPollButton.Location = new System.Drawing.Point(12, 782);
            this.createPollButton.Name = "createPollButton";
            this.createPollButton.Size = new System.Drawing.Size(130, 34);
            this.createPollButton.TabIndex = 8;
            this.createPollButton.Text = "Δημιουργία";
            this.createPollButton.UseVisualStyleBackColor = true;
            this.createPollButton.Click += new System.EventHandler(this.CreatePollButton_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(12, 610);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(86, 25);
            this.questionLabel.TabIndex = 12;
            this.questionLabel.Text = "Ερώτηση";
            // 
            // questionRichTextbox
            // 
            this.questionRichTextbox.Location = new System.Drawing.Point(12, 638);
            this.questionRichTextbox.MaxLength = 200;
            this.questionRichTextbox.Name = "questionRichTextbox";
            this.questionRichTextbox.Size = new System.Drawing.Size(612, 129);
            this.questionRichTextbox.TabIndex = 7;
            this.questionRichTextbox.Text = "";
            // 
            // PollCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(636, 831);
            this.Controls.Add(this.questionRichTextbox);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.createPollButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addChoiceLabel);
            this.Controls.Add(this.choicesListview);
            this.Controls.Add(this.choiceLabel);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.choiceTextbox);
            this.Controls.Add(this.titleTextbox);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PollCreationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PollCreationForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextbox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label choiceLabel;
        private System.Windows.Forms.ListView choicesListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label addChoiceLabel;
        private System.Windows.Forms.TextBox choiceTextbox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button createPollButton;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.RichTextBox questionRichTextbox;
    }
}