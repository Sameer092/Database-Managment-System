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
    public partial class salesman_forget : Form
    {
      
        public salesman_forget()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            bool isValidSalesman = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM salesman WHERE Email = '" + Email + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidSalesman = true;
            }
            conn.Close();
            if (isValidSalesman)
            {
                MessageBox.Show("Valid Email!");
                this.Hide();
                Form4 F4 = new Form4();
                F4.Show();
            }
            else
            {
                MessageBox.Show("Invalid Email. Please try again.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_signin F3 = new salesman_signin();
            F3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void salesman_forget_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
