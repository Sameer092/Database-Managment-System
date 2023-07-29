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
    public partial class admin_manageVendorAcc : Form
    {
        public admin_manageVendorAcc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_VendorAdd F3 = new admin_VendorAdd();
            F3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_VendorUpdate F3 = new admin_VendorUpdate();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_VendorDelete F3 = new admin_VendorDelete();
            F3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_VendorRetrieve F3 = new admin_VendorRetrieve();
            F3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_manageAccount F3 = new admin_manageAccount();
            F3.Show();
        }

        private void admin_manageVendorAcc_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
