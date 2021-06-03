
namespace DistributorForms
{
    partial class BusLineEditingForm
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
            this.busLineNumberLabel = new System.Windows.Forms.Label();
            this.busLineNumberCombobox = new System.Windows.Forms.ComboBox();
            this.stopNameLabel = new System.Windows.Forms.Label();
            this.stopNameTextbox = new System.Windows.Forms.TextBox();
            this.addStopButton = new System.Windows.Forms.Button();
            this.stopNameListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateButton = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // busLineNumberLabel
            // 
            this.busLineNumberLabel.AutoSize = true;
            this.busLineNumberLabel.Location = new System.Drawing.Point(12, 23);
            this.busLineNumberLabel.Name = "busLineNumberLabel";
            this.busLineNumberLabel.Size = new System.Drawing.Size(154, 25);
            this.busLineNumberLabel.TabIndex = 0;
            this.busLineNumberLabel.Text = "Αριθμός γραμμής";
            // 
            // busLineNumberCombobox
            // 
            this.busLineNumberCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busLineNumberCombobox.FormattingEnabled = true;
            this.busLineNumberCombobox.Location = new System.Drawing.Point(12, 51);
            this.busLineNumberCombobox.Name = "busLineNumberCombobox";
            this.busLineNumberCombobox.Size = new System.Drawing.Size(98, 33);
            this.busLineNumberCombobox.TabIndex = 1;
            this.busLineNumberCombobox.SelectedIndexChanged += new System.EventHandler(this.BusLineNumberCombobox_SelectedIndexChanged);
            // 
            // stopNameLabel
            // 
            this.stopNameLabel.AutoSize = true;
            this.stopNameLabel.Location = new System.Drawing.Point(12, 102);
            this.stopNameLabel.Name = "stopNameLabel";
            this.stopNameLabel.Size = new System.Drawing.Size(130, 25);
            this.stopNameLabel.TabIndex = 2;
            this.stopNameLabel.Text = "Όνομα στάσης";
            // 
            // stopNameTextbox
            // 
            this.stopNameTextbox.Location = new System.Drawing.Point(12, 130);
            this.stopNameTextbox.MaxLength = 40;
            this.stopNameTextbox.Name = "stopNameTextbox";
            this.stopNameTextbox.Size = new System.Drawing.Size(434, 31);
            this.stopNameTextbox.TabIndex = 3;
            // 
            // addStopButton
            // 
            this.addStopButton.Location = new System.Drawing.Point(12, 167);
            this.addStopButton.Name = "addStopButton";
            this.addStopButton.Size = new System.Drawing.Size(396, 38);
            this.addStopButton.TabIndex = 4;
            this.addStopButton.Text = "Προσθήκη στάσης μετά την επιλεγμένη στάση";
            this.addStopButton.UseVisualStyleBackColor = true;
            this.addStopButton.Click += new System.EventHandler(this.AddStopButton_Click);
            // 
            // stopNameListview
            // 
            this.stopNameListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.stopNameListview.FullRowSelect = true;
            this.stopNameListview.HideSelection = false;
            this.stopNameListview.Location = new System.Drawing.Point(12, 237);
            this.stopNameListview.Name = "stopNameListview";
            this.stopNameListview.Size = new System.Drawing.Size(601, 279);
            this.stopNameListview.TabIndex = 5;
            this.stopNameListview.UseCompatibleStateImageBehavior = false;
            this.stopNameListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Όνομα στάσης";
            this.columnHeader1.Width = 500;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(167, 36);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(166, 32);
            this.deleteToolStripMenuItem.Text = "Διαγραφή";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(12, 522);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(112, 34);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Ενημέρωση";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // BusLineEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 565);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.stopNameListview);
            this.Controls.Add(this.addStopButton);
            this.Controls.Add(this.stopNameTextbox);
            this.Controls.Add(this.stopNameLabel);
            this.Controls.Add(this.busLineNumberCombobox);
            this.Controls.Add(this.busLineNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusLineEditingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BusLineEditingForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label busLineNumberLabel;
        private System.Windows.Forms.ComboBox busLineNumberCombobox;
        private System.Windows.Forms.Label stopNameLabel;
        private System.Windows.Forms.TextBox stopNameTextbox;
        private System.Windows.Forms.Button addStopButton;
        private System.Windows.Forms.ListView stopNameListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button updateButton;
    }
}