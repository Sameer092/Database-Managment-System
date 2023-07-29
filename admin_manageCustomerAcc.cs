using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managment_System
{
    public partial class admin_manageCustomerAcc : Form
    {
        public admin_manageCustomerAcc()
        {
            InitializeComponent();
        }

        private void BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_manageAccount F3 = new admin_manageAccount();
            F3.Show();
        }


        private void DELETE_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_CustomerDelete F3 = new admin_CustomerDelete();
            F3.Show();
        }

        private void UPDATER_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_CustomerUpdate F3 = new admin_CustomerUpdate();
            F3.Show();
        }

        private void RETRIEVE_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin_CustomerRetrieve F3 = new admin_CustomerRetrieve();
            F3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ADD_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            admin_CustomerAdd F3 = new admin_CustomerAdd();
            F3.Show();
        }

        private void admin_manageCustomerAcc_Load(object sender, EventArgs e)
        {
            int desiredWidth = 900;
            int desiredHeight = 500;
            this.Size = new Size(desiredWidth, desiredHeight);
        }
    }
}
