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
    public partial class customer_return : Form
    {
        OracleConnection con;
        public customer_return()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_menu F3 = new salesman_menu();
            F3.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OracleDataAdapter adp = new OracleDataAdapter(@"SELECT r.Return_ID, r.Reciept_ID, r.Customer_ID, r.Product_ID, 
        r.Product_Name, r.Quantity, r.Reason, r.Quantity * p.Price AS Total, r.Return_DATE, r.Status 
        FROM RETURN r 
        INNER JOIN PRODUCT p ON r.Product_ID = p.Product_ID 
        WHERE r.Customer_ID = :customerId", con);
            adp.SelectCommand.Parameters.Add(":customerId", textBox1.Text.Trim());

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void customer_return_Load_1(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
        }

    }
}
