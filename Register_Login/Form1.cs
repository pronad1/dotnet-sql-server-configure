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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
            // Replace Data Source, Initial Catalog, User ID, and Password with your actual values
            string connectionString = "Data Source=DESKTOP-C4DV877\\SQLEXPRESS01;Initial Catalog=loginapp;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to SQL Server: " + ex.Message);
            }               
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Registe_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" && txtpassword.Text == "" && txtComPassword.Text=="")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            if (txtpassword.Text != txtComPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }
            else
            {
                try
                {
                    string query = "INSERT INTO Users (username, password) VALUES (@Username, @Password)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
                        sqlCommand.Parameters.AddWithValue("@Password", txtpassword.Text);
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful.");
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during registration: " + ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();

        }
    }
}
