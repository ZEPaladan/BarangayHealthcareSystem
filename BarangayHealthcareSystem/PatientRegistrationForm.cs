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
    public partial class PatientRegistrationForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public PatientRegistrationForm()
        {
            InitializeComponent();
        }
        // LOAD PATIENTS
        private void LoadPatients()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Patients", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPatients.DataSource = dt;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while loading patients.\n\n" +
                    "Error Message: " + sqlEx.Message + "\n" +
                    "Error Number: " + sqlEx.Number,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while loading patients.\n\n" +
                    "Error Message: " + ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtBirthdate.Clear();
            txtAddress.Clear();
            txtContactNo.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PatientRegistrationForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM Patients WHERE FirstName LIKE @search OR LastName LIKE @search", conn);

                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPatients.DataSource = dt;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while searching patient.\n\n" +
                    sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while searching patient.\n\n" +
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
                        "UPDATE Patients SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Age=@Age, Gender=@Gender, Birthdate=@Birthdate, Address=@Address, ContactNo=@ContactNo " +
                        "WHERE PatientID=@PatientID", conn);

                    cmd.Parameters.AddWithValue("@PatientID", dgvPatients.CurrentRow.Cells["PatientID"].Value);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@Birthdate", txtBirthdate.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Patient updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadPatients();
                    ClearFields();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(
                    "Please select a patient record to update.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while updating patient.\n\n" +
                    sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while updating patient.\n\n" +
                    ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Patients (FirstName, MiddleName, LastName, Age, Gender, Birthdate, Address, ContactNo) " +
                        "VALUES (@FirstName, @MiddleName, @LastName, @Age, @Gender, @Birthdate, @Address, @ContactNo)", conn);

                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@Birthdate", txtBirthdate.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Patient successfully added!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadPatients();
                    ClearFields();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Failed to save patient data to database.\n\n" +
                    "SQL Error: " + sqlEx.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected system error while saving patient.\n\n" +
                    "Error: " + ex.Message,
                    "System Error",
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
                        "DELETE FROM Patients WHERE PatientID=@PatientID", conn);

                    cmd.Parameters.AddWithValue("@PatientID", dgvPatients.CurrentRow.Cells["PatientID"].Value);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Patient deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadPatients();
                    ClearFields();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(
                    "Please select a patient record to delete.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Database error while deleting patient.\n\n" +
                    sqlEx.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected system error while deleting patient.\n\n" +
                    ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];

                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtMiddleName.Text = row.Cells["MiddleName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtGender.Text = row.Cells["Gender"].Value.ToString();
                txtBirthdate.Text = row.Cells["Birthdate"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtContactNo.Text = row.Cells["ContactNo"].Value.ToString();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
