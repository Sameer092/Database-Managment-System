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
    public partial class salesman_newBill : Form
    {
        string C_id = "cccc";
        string S_id = "";
        string bill_id = "hhhh";
        string P_id = "pppp";
        string Price;

        public salesman_newBill()
        {
            InitializeComponent();
        }

        public salesman_newBill(string id)
        {
            S_id = id;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_menu F3 = new salesman_menu();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void salesman_newBill_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void salesman_newBill_Load_1(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            int c_id = 0;
            OracleConnection con;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();
            OracleCommand cmd = new OracleCommand("SELECT reciept_seq.NEXTVAL FROM dual", con);
            bill_id = Convert.ToString(cmd.ExecuteScalar());
            textBox6.Text = bill_id;
            textBox4.Text = S_id;
            OracleCommand ch_c = new OracleCommand("SELECT COUNT(*) FROM Customer", con);
            int count = Convert.ToInt32(ch_c.ExecuteScalar());
            bool isValidCust = false;
            if (count > 0)
            {
                isValidCust = true;
            }
            if (isValidCust)
            {
                OracleCommand cmd1 = new OracleCommand("SELECT customer_id from customer where rownum = 1", con);
                c_id = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            else
            {
                MessageBox.Show("No customer found! First enter Customer Data");
                this.Hide();
                salesman_menu F3 = new salesman_menu();
                F3.Show();
            }
            OracleCommand RCRUD = con.CreateCommand();
            RCRUD.CommandText = "INSERT INTO reciept (reciept_id, salesman_id, customer_id) VALUES('" + bill_id + "','" + S_id + "','" + c_id.ToString() + "')";
            RCRUD.CommandType = CommandType.Text;
            RCRUD.ExecuteNonQuery();
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string customerID = textBox3.Text;
            bool isValidCustomer = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM customer WHERE customer_id = '" + customerID + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidCustomer = true;
            }
            conn.Close();
            if (isValidCustomer)
            {
                MessageBox.Show("Valid customer ID");
                C_id = customerID;
            }
            else
            {
                MessageBox.Show("Invalid customer ID. Please try again.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string SalesmanID = textBox4.Text;
            bool isValidSalesman = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM salesman WHERE salesman_id = '" + SalesmanID + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidSalesman = true;
            }
            conn.Close();
            if (isValidSalesman)
            {
                MessageBox.Show("Valid salesman ID");
                S_id = SalesmanID;
            }
            else
            {
                MessageBox.Show("Invalid salesman ID. Please try again.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();

            string ProdID = textBox1.Text;
            P_id = ProdID;
            if (C_id == "cccc")
            {
                MessageBox.Show("Customer ID left blank!. Please Fill it.");
            }
            else if (P_id == "pppp")
            {
                MessageBox.Show("Prod ID left blank!. Please Fill it.");
            }
            else
            {
                ProdID = textBox1.Text;
                bool isValidProd = false;

                OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM PRODUCT WHERE Product_id = '" + ProdID + "'", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    isValidProd = true;
                }
                if (isValidProd)
                {
                    MessageBox.Show("Valid Prod ID");
                    P_id = ProdID;
                    OracleCommand cmd2 = new OracleCommand("SELECT price*" + numericUpDown1.Value.ToString() + " FROM PRODUCT WHERE Product_id = " + P_id, conn);
                    Price = Convert.ToString(cmd2.ExecuteScalar());
                    OracleCommand insertCRUD = conn.CreateCommand();
                    insertCRUD.CommandText = "INSERT INTO reciept_detail (reciept_id, salesman_id, customer_id, product_id, product_name, product_qty, product_price) VALUES('" + bill_id + "','" + S_id + "','" + C_id + "','" + P_id + "','" + textBox2.Text.ToString() + "'," + numericUpDown1.Value.ToString() + "," + Price + ")";
                    insertCRUD.CommandType = CommandType.Text;
                    int rows = insertCRUD.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Inserted 1 row successfully.");
                    }
                    OracleCommand UpdateCRUD = conn.CreateCommand();
                    UpdateCRUD.CommandText = "Update Product set quantity = quantity - " + numericUpDown1.Value.ToString() + " where product_id = " + P_id;
                    insertCRUD.CommandType = CommandType.Text;
                    UpdateCRUD.ExecuteNonQuery();
                    OracleDataAdapter adp1 = new OracleDataAdapter("SELECT * FROM RECIEPT_Detail WHERE Reciept_id = '" + bill_id + "'", conn);
                    DataTable dtt = new DataTable();
                    adp1.Fill(dtt);
                    dataGridView1.DataSource = dtt;
                }
                else
                {
                    MessageBox.Show("Invalid Prod ID. Please try again.");
                }
            }
            conn.Close();

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            if (C_id == "cccc")
            {
                MessageBox.Show("Customer ID left blank!. Please Fill it.");
            }
            else if (S_id == "ssss")
            {
                MessageBox.Show("Salesman ID left blank!. Please Fill it.");
            }
            else if (P_id == "pppp")
            {
                MessageBox.Show("Prod ID left blank!. Please Fill it.");
            }
            else
            {
                OracleCommand cmd = new OracleCommand("SELECT SUM(Product_Price) FROM Reciept_detail WHERE Reciept_id = '" + bill_id + "'", conn);
                string sum = Convert.ToString(cmd.ExecuteScalar());
                DateTime date = dateTimePicker1.Value;
                OracleCommand insertCRUD = conn.CreateCommand();
                insertCRUD.CommandText = "UPDATE reciept set Salesman_id = :salesman_id, Customer_id = :customer_id, r_date = :r_date, total_amount = :total_amount where reciept_id = :reciept_id";
                insertCRUD.CommandType = CommandType.Text;

                insertCRUD.Parameters.Add(new OracleParameter("salesman_id", S_id));
                insertCRUD.Parameters.Add(new OracleParameter("customer_id", C_id));
                insertCRUD.Parameters.Add(new OracleParameter("r_date", date));
                insertCRUD.Parameters.Add(new OracleParameter("total_amount", sum));
                insertCRUD.Parameters.Add(new OracleParameter("reciept_id", bill_id));
                int rows = insertCRUD.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Inserted 1 row successfully.");
                }
            }
            conn.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string customerID = textBox3.Text;
            bool isValidCustomer = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM customer WHERE customer_id = '" + customerID + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidCustomer = true;
            }
            conn.Close();
            if (isValidCustomer)
            {
                MessageBox.Show("Valid customer ID");
                C_id = customerID;
            }
            else
            {
                MessageBox.Show("Invalid customer ID. Please try again.");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string SalesmanID = textBox4.Text;
            bool isValidSalesman = false;

            OracleConnection conn;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            conn = new OracleConnection(conStr);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM salesman WHERE salesman_id = '" + SalesmanID + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                isValidSalesman = true;
            }
            conn.Close();
            if (isValidSalesman)
            {
                MessageBox.Show("Valid salesman ID");
                S_id = SalesmanID;
            }
            else
            {
                MessageBox.Show("Invalid salesman ID. Please try again.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            salesman_menu F3 = new salesman_menu();
            F3.Show();
        }
    }
}
