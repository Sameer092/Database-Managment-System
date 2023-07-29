using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managment_System
{
    public partial class admin_inventory : Form
    {
        public admin_inventory()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_menu F3 = new admin_menu();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_allProducts F3 = new admin_allProducts();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_searchProducts ASP = new admin_searchProducts();
            ASP.Show();
        }

        private void admin_inventory_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
