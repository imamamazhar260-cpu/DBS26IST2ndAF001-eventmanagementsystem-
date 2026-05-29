using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using eventmanagementsystem.Services;

namespace eventmanagementsystem.Forms
{
    public partial class PaymentForm : Form
    {
        int selectedPaymentID = 0;
        public PaymentForm()
        {
            InitializeComponent();
        }
        void LoadBookings()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
    BookingID
    FROM Booking";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbBooking.DataSource = dt;

            cmbBooking.DisplayMember = "BookingID";

            cmbBooking.ValueMember = "BookingID";

            con.Close();
        }
        void LoadPayments()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
    PaymentID,
    BookingID,
    Amount,
    PaymentMethod,
    PaymentDate,
    PaymentStatus

    FROM Payment";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvPayments.DataSource = dt;

            con.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                @"INSERT INTO Payment
    (
    BookingID,
    Amount,
    PaymentMethod,
    PaymentDate,
    PaymentStatus
    )

    VALUES
    (
    @booking,
    @amount,
    @method,
    @date,
    @status
    )";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                "@booking",
                cmbBooking.SelectedValue);

                cmd.Parameters.AddWithValue(
                "@amount",
                txtAmount.Text);

                cmd.Parameters.AddWithValue(
                "@method",
                cmbMethod.Text);

                cmd.Parameters.AddWithValue(
                "@date",
                dtpPayment.Value);

                cmd.Parameters.AddWithValue(
                "@status",
                cmbStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment Added");

                con.Close();

                LoadPayments();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadBookings();
            LoadPayments();
        }

        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPaymentID =
Convert.ToInt32(
dgvPayments.Rows[e.RowIndex]
.Cells["PaymentID"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                "DELETE FROM Payment WHERE PaymentID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                "@id",
                selectedPaymentID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment Deleted");

                con.Close();

                LoadPayments();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbBooking.SelectedIndex = 0;

            txtAmount.Clear();

            cmbMethod.SelectedIndex = -1;

            cmbStatus.SelectedIndex = -1;

            selectedPaymentID = 0;
        }
    }
    }
