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

namespace TSP_Project_2022_Supermarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string sellerName = "";

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\edy_d\OneDrive\Documents\grstoredb.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            password.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "" || password.Text == "")
            {
                MessageBox.Show("Enter username and password!");
            } 
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {
                        if (Uname.Text == "Admin" && password.Text == "Admin")
                        {
                            Product product = new Product();
                            product.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Enter the correct username and password!");
                            Uname.Text = "";
                            password.Text = "";
                        }
                    }
                    else
                    {
                       conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("select count(8) from Seller where SellerName='" + Uname.Text + "' and SellerPass='" + password.Text + "'", conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            sellerName = Uname.Text;
                            Selling selling = new Selling();
                            selling.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username and password!");
                            Uname.Text = "";
                            password.Text = "";
                        }
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select a role");
                }
            }
        }
    }
}
