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
    public partial class admin_VendorReport : Form
    {
        public admin_VendorReport()
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

            OracleDataAdapter adp1 = new OracleDataAdapter("SELECT r.Vendor_id,s.name,r.Product_id,Sum(r.price) Amount_gained FROM Product r, Vendor s where r.Vendor_id = s.Vendor_id group by r.Vendor_id, s.name, r.product_id order by Sum(r.price) desc", conn);
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            dataGridView1.DataSource = dtt;

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();

            OracleDataAdapter adp1 = new OracleDataAdapter("SELECT r.Vendor_id,s.name,Sum(r.price) Amount_gained, Count(r.Product_id) Types_of_Products_sold FROM Product r, Vendor s where r.Vendor_id = s.Vendor_id group by r.Vendor_id, s.name order by Sum(r.price) desc", conn);
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            dataGridView2.DataSource = dtt;

            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            admin_reportMenu F3 = new admin_reportMenu();
            F3.Show();
        }

        private void admin_VendorReport_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
