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
    public partial class admin_signin : Form
    {
        public admin_signin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_signup F3 = new admin_signup();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string adminID = textBox1.Text;
            string password = textBox2.Text;
            bool isValidadmin = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM admin WHERE username = '" + adminID + "' AND password = '" + password + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidadmin = true;
            }
            conn.Close();
            if (isValidadmin)
            {
                MessageBox.Show("Valid admin ID and password!");
                //Do admin part
                this.Hide();
                admin_menu F3 = new admin_menu();
                F3.Show();
            }
            else
            {
                MessageBox.Show("Invalid admin ID or password. Please try again.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F3 = new Form2();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_forget F3 = new admin_forget();
            F3.Show();
        }

        private void admin_signin_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
