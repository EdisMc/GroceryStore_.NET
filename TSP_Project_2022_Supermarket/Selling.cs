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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\edy_d\OneDrive\Documents\grstoredb.mdf;Integrated Security=True;Connect Timeout=30");
        private void showData()
        {
            conn.Open();
            string query = "select ProdName, ProdQty from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void Selling_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void ProdDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdName.Text = ProdDGV1.SelectedRows[0].Cells[0].Value.ToString();
            ProdPrice.Text = ProdDGV1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelb.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        int grTotal = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            int n = 0, total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);

            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.CreateCells(OrderDGV);
            dataGridViewRow.Cells[0].Value = n++;
            dataGridViewRow.Cells[1].Value = ProdName.Text;
            dataGridViewRow.Cells[2].Value = ProdPrice.Text;
            dataGridViewRow.Cells[3].Value = ProdQty.Text;
            dataGridViewRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            OrderDGV.Rows.Add(dataGridViewRow);
            grTotal = grTotal + total;
            Amtlb.Text = "Rs " + grTotal;

        }
    }
}
