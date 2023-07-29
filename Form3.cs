using System;
using Oracle.ManagedDataAccess.Client;
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
    public partial class customer_signin : Form
    {
        public customer_signin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string customerID = textBox1.Text;
            string password = textBox2.Text;
            bool isValidCustomer = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM customer WHERE username = '" + customerID + "' AND password = '" + password + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidCustomer = true;
            }
            conn.Close();
            if (isValidCustomer)
            {
                MessageBox.Show("Valid customer ID and password!");
                this.Hide();
                Customer_menu F3 = new Customer_menu();
                F3.Show();
            }
            else
            {
                MessageBox.Show("Invalid customer ID or password. Please try again.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_siginup F3 = new customer_siginup();
            F3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_forget F3 = new customer_forget();
            F3.Show();
        }

        private void customer_signin_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
