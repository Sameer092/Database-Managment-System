using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace Managment_System
{
    public partial class vendor_signup : Form
    {
        OracleConnection con;
        public vendor_signup()
        {

            InitializeComponent();
        }

        private void vendor_signup_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight); 
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=FINALPROJECT;PASSWORD=fullmarks100";
            con = new OracleConnection(conStr);
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
            con.Open();
            OracleCommand insertCRUD = con.CreateCommand();
            string name = textBox1.Text;
            string accountNo = textBox5.Text;
            string contact = textBox6.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;
            string username = textBox4.Text;

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
                insertCRUD.CommandText = "INSERT INTO VENDOR(Vendor_ID,Name,Account_No,Contact,Email,Password,Username) VALUES (vendor_seq.nextval, '" + textBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "')";
                insertCRUD.CommandType = CommandType.Text;
                int rows = insertCRUD.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Thank you for signup\nHave a Great Day!!!");

                }
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendor_signin F3 = new vendor_signin();
            F3.Show();
        }
    }
}
