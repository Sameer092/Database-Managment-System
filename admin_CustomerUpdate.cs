using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Oracle.ManagedDataAccess.Client;
namespace Managment_System
{
    public partial class admin_CustomerUpdate : Form
    {
        OracleConnection con;
        public admin_CustomerUpdate()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        bool IsNumeric(string input)
        {
            return int.TryParse(input, out int intValue) || double.TryParse(input, out double doubleValue);
        }

        public bool IsValidEmail(string email)
        {
            // Email pattern regular expression
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            Match match = Regex.Match(email, pattern);

            // Return true if the email is valid, false otherwise
            return match.Success;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            string accountNo = textBox3.Text.Trim();
            string contact = textBox4.Text.Trim();
            string email = textBox5.Text.Trim();
            string password = textBox6.Text.Trim();
            string username = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a valid name.");
            }
            else if (!int.TryParse(accountNo, out int accountNoValue))
            {
                MessageBox.Show("Please enter a valid account number.");
            }
            else if (string.IsNullOrEmpty(contact) || !IsNumeric(contact))
            {
                MessageBox.Show("Please enter a valid contact number.");
            }
            else if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a valid password.");
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a valid username.");
            }
            else
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUSTOMER SET Name = :name, Account_No = :accountNo, Contact = :contact, Email = :email, Password = :password, Username = :username WHERE Customer_ID = :customerId";
                    cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = textBox2.Text.Trim();
                    cmd.Parameters.Add("accountNo", OracleDbType.Varchar2).Value = textBox3.Text.Trim();
                    cmd.Parameters.Add("contact", OracleDbType.Varchar2).Value = textBox4.Text.Trim();
                    cmd.Parameters.Add("email", OracleDbType.Varchar2).Value = textBox5.Text.Trim();
                    cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = textBox6.Text.Trim();
                    cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = textBox7.Text.Trim();
                    cmd.Parameters.Add("customerId", OracleDbType.Varchar2).Value = textBox1.Text.Trim();
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Customer information updated successfully!");
                        textBox1.ReadOnly = false;
                        this.Hide();
                        admin_manageCustomerAcc F3 = new admin_manageCustomerAcc();
                        F3.Show();
                    }
                    else
                    {
                        textBox1.ReadOnly = false;
                        MessageBox.Show("No rows were updated.");
                        this.Hide();
                        admin_manageCustomerAcc F3 = new admin_manageCustomerAcc();
                        F3.Show();
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void admin_CustomerUpdate_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string customerId = textBox1.Text.Trim();

            textBox1.ReadOnly = true;
            OracleCommand cmd = new OracleCommand("SELECT * FROM CUSTOMER WHERE CUSTOMER_ID = :customerId", con);
            cmd.Parameters.Add("customerId", OracleDbType.Varchar2).Value = customerId;

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                string name = reader.GetString(reader.GetOrdinal("NAME"));
                string accountNo = reader.GetString(reader.GetOrdinal("ACCOUNT_NO"));
                string contact = reader.GetString(reader.GetOrdinal("CONTACT"));
                string email = reader.GetString(reader.GetOrdinal("EMAIL"));
                string password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                string username = reader.GetString(reader.GetOrdinal("USERNAME"));

                textBox2.Text = name;
                textBox3.Text = accountNo;
                textBox4.Text = contact;
                textBox5.Text = email;
                textBox6.Text = password;
                textBox7.Text = username;
            }
            else
            {
                MessageBox.Show("Customer ID not found.");
            }

            reader.Close();

        }
    }
}
