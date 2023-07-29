using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace Managment_System
{
    public partial class customer_forget : Form
    {
        public customer_forget()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_signin F3 = new customer_signin();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            bool isValidCustomer = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM CUSTOMER WHERE Email = '" + Email + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidCustomer = true;
            }
            conn.Close();
            if (isValidCustomer)
            {
                MessageBox.Show("Valid Email!");
                this.Hide();
                Form6 F6 = new Form6();
                F6.Show();
            }
            else
            {
                MessageBox.Show("Invalid Email. Please try again.");
            }
        }

        private void customer_forget_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
