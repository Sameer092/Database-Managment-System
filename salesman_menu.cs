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
    public partial class salesman_menu : Form
    {
        string s_id;

        public salesman_menu()
        {
            InitializeComponent();
        }

        public salesman_menu(string id)
        {
            s_id = id;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_newBill F3 = new salesman_newBill(s_id);
            F3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_return F3 = new salesman_return();
            F3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void salesman_menu_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
