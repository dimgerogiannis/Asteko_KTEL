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

namespace Project.BusDriverForms
{
    public partial class IncommingComplaintForm : Form
    {
        private BusDriver _busDriver;
        private List<DisciplinaryComplaint> _complaints;

        public IncommingComplaintForm(BusDriver busDriver)
        {
            _busDriver = busDriver;
            InitializeComponent();
        }

        private void IncommingComplaintForm_Load(object sender, EventArgs e)
        {
            _complaints = _busDriver.GetDisciplinaryComplaints();

            foreach (var complaint in _complaints.OrderByDescending(x => x.Datetime))
                datetimeCombobox.Items.Add(complaint.Datetime.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        private void DatetimeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (datetimeCombobox.SelectedItem != null)
                complaintRichTextbox.Text = _complaints.Find(x => x.Datetime == DateTime.Parse(datetimeCombobox.SelectedItem.ToString())).Summary;
        }
    }
}
