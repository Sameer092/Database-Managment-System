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
    public partial class vendor_signin : Form
    {
        public vendor_signin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_signup F3 = new vendor_signup();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vendorID = textBox1.Text;
            string password = textBox2.Text;
            bool isValidvendor = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM vendor WHERE username = '" + vendorID + "' AND password = '" + password + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidvendor = true;
            }
            if (isValidvendor)
            {
                MessageBox.Show("Valid vendor ID and password!");
                OracleCommand c = new OracleCommand("SELECT vendor_id FROM vendor WHERE username = '" + vendorID + "'", conn);
                string ID = Convert.ToString(c.ExecuteScalar());
                this.Hide();
                vendor_menu F3 = new vendor_menu(ID);
                F3.Show();
            }
            else
            {
                MessageBox.Show("Invalid vendor ID or password. Please try again.");
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
            vendor_forget F3 = new vendor_forget();
            F3.Show();
        }

        private void vendor_signin_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
