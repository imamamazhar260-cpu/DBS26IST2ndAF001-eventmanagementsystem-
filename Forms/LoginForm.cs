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
using eventmanagementsystem.Forms;
namespace eventmanagementsystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con =
            DBConnection.GetConnection();

            try
            {
                con.Open();

                string query =
                "SELECT COUNT(*) FROM [User] WHERE Email=@Email AND Password=@Password";

                SqlCommand cmd =
                new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                int result =
                (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    MessageBox.Show("Login Successful");

                    DashboardForm df =
                    new DashboardForm();

                    this.Hide();

                    df.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}