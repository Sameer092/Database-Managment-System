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
    public partial class admin_manageSalesmanAcc : Form
    {
        public admin_manageSalesmanAcc()
        {
            InitializeComponent();
        }

        private void admin_manageSalesmanAcc_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_SalesmanRetrieve F3 = new admin_SalesmanRetrieve();
            F3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_SalesmanDelete F3 = new admin_SalesmanDelete();
            F3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_SalesmanUpdate F3 = new admin_SalesmanUpdate();
            F3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_SalesmanAdd F3 = new admin_SalesmanAdd();
            F3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_manageAccount F3 = new admin_manageAccount();
            F3.Show();
        }
    }
}
