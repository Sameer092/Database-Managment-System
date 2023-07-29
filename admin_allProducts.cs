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
    public partial class admin_allProducts : Form
    {
        OracleConnection con;
        public admin_allProducts()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_inventory F3 = new admin_inventory();
            F3.Show();
        }

        private void admin_allProducts_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter(
                "SELECT P.*, C.CATEGORY_ID, C.CATEGORY_NAME, R.RACK_NO, R.LOCATION " +
                "FROM PRODUCT P " +
                "JOIN CATEGORY C ON P.PRODUCT_ID = C.PRODUCT_ID " +
                "JOIN RACK R ON P.PRODUCT_ID = R.PRODUCT_ID", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
