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
    public partial class Form7 : Form
    {
        OracleConnection con;
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string prevusername = textBox1.Text.ToString().Trim();
            string newPassword = textBox2.Text.ToString().Trim();

            string sql = "UPDATE ADMIN SET PASSWORD = :newPassword WHERE USERNAME = :prevusername";

            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":newPassword", newPassword);
            cmd.Parameters.Add(":username", prevusername);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Password updated successfully!");
            }
            else
            {
                MessageBox.Show("Unable to update password. Username not found.");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_signin zs = new admin_signin();
            zs.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
        }
    }
}
