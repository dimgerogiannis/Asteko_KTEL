using ClassesFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassesFolder.Enums;

namespace Project.BusDriverForms
{
    public partial class SanitaryComplaintForm : Form
    {
        private BusDriver _busDriver;
        private Dictionary<string, string> _clients;

        public SanitaryComplaintForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (clientFullNameLabelCombobox.SelectedItem != null && 
                violationsCombobox.SelectedItem != null)
            {
                var username = clientFullNameLabelCombobox.SelectedItem.ToString().Split("=")[1];
                username = username.Replace(" ", "");
                username = username.Replace(")", "");

                if (!_busDriver.CheckDuplicateSanitaryComplaint(username))
                {
                    SanitaryComplaintCategory category = SanitaryComplaintCategory.CloseDistance;

                    switch (violationsCombobox.SelectedItem.ToString())
                    {
                        case "Άρνηση χρήσης μάσκας":
                            category = SanitaryComplaintCategory.WeakMaskRefusal;
                            break;
                        case "Μη τήρηση των προβλεπόμενων αποστάσεων":
                            category = SanitaryComplaintCategory.CloseDistance;
                            break;
                        case "Ύπαρξη συμπτωμάτων του ιού":
                            category = SanitaryComplaintCategory.HasIllnessSymptoms;
                            break;
                    }

                    SanitaryComplaint complaint = new SanitaryComplaint
                    (
                        username,
                        violationDescriptionRichTextbox.Text,
                        category,
                        _busDriver.Username
                    );

                    _busDriver.InsertSanitaryComplaintInDatabase(complaint);

                    MessageBox.Show("Επιτυχής καταχώρηση καταγγελίας παραβίασης υγειονομικών μέτρων.",
                                    "Επιτυχία",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Έχετε ήδη καταχωρήσει μια καταγγελία παραβίασης υγειονομικών μέτρων για τον συγκεκριμένο επιβάτη.",
                                    "Σφάλμα",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);                  
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα απαραίτητα πεδία για να υποβάλετε την καταγγελία.",
                                "Σφάλμα",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ViolationDescriptionRichTextbox_TextChanged(object sender, EventArgs e)
        {
            violationDescriptionLabel.Text = $"Περιγραφή παραβίασης μέτρων προστασίας ({300 - violationDescriptionRichTextbox.Text.Length})";
        }

        private void SanitaryComplaintForm_Load(object sender, EventArgs e)
        {
            violationsCombobox.Items.AddRange(new string[]
            {
                "Άρνηση χρήσης μάσκας",
                "Μη τήρηση των προβλεπόμενων αποστάσεων",
                "Ύπαρξη συμπτωμάτων του ιού"
            });

            _clients = _busDriver.GetLastItineraryClients();

            foreach (var entry in _clients)
                clientFullNameLabelCombobox.Items.Add($"{entry.Key} (username = {entry.Value})");
        }
    }
}
