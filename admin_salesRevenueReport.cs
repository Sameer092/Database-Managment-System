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
    public partial class admin_salesRevenueReport : Form
    {
        public admin_salesRevenueReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_reportMenu F3 = new admin_reportMenu();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM reciept", conn);
            string count = Convert.ToString(cmd.ExecuteScalar());
            textBox2.Text = count;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT SUM(total_amount) FROM reciept", conn);
            string SUM = Convert.ToString(cmd.ExecuteScalar());
            textBox1.Text = SUM;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT SUM(total_amount) FROM reciept", conn);
            int SUM = Convert.ToInt32(cmd.ExecuteScalar());
            double rev = SUM * 0.1;
            textBox3.Text = rev.ToString();
            conn.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void admin_salesRevenueReport_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
