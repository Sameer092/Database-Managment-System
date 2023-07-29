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
    public partial class vendor_forget : Form
    {
        public vendor_forget()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_signin F3 = new vendor_signin();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            bool isValidVendor = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM VENDOR WHERE Email = '" + Email + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidVendor = true;
            }
            conn.Close();
            if (isValidVendor)
            {
                MessageBox.Show("Valid Email!");
                this.Hide();
                Form5 F5 = new Form5();
                F5.Show();
            }
            else
            {
                MessageBox.Show("Invalid Email. Please try again.");
            }
        }

        private void vendor_forget_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
