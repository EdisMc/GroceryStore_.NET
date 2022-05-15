using System;
using System.Windows.Forms;

namespace TSP_Project_2022_Supermarket
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        int start_point = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            start_point++;
            Progress.Value = start_point;

            if (Progress.Value == 100)
            {
                Progress.Value = 0;
                timer1.Stop();
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }

        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
