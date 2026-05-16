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
    
    public partial class ConsultationForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public ConsultationForm()
        {
            InitializeComponent();
        }

        private void ConsultationForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            LoadConsultations();
        }
        // CLEAR FIELDS
        private void ClearFields()
        {
            txtSymptoms.Clear();
            txtDiagnosis.Clear();
            txtPrescription.Clear();
            txtDoctorName.Clear();
        }

        // LOAD PATIENTS INTO COMBOBOX
        private void LoadPatients()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT PatientID, FirstName + ' ' + LastName AS FullName FROM Patients", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPatient.DataSource = dt;
                    cmbPatient.DisplayMember = "FullName";
                    cmbPatient.ValueMember = "PatientID";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading patients:\n" + ex.Message);
            }
        }

        // LOAD CONSULTATIONS
        private void LoadConsultations()
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(@"
                        SELECT 
                            c.ConsultationID,
                            p.FirstName + ' ' + p.LastName AS PatientName,
                            c.ConsultationDate,
                            c.Symptoms,
                            c.Diagnosis,
                            c.Prescription,
                            c.DoctorName
                        FROM Consultations c
                        INNER JOIN Patients p ON c.PatientID = p.PatientID", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvConsultations.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading consultations:\n" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO Consultations 
                        (PatientID, ConsultationDate, Symptoms, Diagnosis, Prescription, DoctorName)
                        VALUES
                        (@PatientID, @ConsultationDate, @Symptoms, @Diagnosis, @Prescription, @DoctorName)", conn);

                    cmd.Parameters.AddWithValue("@PatientID", cmbPatient.SelectedValue);
                    cmd.Parameters.AddWithValue("@ConsultationDate", dtpConsultationDate.Value);
                    cmd.Parameters.AddWithValue("@Symptoms", txtSymptoms.Text);
                    cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                    cmd.Parameters.AddWithValue("@Prescription", txtPrescription.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Consultation saved successfully!");
                    }

                    LoadConsultations();
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error while saving consultation:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n" + ex.Message);
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
                        "DELETE FROM Consultations WHERE ConsultationID=@id", conn);

                    cmd.Parameters.AddWithValue("@id", dgvConsultations.CurrentRow.Cells["ConsultationID"].Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Deleted successfully!");

                    LoadConsultations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting consultation:\n" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(@"
                        SELECT 
                            c.ConsultationID,
                            p.FirstName + ' ' + p.LastName AS PatientName,
                            c.ConsultationDate,
                            c.Diagnosis
                        FROM Consultations c
                        INNER JOIN Patients p ON c.PatientID = p.PatientID
                        WHERE p.FirstName LIKE @search OR p.LastName LIKE @search", conn);

                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvConsultations.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message);
            }
        }
    }
}
