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
    public partial class admin_salesmanReport : Form
    {
        public admin_salesmanReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_reportMenu F3 = new admin_reportMenu();
            F3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();

            OracleDataAdapter adp1 = new OracleDataAdapter("SELECT r.Salesman_id,s.name,r.reciept_id,Sum(r.total_amount) Amount_generated FROM Reciept r,Salesman s where r.salesman_id = s.salesman_id group by r.salesman_id,s.name,r.reciept_id order by Sum(r.total_amount) desc", conn);
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            dataGridView1.DataSource = dtt;

            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();

            OracleDataAdapter adp1 = new OracleDataAdapter("SELECT r.Salesman_id,s.name,Sum(r.total_amount) Amount_generated, Count(r.Salesman_id) Count_of_Sales_Made FROM Reciept r, Salesman s where r.salesman_id = s.salesman_id group by r.salesman_id, s.name order by Sum(r.total_amount) desc", conn);
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            dataGridView2.DataSource = dtt;

            conn.Close();
        }

        private void admin_salesmanReport_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
