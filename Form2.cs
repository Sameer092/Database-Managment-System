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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_signin F3 = new customer_signin();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_signin F3 = new vendor_signin();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_signin F3 = new admin_signin();
            F3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_signin F3 = new salesman_signin();
            F3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F3 = new Form1();
            F3.Show();
        }
    }
}
