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
    public partial class admin_menu : Form
    {
        public admin_menu()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_reportMenu F3 = new admin_reportMenu();
            F3.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_inventory AI = new admin_inventory();
            AI.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_manageAccount F3 = new admin_manageAccount();
            F3.Show();
        }

        private void admin_menu_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
