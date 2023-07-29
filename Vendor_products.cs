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
    public partial class Vendor_products : Form
    {

        string v_id;
        public Vendor_products()
        {
            InitializeComponent();
        }

        public Vendor_products(string ID)
        {
            v_id = ID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_menu F3 = new vendor_menu();
            F3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();

            OracleCommand insertCRUD = conn.CreateCommand();
            insertCRUD.CommandText = "INSERT INTO product (PRODUCT_ID, VENDOR_ID, PRODUCT_NAME, BARCODE, PRICE, QUANTITY)VALUES(product_seq.nextval,"+ v_id +",'"+ textBox1.Text.ToString() + "',"+ textBox2.Text.ToString() + "," + textBox3.Text.ToString() + "," + numericUpDown1.Value.ToString() + ")";
            insertCRUD.CommandType = CommandType.Text;
            int rows = insertCRUD.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Inserted 1 row successfully.");
            }
            OracleDataAdapter adp1 = new OracleDataAdapter("SELECT * FROM PRODUCT WHERE vendor_id = '" + v_id + "'", conn);
            DataTable dtt = new DataTable();
            adp1.Fill(dtt);
            dataGridView1.DataSource = dtt;

            conn.Close();
        }

        private void Vendor_products_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            textBox4.Text = v_id;
        }
    }
}
