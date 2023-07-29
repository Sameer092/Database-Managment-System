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
    public partial class admin_reportMenu : Form
    {
        public admin_reportMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_menu F3 = new admin_menu();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_salesRevenueReport F3 = new admin_salesRevenueReport();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_customerReportForm8 F3 = new admin_customerReportForm8();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_salesmanReport F3 = new admin_salesmanReport();
            F3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_VendorReport F3 = new admin_VendorReport();
            F3.Show();
        }

        private void admin_reportMenu_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
