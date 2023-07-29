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
    public partial class Customer_menu : Form
    {
        public Customer_menu()
        {
            InitializeComponent();
        }

        private void Customer_menu_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_return F3 = new customer_return();
            F3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_history F3 = new Customer_history();
            F3.Show();
        }
    }
}
