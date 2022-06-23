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
    public partial class docname1 : Form
    {
        public docname1()
        {
            InitializeComponent();
            DisplayRec();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");
        private void Patient_Load(object sender, EventArgs e)
        {

        }
        private void DisplayRec()
        {

            string Query = "Select* from PatientTb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Patid.Text == "" || patname.Text == "" || patphone.Text == "" || patgen.Text == "" || patphone.Text == "" || cost.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cdm = new SqlCommand("insert into  PatientTb values(@patid,@Name,@Gender,@Age,@Phonenumber,@RoomNo,@Cost,@DoctorName)", conn);
                    cdm.Parameters.AddWithValue("patid", int.Parse(Patid.Text));
                    cdm.Parameters.AddWithValue("Name", patname.Text);
                    cdm.Parameters.AddWithValue("Gender", patgen.Text);
                    cdm.Parameters.AddWithValue("Age", patdob.Text);
                    cdm.Parameters.AddWithValue("Cost", cost.Text);
                    cdm.Parameters.AddWithValue("Phonenumber", patphone.Text);
                    cdm.Parameters.AddWithValue("RoomNo", room.Text);
                    cdm.Parameters.AddWithValue("DoctorName", combo.Text);
                    cdm.ExecuteNonQuery();


                    MessageBox.Show("patient Added");
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

        private void delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cdm = new SqlCommand("Delete PatientTb where patid=@patid", conn);

            cdm.Parameters.AddWithValue("patid", int.Parse(Patid.Text));
            cdm.ExecuteNonQuery();
            conn.Close();
            DisplayRec();
            MessageBox.Show("Successfully Deleted");
            conn.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cdm = new SqlCommand("update PatientTb set Name=@Name,Age=@Age,Gender=@Gender,Phonenumber=@Phonenumber,Cost=@Cost,RoomNo=@RoomNo,DoctorName=@DoctorName where patid=@patid", conn);
            cdm.Parameters.AddWithValue("patid", int.Parse(Patid.Text));
            cdm.Parameters.AddWithValue("Name", patname.Text);
            cdm.Parameters.AddWithValue("Gender", patgen.Text);
            cdm.Parameters.AddWithValue("Age", patdob.Text);
            cdm.Parameters.AddWithValue("Cost", cost.Text);
            cdm.Parameters.AddWithValue("RoomNo", room.Text);
            cdm.Parameters.AddWithValue("Phonenumber", patphone.Text);
            cdm.Parameters.AddWithValue("DoctorName", combo.Text);
            cdm.ExecuteNonQuery();

            MessageBox.Show("Successfully updated");
            DisplayRec();
            conn.Close();
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

        private void patname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(patname.Text))
            {
                e.Cancel = true;
                patname.Focus();
                errorProvider2.SetError(patname, "Please enter your name");
            }
            else
            {
                errorProvider2.SetError(patname, null);
            }
        }

        private void Patid_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Patid.Text))
            {
                e.Cancel = true;
                Patid.Focus();
                errorProvider1.SetError(Patid, "Please enter your Id");
            }
            else
            {
                errorProvider1.SetError(Patid, null);
            }
        }

        private void patname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Patid_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Patid.Text = row.Cells["patId"].Value.ToString();
                patname.Text = row.Cells["Name"].Value.ToString();
                patgen.Text = row.Cells["Gender"].Value.ToString();
                patdob.Text = row.Cells["Age"].Value.ToString();
                cost.Text = row.Cells["Cost"].Value.ToString();
                room.Text = row.Cells["RoomNo"].Value.ToString();
                patphone.Text = row.Cells["Phonenumber"].Value.ToString();
                combo.Text = row.Cells["DoctorName"].Value.ToString();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

           
            DisplayRec();
            conn.Close();
        }
    }
}
