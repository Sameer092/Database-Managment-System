using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace Managment_System
{
    public partial class salesman_signin : Form
    {
        public salesman_signin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_signup F3 = new salesman_signup();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string SalesmanID = textBox1.Text;
            string password = textBox2.Text;
            bool isValidSalesman = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM salesman WHERE username = '" + SalesmanID + "' AND password = '" + password + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidSalesman = true;
            }
            OracleCommand cmd2 = new OracleCommand("SELECT salesman_id FROM salesman WHERE username = '" + SalesmanID + "' AND password = '" + password + "'", conn);
            string s = Convert.ToString(cmd2.ExecuteScalar());
            if (isValidSalesman)
            {
                MessageBox.Show("Valid salesman ID and password!");
                this.Hide();
                salesman_menu F3 = new salesman_menu(s);
                F3.Show();
            }
            else
            {
                MessageBox.Show("Invalid salesman ID or password. Please try again.");
            }
            conn.Close();

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
            salesman_forget F3 = new salesman_forget();
            F3.Show();
        }
    }
}
