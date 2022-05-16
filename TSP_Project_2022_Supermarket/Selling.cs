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

        private void Selling_Load(object sender, EventArgs e)
        {
            showData();
            showBillData();
            fillCombo();
            SellerName.Text = Form1.sellerName;
        }
        private void showData()
        {
            conn.Open();
            string query = "select ProdName, ProdPrice from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void showBillData()
        {
            conn.Open();
            string query = "select * from Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showData();
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

        int grTotal = 0, n = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (BillId.Text == "")
            {
                MessageBox.Show("Missing Bill Id!");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Bill values(" + BillId.Text + ",'" + SellerName.Text + "','" + Datelb.Text + "'," + Amtlb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order added successfully!");
                    conn.Close();
                    showBillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("EDY'S GROCERY STORE", new Font("Ink Free",25,FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill Id: " + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Ink Free", 20, FontStyle.Bold), Brushes.Blue, new Point(100,70));
            e.Graphics.DrawString("Seller Name: " + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Ink Free", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date: " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Ink Free", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount: " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Ink Free", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            e.Graphics.DrawString("Edis Reyhan", new Font("Ink Free", 20, FontStyle.Italic), Brushes.Red, new Point(660, 230));

            Image img = Image.FromFile(@"C:\Users\edy_d\OneDrive\Pictures\CordeliasMarket-2.jpg");
            e.Graphics.DrawImage(img, new Point(280, 280));
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select ProdName, ProdQty from Product where ProdCat='" + comboBox2.SelectedValue.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            ProdDGV1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void fillCombo()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select CatName from Category", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            comboBox2.ValueMember = "catName";
            comboBox2.DataSource = dt;
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                int total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(OrderDGV);
                dataGridViewRow.Cells[0].Value = n + 1;
                dataGridViewRow.Cells[1].Value = ProdName.Text;
                dataGridViewRow.Cells[2].Value = ProdPrice.Text;
                dataGridViewRow.Cells[3].Value = ProdQty.Text;
                dataGridViewRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
                OrderDGV.Rows.Add(dataGridViewRow);
                n++;
                grTotal = grTotal + total;
                Amtlb.Text = "" + grTotal;
            }
        }
    }
}
