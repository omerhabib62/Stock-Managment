using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_system
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private void Load_page()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                string status = item["ProductStatus"].ToString();
                if (item["ProductStatus"].ToString()=="0")
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }


            }

        }
        private void Products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Load_page();
        }
         private bool ifRecordExists(SqlConnection con,string productcode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [Product] WHERE [ProductCode]='"+productcode+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            con.Open();
            int status = 1;
            if (comboBox1.SelectedIndex==0) {
                status = 0;
            }
            else
            {
                status = 1; 
            }
            var sqlQuery = @"";
            if (ifRecordExists(con,textBox1.Text))
            {
                sqlQuery = @"UPDATE [dbo].[Product] SET [ProductName] = '"+textBox2.Text+"',[ProductStatus] = "+status+" WHERE [ProductCode] = '" + textBox1.Text + "';";
            }
            else
            {
                sqlQuery= @"INSERT INTO [dbo].[Product]([ProductCode],[ProductName],[ProductStatus]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + status + "'); ";
            }
            SqlCommand cmd = new SqlCommand(sqlQuery,con);
            cmd.ExecuteNonQuery();
            con.Close();

            //Fill data table
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            dataGridView1.Rows.Clear();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                string statuss = item["ProductStatus"].ToString();
                if (item["ProductStatus"].ToString() == "0")
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }


            }

        }
       
        
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString()=="Active")
            {
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            var sqlQuery = @"";
            if (ifRecordExists(con,textBox1.Text))
            {
                con.Open();
                sqlQuery = @"DELETE FROM [Product] WHERE [ProductCode]='"+textBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record Not Exists...");
            }
            

            //Fill data table
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            dataGridView1.Rows.Clear();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                string statuss = item["ProductStatus"].ToString();
                if (item["ProductStatus"].ToString() == "0")
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedItem = null;
            textBox1.Focus();
        }
    }
}
