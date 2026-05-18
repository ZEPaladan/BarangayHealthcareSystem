using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangayHealthcareSystem
{
    public partial class InventoryForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public InventoryForm()
        {
            InitializeComponent();
        }
        // LOAD MEDICINES
        private void LoadMedicines()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM Medicines", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMedicines.DataSource = dt;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while loading medicines.\n\n" +
                    sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while loading medicines.\n\n" +
                    ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        // STYLE DATAGRIDVIEW
        private void StyleDataGridView()
        {
            dgvMedicines.BorderStyle = BorderStyle.None;

            dgvMedicines.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvMedicines.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvMedicines.BackgroundColor = Color.White;

            dgvMedicines.DefaultCellStyle.SelectionBackColor = Color.Teal;
            dgvMedicines.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvMedicines.RowHeadersVisible = false;

            dgvMedicines.EnableHeadersVisualStyles = false;

            dgvMedicines.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 120, 215);

            dgvMedicines.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvMedicines.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvMedicines.ColumnHeadersHeight = 35;

            dgvMedicines.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);

            dgvMedicines.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMedicines.RowTemplate.Height = 30;
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            StyleDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Medicines " +
                        "(MedicineName, Category, Quantity, Unit, ExpirationDate, Supplier) " +
                        "VALUES " +
                        "(@MedicineName, @Category, @Quantity, @Unit, @ExpirationDate, @Supplier)",
                        conn);

                    cmd.Parameters.AddWithValue("@MedicineName", txtMedicineName.Text);
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                    cmd.Parameters.AddWithValue("@ExpirationDate", dtpExpirationDate.Value);
                    cmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Medicine added successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    LoadMedicines();
                    ClearFields();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while saving medicine.\n\n" +
                    sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while saving medicine.\n\n" +
                    ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Medicines SET " +
                        "MedicineName=@MedicineName, " +
                        "Category=@Category, " +
                        "Quantity=@Quantity, " +
                        "Unit=@Unit, " +
                        "ExpirationDate=@ExpirationDate, " +
                        "Supplier=@Supplier " +
                        "WHERE MedicineID=@MedicineID",
                        conn);

                    cmd.Parameters.AddWithValue("@MedicineID",
                        dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

                    cmd.Parameters.AddWithValue("@MedicineName", txtMedicineName.Text);
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                    cmd.Parameters.AddWithValue("@ExpirationDate", dtpExpirationDate.Value);
                    cmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Medicine updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    LoadMedicines();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating medicine.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Medicines WHERE MedicineID=@MedicineID",
                        conn);

                    cmd.Parameters.AddWithValue("@MedicineID",
                        dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Medicine deleted successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    LoadMedicines();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting medicine.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvMedicines.Rows[e.RowIndex];

                    txtMedicineName.Text = row.Cells["MedicineName"].Value.ToString();
                    txtCategory.Text = row.Cells["Category"].Value.ToString();
                    txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                    txtUnit.Text = row.Cells["Unit"].Value.ToString();
                    txtSupplier.Text = row.Cells["Supplier"].Value.ToString();

                    dtpExpirationDate.Value =
                        Convert.ToDateTime(row.Cells["ExpirationDate"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error selecting medicine.\n\n" +
                    ex.Message,
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM Medicines WHERE MedicineName LIKE @search",
                        conn);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@search",
                        "%" + txtSearch.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMedicines.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search error.\n\n" +
                    ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        // CLEAR FIELDS
        private void ClearFields()
        {
            txtMedicineName.Clear();
            txtCategory.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtSupplier.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvMedicines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (dgvMedicines.Columns.Count <= 3) return;

                var value = dgvMedicines.Rows[e.RowIndex].Cells["Quantity"].Value;

                if (value == null) return;

                int quantity;

                if (int.TryParse(value.ToString(), out quantity))
                {
                    if (quantity <= 10)
                    {
                        dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                            Color.LightCoral;

                        dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.ForeColor =
                            Color.White;
                    }
                }
            }
            catch
            {
                // silent formatting protection
            }
        }
    }
}
