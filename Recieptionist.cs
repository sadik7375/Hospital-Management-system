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
    public partial class Recieptionist : Form
    {


        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");
        public Recieptionist()
        {
            InitializeComponent();
            DisplayRec();
        }

        private void DisplayRec()
        {
           
            string Query = "Select* from RecieptionistTb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
            

        }
        DataTable Execute(SqlCommand command)
        {
            DataTable dt = new DataTable();
            command.Connection.Open();
            //dt.Load(command.ExecuteReader());
            command.Connection.Close();
            return dt;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Recieptionist_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (RepId.Text==""||RepName.Text == "" || Repphone.Text == "" || Reppassword.Text == "" || RepAddress.Text == "") 
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cdm = new SqlCommand("insert into   RecieptionistTb values(@RepId,@Repname,@Repphone,@Reppassword,@Repaddress)", conn);
                    cdm.Parameters.AddWithValue("RepId", int.Parse(RepId.Text));
                    cdm.Parameters.AddWithValue("Repname",RepName.Text);
                    cdm.Parameters.AddWithValue("Repphone", Repphone.Text);
                    cdm.Parameters.AddWithValue("Reppassword", Reppassword.Text);
                    cdm.Parameters.AddWithValue("Repaddress", RepAddress.Text);
                    cdm.ExecuteNonQuery();

                    
                    MessageBox.Show("Repcieptionist Added");
                    SqlDataAdapter da = new SqlDataAdapter(cdm);
                    DataTable dt = new DataTable();
                    DisplayRec();

                    conn.Close();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cdm = new SqlCommand("update  RecieptionistTb set Repname=@Repname,Repphone=@Repphone,Reppassword=@Reppassword,Repaddress=@Repaddress where RepId=@RepId", conn);
            cdm.Parameters.AddWithValue("RepId",int.Parse( RepId.Text));
            cdm.Parameters.AddWithValue("Repname", RepName.Text);
            cdm.Parameters.AddWithValue("Repphone", Repphone.Text);
            cdm.Parameters.AddWithValue("Reppassword", Reppassword.Text);
           cdm.Parameters.AddWithValue("Repaddress", RepAddress.Text);
           cdm.ExecuteNonQuery();
          
            MessageBox.Show("Successfully updated");
            DisplayRec();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            

            conn.Open();
            SqlCommand cdm = new SqlCommand("Delete RecieptionistTb where RepId=@RepId", conn);
            cdm.Parameters.AddWithValue("RepId", int.Parse(RepId.Text));
            
            cdm.ExecuteNonQuery();
            DisplayRec();
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void RepId_TextChanged(object sender, EventArgs e)
        {

        }

        private void RepId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(RepId.Text))
            {
                e.Cancel = true;
                RepId.Focus();
                errorProvider1.SetError(RepId, "Please enter your id");
            }
            else
            {
                errorProvider1.SetError(RepId, null);
            }
        }

        private void RepName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(RepName.Text))
            {
                e.Cancel = true;
                RepName.Focus();
                errorProvider2.SetError(RepName, "Please enter your name");
            }
            else
            {
                errorProvider2.SetError(RepName, null);
            }
        }

        private void Reppassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Reppassword.Text))
            {
                e.Cancel = true;
                Reppassword.Focus();
                errorProvider3.SetError(Reppassword, "Please enter your password");
            }
            else
            {
                errorProvider3.SetError(Reppassword, null);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
