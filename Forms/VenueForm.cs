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
    public partial class VenueForm : Form
    {
        int selectedVenueID = 0;
        public VenueForm()
        {
            InitializeComponent();
        }
        void LoadVenues()
        {
            SqlConnection con =
            DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT
      VenueID,
      VenueName,
      Location,
      Capacity,
      ContactNumber
      FROM Venue";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvVenues.DataSource = dt;

            con.Close();
        }

        private void VenueForm_Load(object sender, EventArgs e)
        {
            
            LoadVenues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                @"INSERT INTO Venue
      (
        VenueName,
        Location,
        Capacity,
        ContactNumber
      )
      VALUES
      (
        @name,
        @location,
        @capacity,
        @contact
      )";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                "@name",
                txtVenueName.Text);

                cmd.Parameters.AddWithValue(
                "@location",
                txtLocation.Text);

                cmd.Parameters.AddWithValue(
                "@capacity",
                Convert.ToInt32(txtCapacity.Text));

                cmd.Parameters.AddWithValue(
                "@contact",
                txtContactNumber.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Venue Added");

                con.Close();

                LoadVenues();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvVenues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedVenueID =
Convert.ToInt32(
dgvVenues.Rows[e.RowIndex]
.Cells["VenueID"].Value);

            txtVenueName.Text =
            dgvVenues.Rows[e.RowIndex]
            .Cells["VenueName"].Value.ToString();

            txtLocation.Text =
            dgvVenues.Rows[e.RowIndex]
            .Cells["Location"].Value.ToString();

            txtCapacity.Text =
            dgvVenues.Rows[e.RowIndex]
            .Cells["Capacity"].Value.ToString();

            txtContactNumber.Text =
            dgvVenues.Rows[e.RowIndex]
            .Cells["ContactNumber"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                @"UPDATE Venue
      SET
      VenueName=@name,
      Location=@location,
      Capacity=@capacity,
      ContactNumber=@contact
      WHERE VenueID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name",
                txtVenueName.Text);

                cmd.Parameters.AddWithValue("@location",
                txtLocation.Text);

                cmd.Parameters.AddWithValue("@capacity",
                Convert.ToInt32(txtCapacity.Text));

                cmd.Parameters.AddWithValue("@contact",
                txtContactNumber.Text);

                cmd.Parameters.AddWithValue("@id",
                selectedVenueID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Venue Updated");

                con.Close();

                LoadVenues();

                btnClear.PerformClick();
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
                "DELETE FROM Venue WHERE VenueID=@id";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                "@id",
                selectedVenueID);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Venue Deleted");

                con.Close();

                LoadVenues();

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con =
DBConnection.GetConnection();

            con.Open();

            string query =
            @"SELECT *
  FROM Venue
  WHERE VenueName LIKE '%' + @search + '%'";

            SqlDataAdapter da =
            new SqlDataAdapter(query, con);

            da.SelectCommand.Parameters.AddWithValue(
            "@search",
            txtSearch.Text);

            DataTable dt =
            new DataTable();

            da.Fill(dt);

            dgvVenues.DataSource = dt;

            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVenueName.Clear();

            txtLocation.Clear();

            txtCapacity.Clear();

            txtContactNumber.Clear();

            txtSearch.Clear();

            selectedVenueID = 0;
        }
    }
    }

