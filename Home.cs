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
namespace HMproject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            count();
            count1();
            count2();
        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");
       
        private void count()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from PatientTb",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PatLb.Text = dt.Rows[0][0].ToString();
            conn.Close();

        }

        private void count1()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from DoctorTb", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DocLb.Text = dt.Rows[0][0].ToString();
            conn.Close();

        }
        private void count2()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from RecieptionistTb", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            RepLb.Text = dt.Rows[0][0].ToString();
            conn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            docname1 obj = new docname1();
            obj.Show();
            this.Hide();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Doctor obj = new Doctor();
            obj.Show();
            this.Hide();
           
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Recieptionist obj = new Recieptionist();
            obj.Show();
            this.Hide();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
