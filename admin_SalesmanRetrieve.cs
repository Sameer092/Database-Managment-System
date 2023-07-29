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
    public partial class admin_SalesmanRetrieve : Form
    {
        OracleConnection con;
        public admin_SalesmanRetrieve()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Close();
            this.Hide();
            admin_manageSalesmanAcc F3 = new admin_manageSalesmanAcc();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter("SELECT * FROM SALESMAN WHERE Salesman_ID = '" + textBox1.Text.ToString() + "'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void admin_SalesmanRetrieve_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter("SELECT * FROM SALESMAN ", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
