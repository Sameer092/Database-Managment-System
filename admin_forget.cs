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
    public partial class admin_forget : Form
    {
        public admin_forget()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_signin F3 = new admin_signin();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            bool isValidAdmin = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM ADMIN WHERE Email = '" + Email + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidAdmin = true;
            }
            conn.Close();
            if (isValidAdmin)
            {
                MessageBox.Show("Valid Email!");
                this.Hide();
                Form7 F7 = new Form7();
                F7.Show();
            }
            else
            {
                MessageBox.Show("Invalid Email. Please try again.");
            }
        }

        private void admin_forget_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
