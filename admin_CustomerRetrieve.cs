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
    public partial class admin_CustomerRetrieve : Form
    {
        OracleConnection con;
        public admin_CustomerRetrieve()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter("SELECT * FROM CUSTOMER WHERE Customer_ID = '" + textBox1.Text.ToString() + "'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin_CustomerRetrieve_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter("SELECT * FROM CUSTOMER ", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Close();
            this.Hide();
            admin_manageCustomerAcc F3 = new admin_manageCustomerAcc();
            F3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void admin_CustomerRetrieve_Load_1(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
