using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangayHealthcareSystem
{
    public partial class UserAccessForm : Form
    {
        public UserAccessForm()
        {
            InitializeComponent();
        }

        private void UserAccessForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminAccessPassword = "bhsadmin";

            if (txtAccessPassword.Text == adminAccessPassword)
            {
                UserAccountForm frm = new UserAccountForm();

                frm.MdiParent = Application.OpenForms["MainForm"] as MainForm;

                frm.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Incorrect administrator password!",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAccessPassword.Clear();
                txtAccessPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
