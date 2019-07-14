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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void Login_Load(object sender, EventArgs e)
        {

        }
        //clear button
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox1.Focus();
        }
        //login button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3KGLD3L;Initial Catalog=Stock;Persist Security Info=True;User ID=sa;Password=abc.123456789");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [UserName],[Password]FROM[dbo].[Login] Where UserName = '"+textBox1.Text+"' and Password = '"+textBox2.Text+"';", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count==1)
            {
                this.Hide();
                Stock_Main main = new Stock_Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                button2_Click(sender,e);
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
