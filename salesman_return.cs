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
    public partial class salesman_return : Form
    {
        OracleConnection connection;
        public salesman_return()
        {
            InitializeComponent();
            string conStr1 = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            connection = new OracleConnection(conStr1);
            connection.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesman_menu F3 = new salesman_menu();
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string receiptId = textBox4.Text;
            string productId = textBox1.Text;
            string customerId = textBox5.Text;
            string productName = textBox3.Text;
            decimal quantity = numericUpDown1.Value;
            string reason = textBox1.Text;

            bool isValidReturn = CheckReturnValidity(receiptId, productId, customerId);

            if (isValidReturn)
            {
                // Add the information to the return table
                AddReturnInfo(receiptId, productId, customerId, productName, quantity, reason);

                MessageBox.Show("Return added successfully.");
            }
            else
            {
                MessageBox.Show("Invalid return information.");
            }
        }

        private bool CheckReturnValidity(string receiptId, string productId, string customerId)
        {
            bool isValid = false;

            string receiptQuery = "SELECT Reciept_ID FROM Reciept WHERE Reciept_ID = :ReceiptId";
            string productQuery = "SELECT Product_ID FROM Product WHERE Product_ID = :ProductID";
            string customerQuery = "SELECT Customer_ID FROM Customer WHERE Customer_ID = :CustomerID";

            // Compare with Receipt table
            using (OracleCommand command = new OracleCommand(receiptQuery, connection))
            {
                command.Parameters.Add("@ReceiptId", OracleDbType.Varchar2).Value = receiptId;
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isValid = true;
                }
            }

            // Compare with Product table
            using (OracleCommand command = new OracleCommand(productQuery, connection))
            {
                command.Parameters.Add("@ProductID", OracleDbType.Varchar2).Value = productId;
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false; // ProductID doesn't exist in the Product table
                }
            }

            // Compare with Customer table
            using (OracleCommand command = new OracleCommand(customerQuery, connection))
            {
                command.Parameters.Add("@CustomerID", OracleDbType.Varchar2).Value = customerId;
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false; // CustomerID doesn't exist in the Customer table
                }
            }

            return isValid;
        }

        private void AddReturnInfo(string receiptId, string productId, string customerId, string productName, decimal quantity, string reason)
        {
            // Insert into Return table
            string insertQuery = "INSERT INTO RETURN(Return_ID,Reciept_ID, Customer_ID, Product_ID, Product_NAME, QUANTITY, REASON) " +
                "VALUES (1235, :ReceiptID, :CustomerID, :ProductID, :ProductName, :Quantity, :Reason)";
            //"VALUES (1234'" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + numericUpDown1.Text.ToString() + "','" + textBox3.Text.ToString() + "')";

            using (OracleCommand command = new OracleCommand(insertQuery, connection))
            {
                command.Parameters.Add("@ReceiptID", OracleDbType.Varchar2).Value = receiptId;
                command.Parameters.Add("@ProductID", OracleDbType.Varchar2).Value = productId;
                command.Parameters.Add("@CustomerID", OracleDbType.Varchar2).Value = customerId;
                command.Parameters.Add("@ProductName", OracleDbType.Varchar2).Value = productName;
                command.Parameters.Add("@Quantity", OracleDbType.Int32).Value = quantity;
                command.Parameters.Add("@Reason", OracleDbType.Varchar2).Value = reason;


                command.ExecuteNonQuery();
            }
        }

        private void salesman_return_Load(object sender, EventArgs e)
        {

        }

        private void salesman_return_Load_1(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}