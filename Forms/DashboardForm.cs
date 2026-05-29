using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eventmanagementsystem.Forms;
using System.Data.SqlClient;
using eventmanagementsystem.Services;

namespace eventmanagementsystem.Forms
{
    public partial class DashboardForm : Form
    {
        int selectedCustomerID = 0;

        int selectedUserID = 0;
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventForm ef =
            new EventForm();

            ef.ShowDialog();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingForm bf =
new BookingForm();

            bf.ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm pf =
new PaymentForm();

            pf.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm cf =
new CustomerForm();

            cf.ShowDialog();
        }
    }
}
