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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            DisplayRec();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");
        private void Doctor_Load(object sender, EventArgs e)
        {

        }
        private void DisplayRec()
        {

            string Query = "Select* from DoctorTb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Docname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Docid.Text == "" || Docname.Text == "" || Docgender.Text == "" ||Docphone.Text==""|| Docexprience.Text == "" || Docdob.Text == "" || Docaddress.Text=="" || Docpassword.Text=="")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cdm = new SqlCommand("insert into   DoctorTb values(@Docid,@Name,@Dob,@Gender,@Exprience,@Phonenumber,@Password,@Address)", conn);
                    cdm.Parameters.AddWithValue("Docid", int.Parse(Docid.Text));
                    cdm.Parameters.AddWithValue("Name", Docname.Text);
                    cdm.Parameters.AddWithValue("Dob", Docdob.Text);
                    cdm.Parameters.AddWithValue("Gender", Docgender.Text);
                    cdm.Parameters.AddWithValue("Exprience", Docexprience.Text);
                    cdm.Parameters.AddWithValue("Phonenumber", Docphone.Text);
                    cdm.Parameters.AddWithValue("Password", Docpassword.Text);
                    cdm.Parameters.AddWithValue("Address", Docaddress.Text);
                    cdm.ExecuteNonQuery();


                    MessageBox.Show("Doctor Added");
                    SqlDataAdapter da = new SqlDataAdapter(cdm);
                    DataTable dt = new DataTable();
                    DisplayRec();

                    conn.Close();
                }
                catch (Exception Ex)
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
            SqlCommand cdm = new SqlCommand("update DoctorTb set Name=@Name,Dob=@Dob,Gender=@Gender,Expricence=@Expricence,Phonenumber=@Phonenumber,Password=@Password,Address=@Address where Docid=@Docid", conn);
            cdm.Parameters.AddWithValue("Docid", int.Parse(Docid.Text));
            cdm.Parameters.AddWithValue("Name", Docname.Text);
            cdm.Parameters.AddWithValue("Age", Docdob.Text);
            cdm.Parameters.AddWithValue("Gender", Docgender.Text);
            cdm.Parameters.AddWithValue("Expricence", Docexprience.Text);
            cdm.Parameters.AddWithValue("Phonenumber", Docphone.Text);
            cdm.Parameters.AddWithValue("Address", Docaddress.Text);
            cdm.Parameters.AddWithValue("Password", Docpassword.Text);
            cdm.ExecuteNonQuery();

            MessageBox.Show("Successfully updated");
            DisplayRec();
            conn.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            //int rowIndex = dataGridView1.CurrentCell.RowIndex;
            //dataGridView1.Rows.RemoveAt(rowIndex);

            SqlCommand cdm = new SqlCommand("Delete DoctorTb where Docid=@Docid", conn);

            cdm.Parameters.AddWithValue("Docid", int.Parse(Docid.Text));
            cdm.ExecuteNonQuery();
            conn.Close();
            DisplayRec();
            MessageBox.Show("Successfully Deleted");
            conn.Close();
        }

        private void Docpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void Docid_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Docid.Text))
            {
                e.Cancel = true;
                Docid.Focus();
                errorProvider1.SetError(Docid, "Please enter your password");
            }
            else
            {
                errorProvider1.SetError(Docid, null);
            }
        }

        private void Docpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Docpassword.Text))
            {
                e.Cancel = true;
                Docpassword.Focus();
                errorProvider2.SetError(Docpassword, "Please enter your password ");
            }
            else
            {
                errorProvider2.SetError(Docpassword, null);
            }
        }

        private void Docname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Docname.Text))
            {
                e.Cancel = true;
                Docname.Focus();
                errorProvider1.SetError(Docname, "Please enter your name");
            }
            else
            {
                errorProvider1.SetError(Docname, null);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

