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
    public partial class vendor_menu : Form
    {
        string v_id;
        public vendor_menu()
        {
            InitializeComponent();
        }

        public vendor_menu(string ID)
        {
            v_id = ID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vendor_products F3 = new Vendor_products(v_id); ;
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_history VS = new vendor_history();
            VS.Show();
        }

        private void vendor_menu_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
