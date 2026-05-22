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
    public partial class UserAccountForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        int selectedUserID = -1;
        public UserAccountForm()
        {
            InitializeComponent();
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            LoadUsers();
        }

        // ================= LOAD USERS =================
        private void LoadUsers()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT UserID, Username, Role FROM Users";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUsers.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                INSERT INTO Users (Username, Password, Role)
                VALUES (@u, @p, @r)";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@r", cmbRole.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User added!");
            ClearFields();
            LoadUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedUserID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);

            txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            cmbRole.Text = dgvUsers.Rows[e.RowIndex].Cells["Role"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1) return;

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                UPDATE Users
                SET Username=@u,
                    Password=@p,
                    Role=@r
                WHERE UserID=@id";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@r", cmbRole.Text);
                cmd.Parameters.AddWithValue("@id", selectedUserID);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User updated!");
            ClearFields();
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1) return;

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM Users WHERE UserID=@id";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedUserID);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User deleted!");
            ClearFields();
            LoadUsers();
        }
        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cmbRole.SelectedIndex = -1;

            selectedUserID = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
    

