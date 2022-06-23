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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");

        DataTable Execute(SqlCommand command)
        {
            DataTable dt = new DataTable();
            command.Connection.Open();
            dt.Load(command.ExecuteReader());
            command.Connection.Close();
            return dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (select.SelectedIndex == -1)
            {
                MessageBox.Show("Select your position");
            }
            else if (select.SelectedIndex == 0)
            {
                if (userId.Text == "1234" && userpass.Text == "pass")
                {
                    Home obj = new Home();
                    obj.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong username or password");

                }
            }
            else if (select.SelectedIndex == 1)
            {
                if (userId.Text == "" && userpass.Text == "")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    string sql = "select * " +
                " from [dbo].[DoctorTb] where Docid ='" + userId.Text
                + "' and Password='" + userpass.Text + "'";

                    SqlCommand sqlCmd = new SqlCommand(sql, conn);
                    DataTable dt = Execute(sqlCmd);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login successful");
                        Prescription pt = new Prescription();
                        pt.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Faild");
                    }

                }
            }


            else
            {
                string sql = "select * " +
                " from [dbo].[RecieptionistTb] where RepId ='" + userId.Text
                + "' and Reppassword='" + userpass.Text + "'";

                SqlCommand sqlCmd = new SqlCommand(sql, conn);
                DataTable dt = Execute(sqlCmd);
                if (dt.Rows.Count > 0)
                { 
                    MessageBox.Show("Login successful");
                    docname1 form2 = new docname1();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Faild");
                }


            }
        }











        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            select.SelectedIndex = -1;
            userId.Text = "";
            userpass.Text = "";

        }
        private void select_Validating(object sender, CancelEventArgs e)
        {

            
        }


        private void userId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(userId.Text))
            {
                e.Cancel = true;
                userId.Focus();
                errorProvider1.SetError(userId, "Please Enter your UserId");
            }
            else
            {
                errorProvider1.SetError(select, null);
            }
        }

        private void userpass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(userId.Text))
            {
                e.Cancel = true;
                userId.Focus();
                errorProvider1.SetError(userId, "Please Enter your Password");
            }
            else
            {
                errorProvider1.SetError(select, null);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void select_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void userId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void select_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(select.Text))
            {
                e.Cancel = true;
                select.Focus();
                errorProvider1.SetError(select, "Please select your position");
            }
            else
            {
                errorProvider1.SetError(select, null);
            }
        }
    }
}
