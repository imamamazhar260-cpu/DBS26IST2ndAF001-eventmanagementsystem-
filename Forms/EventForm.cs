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
    public partial class EventForm : Form

    {
        int selectedEventID = 0;
        public EventForm()
        {
            InitializeComponent();
        }

        void LoadVenues()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT VenueID, VenueName FROM Venue", con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbVenue.DataSource = dt;

            cmbVenue.DisplayMember = "VenueName";

            cmbVenue.ValueMember = "VenueID";

            con.Close();
        }
        void LoadCategories()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT CategoryID, CategoryName FROM Category", con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbCategory.DataSource = dt;

            cmbCategory.DisplayMember = "CategoryName";

            cmbCategory.ValueMember = "CategoryID";

            con.Close();
        }
        void LoadOrganizers()

        {

            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            SqlDataAdapter da =
            new SqlDataAdapter(
            "SELECT OrganizerID, OrganizationName FROM Organizer", con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            cmbOrganizer.DataSource = dt;

            cmbOrganizer.DisplayMember = "OrganizationName";

            cmbOrganizer.ValueMember = "OrganizerID";

            con.Close();
        }
        void LoadEvents()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
    EventID,
    EventTitle,
    Description,
    EventDate,
    TicketPrice,
    TotalSeats
    FROM Event";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvEvents.DataSource = dt;

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();

            txtDescription.Clear();

            txtPrice.Clear();

            txtSeats.Clear();

            cmbVenue.SelectedIndex = 0;

            cmbCategory.SelectedIndex = 0;

            cmbOrganizer.SelectedIndex = 0;

            selectedEventID = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Enter Event Title");
                return;
            }

            if (txtDescription.Text == "")
            {
                MessageBox.Show("Enter Description");
                return;
            }

            if (txtPrice.Text == "")
            {
                MessageBox.Show("Enter Ticket Price");
                return;
            }

            if (txtSeats.Text == "")
            {
                MessageBox.Show("Enter Total Seats");
                return;
            }

            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Price must be numeric");
                return;
            }

            int seats;

            if (!int.TryParse(txtSeats.Text, out seats))
            {
                MessageBox.Show("Seats must be numeric");
                return;
            }

            if (dtpEventDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Event date cannot be past date");
                return;
            }
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                @"INSERT INTO Event
    (EventTitle, Description, EventDate,
    TicketPrice, TotalSeats,
    VenueID, CategoryID, OrganizerID)

    VALUES
    (@title, @desc, @date,
    @price, @seats,
    @venue, @category, @organizer)";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@title", txtTitle.Text);

                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.Parameters.AddWithValue("@date", dtpEventDate.Value);

                cmd.Parameters.AddWithValue("@price", txtPrice.Text);

                cmd.Parameters.AddWithValue("@seats", txtSeats.Text);

                cmd.Parameters.AddWithValue("@venue", cmbVenue.SelectedValue);

                cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedValue);

                cmd.Parameters.AddWithValue("@organizer", cmbOrganizer.SelectedValue);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Event Added Successfully");
                LoadEvents();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            LoadVenues();
            LoadCategories();
            LoadOrganizers();
            LoadEvents();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEventID =
            Convert.ToInt32(
            dgvEvents.Rows[e.RowIndex].Cells["EventID"].Value);

            txtTitle.Text =
            dgvEvents.Rows[e.RowIndex].Cells["EventTitle"].Value.ToString();

            txtDescription.Text =
            dgvEvents.Rows[e.RowIndex].Cells["Description"].Value.ToString();

            dtpEventDate.Value =
            Convert.ToDateTime(
            dgvEvents.Rows[e.RowIndex].Cells["EventDate"].Value);

            txtPrice.Text =
            dgvEvents.Rows[e.RowIndex].Cells["TicketPrice"].Value.ToString();

            txtSeats.Text =
            dgvEvents.Rows[e.RowIndex].Cells["TotalSeats"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                @"UPDATE Event
    SET
    EventTitle=@title,
    Description=@desc,
    EventDate=@date,
    TicketPrice=@price,
    TotalSeats=@seats

    WHERE EventID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@title", txtTitle.Text);

                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.Parameters.AddWithValue("@date", dtpEventDate.Value);

                cmd.Parameters.AddWithValue("@price", txtPrice.Text);

                cmd.Parameters.AddWithValue("@seats", txtSeats.Text);

                cmd.Parameters.AddWithValue("@id", selectedEventID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Event Updated Successfully");

                LoadEvents();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                "DELETE FROM Event WHERE EventID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", selectedEventID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Event Deleted Successfully");

                LoadEvents();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
EventID,
EventTitle,
Description,
EventDate,
TicketPrice,
TotalSeats

FROM Event

WHERE EventTitle LIKE @search";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue(
            "@search",
            "%" + txtSearch.Text + "%");

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvEvents.DataSource = dt;

            con.Close();
        }
    }
}