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
    public partial class admin_CustomerDelete : Form
    {
        OracleConnection con;
        public admin_CustomerDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Hide();
            admin_manageCustomerAcc F3 = new admin_manageCustomerAcc();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerID = textBox1.Text;


            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = "DELETE FROM CUSTOMER WHERE Customer_ID = :customerID";
            command.Parameters.Add(":customerID", OracleDbType.Varchar2).Value = customerID;

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully.");
                OracleDataAdapter adp = new OracleDataAdapter("SELECT * from CUSTOMER", con);
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

        private void admin_CustomerDelete_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();

            OracleDataAdapter adp = new OracleDataAdapter("SELECT * from CUSTOMER", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
