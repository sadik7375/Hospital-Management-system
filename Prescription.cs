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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
          DisplayRec();
            RepLb.Enabled = false;
            DocLb.Enabled = false;
            paLb.Enabled = false;
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wahid\OneDrive\Documents\HMinfo.mdf;Integrated Security=True;Connect Timeout=30");
        private void Prescription_Load(object sender, EventArgs e)
        {

        }
        private void DisplayRec()
        {

            string Query = "Select* from Prescription";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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

        private void Add_Click(object sender, EventArgs e)
        {
            if (Docname.Text == "" || Patname.Text == "" || medicine.Text == "" || Test.Text == "" || date.Text == "" || pres.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cdm = new SqlCommand("insert into  Prescription values(@Presid,@DoctorName,@PatienName,@Medicine,@Test,@Date)", conn);
                    cdm.Parameters.AddWithValue("Presid", int.Parse(pres.Text));
                    cdm.Parameters.AddWithValue("DoctorName", Docname.Text);
                    cdm.Parameters.AddWithValue("PatienName", Patname.Text);
                    cdm.Parameters.AddWithValue("Date", date.Text);
                    cdm.Parameters.AddWithValue("Medicine", medicine.Text);
                    cdm.Parameters.AddWithValue("Test", Test.Text);
                    cdm.ExecuteNonQuery();


                    //MessageBox.Show("patient Added");
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

        private void Delete_Click(object sender, EventArgs e)
        { int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            conn.Open();
            SqlCommand cdm = new SqlCommand("Delete Prescription where PresId=@PresId", conn);

            cdm.Parameters.AddWithValue("PresId", int.Parse(pres.Text));
            cdm.ExecuteNonQuery();
            conn.Close();
            DisplayRec();
            MessageBox.Show("Successfully Deleted");
            conn.Close();
        }

        private void datagview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              
            
        }

        private void Docname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Docname.Text))
            {
                e.Cancel = true;
                Docname.Focus();
                errorProvider1.SetError(Docname, "Please select your position");
            }
            else
            {
                errorProvider1.SetError(Docname, null);
            }
        }

        private void pres_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(pres.Text))
            {
                e.Cancel = true;
                pres.Focus();
                errorProvider2.SetError(pres, "Please enter your Id");
            }
            else
            {
                errorProvider2.SetError(pres, null);
            }
        }

        private void Patname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Patname.Text))
            {
                e.Cancel = true;
                Patname.Focus();
                errorProvider3.SetError(Patname, "Please enter patient name");
            }
            else
            {
                errorProvider3.SetError(Patname, null);
            }
        }

        private void sd(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                pres.Text = row.Cells["PresId"].Value.ToString();
                Docname.Text = row.Cells["DoctorName"].Value.ToString();
                Patname.Text = row.Cells["PatientName"].Value.ToString();
                medicine.Text = row.Cells["Medicine"].Value.ToString();
                Test.Text = row.Cells["Test"].Value.ToString();
                date.Text = row.Cells["Date"].Value.ToString();
                rich.Text = "/n/n/n/n";
                rich.Text ="\n\n\n\n\n                                     Newlife Hospital\n\n" + "                                     PRESCRIPTION           " + "\n" + "\n      Doctor Name:" + row.Cells["DoctorName"].Value.ToString() +"                Patien:" + row.Cells["PatientName"].Value.ToString() + "\n\n   " +"   "+"Medicine:"+ row.Cells["Medicine"].Value.ToString()+"           "+ "      Date:"+row.Cells["Date"].Value.ToString()+ "\n\n\n                                       Thank You";
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {








        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          // rich.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            //if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            //{/
                //printDocument1.Print();
            //}
        }

        private void DocLb_Click(object sender, EventArgs e)
        {

        }
    }
}

