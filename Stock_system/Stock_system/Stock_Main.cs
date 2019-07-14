using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_system
{
    public partial class Stock_Main : Form
    {
        

        public Stock_Main()
        {
            InitializeComponent();
        }

        private void Stock_Main_Load(object sender, EventArgs e)
        {

        }

        private void Stock_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.MdiParent = this;
            products.Show();
        }
    }
}
