using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangayHealthcareSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textbox_password.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                using (SQLiteConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT COUNT(*) 
                FROM Users 
                WHERE Username=@username 
                AND Password=@password";

                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", textbox_username.Text);
                    cmd.Parameters.AddWithValue("@password", textbox_password.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");

                        this.Hide();

                        MainForm mdi = new MainForm();
                        mdi.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error:\n" + ex.Message);
            }
        }

        private void checkbox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked)
            {
                textbox_password.UseSystemPasswordChar = false;
            }
            else
            {
                textbox_password.UseSystemPasswordChar = true;
            }
        }
    }
}
