
namespace DistributorForms
{
    partial class BusLineConfigurationForm
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
            this.busLineLabel = new System.Windows.Forms.Label();
            this.busLineNumberTextbox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationCombobox = new System.Windows.Forms.ComboBox();
            this.stopNameLabel = new System.Windows.Forms.Label();
            this.stopNameTextbox = new System.Windows.Forms.TextBox();
            this.stopNamesListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.submitStopButton = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitButton = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // busLineLabel
            // 
            this.busLineLabel.AutoSize = true;
            this.busLineLabel.Location = new System.Drawing.Point(12, 24);
            this.busLineLabel.Name = "busLineLabel";
            this.busLineLabel.Size = new System.Drawing.Size(154, 25);
            this.busLineLabel.TabIndex = 0;
            this.busLineLabel.Text = "Αριθμός γραμμής";
            // 
            // busLineNumberTextbox
            // 
            this.busLineNumberTextbox.Location = new System.Drawing.Point(12, 52);
            this.busLineNumberTextbox.Name = "busLineNumberTextbox";
            this.busLineNumberTextbox.Size = new System.Drawing.Size(90, 31);
            this.busLineNumberTextbox.TabIndex = 1;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(12, 107);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(158, 25);
            this.durationLabel.TabIndex = 2;
            this.durationLabel.Text = "Διάρκεια γραμμής";
            // 
            // durationCombobox
            // 
            this.durationCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.durationCombobox.FormattingEnabled = true;
            this.durationCombobox.Location = new System.Drawing.Point(12, 135);
            this.durationCombobox.Name = "durationCombobox";
            this.durationCombobox.Size = new System.Drawing.Size(90, 33);
            this.durationCombobox.TabIndex = 3;
            // 
            // stopNameLabel
            // 
            this.stopNameLabel.AutoSize = true;
            this.stopNameLabel.Location = new System.Drawing.Point(12, 190);
            this.stopNameLabel.Name = "stopNameLabel";
            this.stopNameLabel.Size = new System.Drawing.Size(130, 25);
            this.stopNameLabel.TabIndex = 4;
            this.stopNameLabel.Text = "Όνομα στάσης";
            // 
            // stopNameTextbox
            // 
            this.stopNameTextbox.Location = new System.Drawing.Point(12, 218);
            this.stopNameTextbox.MaxLength = 40;
            this.stopNameTextbox.Name = "stopNameTextbox";
            this.stopNameTextbox.Size = new System.Drawing.Size(342, 31);
            this.stopNameTextbox.TabIndex = 5;
            // 
            // stopNamesListview
            // 
            this.stopNamesListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.stopNamesListview.FullRowSelect = true;
            this.stopNamesListview.HideSelection = false;
            this.stopNamesListview.Location = new System.Drawing.Point(12, 323);
            this.stopNamesListview.Name = "stopNamesListview";
            this.stopNamesListview.Size = new System.Drawing.Size(509, 230);
            this.stopNamesListview.TabIndex = 6;
            this.stopNamesListview.UseCompatibleStateImageBehavior = false;
            this.stopNamesListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Όνομα στάσης";
            this.columnHeader1.Width = 500;
            // 
            // submitStopButton
            // 
            this.submitStopButton.Location = new System.Drawing.Point(12, 267);
            this.submitStopButton.Name = "submitStopButton";
            this.submitStopButton.Size = new System.Drawing.Size(169, 34);
            this.submitStopButton.TabIndex = 7;
            this.submitStopButton.Text = "Προσθήκη στάσης";
            this.submitStopButton.UseVisualStyleBackColor = true;
            this.submitStopButton.Click += new System.EventHandler(this.SubmitStopButton_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(165, 36);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.removeToolStripMenuItem.Text = "Αφαίρεση";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click_1);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 559);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Προσθήκη";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // BusLineConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(533, 602);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.submitStopButton);
            this.Controls.Add(this.stopNamesListview);
            this.Controls.Add(this.stopNameTextbox);
            this.Controls.Add(this.stopNameLabel);
            this.Controls.Add(this.durationCombobox);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.busLineNumberTextbox);
            this.Controls.Add(this.busLineLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusLineConfigurationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BusLineConfigurationForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label busLineLabel;
        private System.Windows.Forms.TextBox busLineNumberTextbox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.ComboBox durationCombobox;
        private System.Windows.Forms.Label stopNameLabel;
        private System.Windows.Forms.TextBox stopNameTextbox;
        private System.Windows.Forms.ListView stopNamesListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button submitStopButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button submitButton;
    }
}