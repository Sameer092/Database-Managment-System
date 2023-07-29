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
    public partial class admin_VendorDelete : Form
    {
        OracleConnection con;
        public admin_VendorDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Hide();
            admin_manageVendorAcc F3 = new admin_manageVendorAcc();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vendorID = textBox1.Text;

            con.Open();

            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = "DELETE FROM VENDOR WHERE Vendor_ID = :vendorID";
            command.Parameters.Add(":vendorID", OracleDbType.Varchar2).Value = vendorID;

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully.");
                OracleDataAdapter adp = new OracleDataAdapter("SELECT * from VENDOR", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Record not found or could not be deleted.");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin_VendorDelete_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();

            OracleDataAdapter adp = new OracleDataAdapter("SELECT * from VENDOR", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
