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
    public partial class vendor_history : Form
    {
        OracleConnection con;
        public vendor_history()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_menu F3 = new vendor_menu();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter("SELECT * FROM PRODUCT WHERE Vendor_ID = '" + textBox1.Text.ToString() + "'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void vendor_history_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
