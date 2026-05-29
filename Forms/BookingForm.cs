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
    public partial class BookingForm : Form
    {
        int selectedBookingID = 0;

        int selectedEventID = 0;

        int selectedTickets = 0;  
        public BookingForm()
        {
            InitializeComponent();
        }
        void LoadCustomers()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
    Customer.CustomerID,
    [User].FullName

    FROM Customer

    INNER JOIN [User]
    ON Customer.UserID = [User].UserID";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbCustomer.DataSource = dt;

            cmbCustomer.DisplayMember = "FullName";

            cmbCustomer.ValueMember = "CustomerID";

            con.Close();
        }
        void LoadEvents()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT EventID, EventTitle FROM Event", con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbEvent.DataSource = dt;

            cmbEvent.DisplayMember = "EventTitle";

            cmbEvent.ValueMember = "EventID";

            con.Close();
        }
        void LoadBookings()
{
    SqlConnection con =
    DBConnection.GetConnection();

    con.Open();

    string query =
    @"SELECT
    Booking.BookingID,
Booking.EventID,
    [User].FullName,
    Event.EventTitle,
    Booking.BookingDate,
    Booking.NumberOfTickets,
    Booking.BookingStatus


    FROM Booking

    INNER JOIN Customer
    ON Booking.CustomerID = Customer.CustomerID

    INNER JOIN [User]
    ON Customer.UserID = [User].UserID

    INNER JOIN Event
    ON Booking.EventID = Event.EventID";

    SqlDataAdapter da =
    new SqlDataAdapter(query, con);

    DataTable dt =
    new DataTable();

    da.Fill(dt);

    dgvBookings.DataSource = dt;

    con.Close();
}

        private void BookingForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadEvents();
            LoadBookings();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                SqlConnection con =
                DBConnection.GetConnection();

                con.Open();

                string query =
                "SELECT TicketPrice FROM Event WHERE EventID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                "@id",
                cmbEvent.SelectedValue);

                decimal price =
                Convert.ToDecimal(cmd.ExecuteScalar());

                int qty =
                Convert.ToInt32(txtQuantity.Text);

                decimal total = price * qty;

                txtTotal.Text = total.ToString();
                

                con.Close();
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            con.Open();

            SqlTransaction transaction =
            con.BeginTransaction();

            try
            {
                string insertQuery =
@"INSERT INTO Booking
(
CustomerID,
EventID,
BookingDate,
NumberOfTickets,
BookingStatus
)

VALUES
(
@customer,
@event,
@date,
@qty,
@status
)";

                SqlCommand cmd =
                new SqlCommand(insertQuery, con, transaction);

                cmd.Parameters.AddWithValue(
                "@customer",
                cmbCustomer.SelectedValue);

                cmd.Parameters.AddWithValue(
                "@event",
                cmbEvent.SelectedValue);

                cmd.Parameters.AddWithValue(
                "@date",
                dtpBooking.Value);

                cmd.Parameters.AddWithValue(
                "@qty",
                txtQuantity.Text);

                cmd.Parameters.AddWithValue(
                "@total",
                txtTotal.Text);
                cmd.Parameters.AddWithValue(
"@status",
"Confirmed");

                cmd.ExecuteNonQuery();

                string updateSeats =
                @"UPDATE Event
    SET TotalSeats = TotalSeats - @qty
    WHERE EventID=@event";

                SqlCommand seatCmd =
                new SqlCommand(updateSeats, con, transaction);

                seatCmd.Parameters.AddWithValue(
                "@qty",
                txtQuantity.Text);

                seatCmd.Parameters.AddWithValue(
                "@event",
                cmbEvent.SelectedValue);

                seatCmd.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Booking Successful");
                LoadBookings();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEventID =
Convert.ToInt32(
dgvBookings.Rows[e.RowIndex].Cells["EventID"].Value);
            selectedBookingID =
Convert.ToInt32(
dgvBookings.Rows[e.RowIndex].Cells["BookingID"].Value);

            selectedTickets =
            Convert.ToInt32(
            dgvBookings.Rows[e.RowIndex].Cells["NumberOfTickets"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            con.Open();

            SqlTransaction transaction =
            con.BeginTransaction();

            try
            {
                string deleteQuery =
                "DELETE FROM Booking WHERE BookingID=@id";

                SqlCommand deleteCmd =
                new SqlCommand(deleteQuery, con, transaction);

                deleteCmd.Parameters.AddWithValue(
                "@id",
                selectedBookingID);

                deleteCmd.ExecuteNonQuery();

                string restoreSeats =
                @"UPDATE Event
    SET TotalSeats = TotalSeats + @tickets
    WHERE EventID=@event";

                SqlCommand seatCmd =
                new SqlCommand(restoreSeats, con, transaction);

                seatCmd.Parameters.AddWithValue(
                "@tickets",
                selectedTickets);

                seatCmd.Parameters.AddWithValue(
                "@event",
                selectedEventID);

                seatCmd.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Booking Deleted");

                LoadBookings();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuantity.Clear();

            txtTotal.Clear();

            cmbCustomer.SelectedIndex = 0;

            cmbEvent.SelectedIndex = 0;

            selectedBookingID = 0;

            selectedEventID = 0;

            selectedTickets = 0;
        }
    }
}
