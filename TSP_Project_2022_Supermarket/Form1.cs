using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSP_Project_2022_Supermarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                            MessageBox.Show("Enter the correct Id and password!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are in the Seller section!");
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
