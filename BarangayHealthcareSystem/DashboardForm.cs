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
    public partial class DashboardForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SQLiteConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SQLiteCommand cmd1 = new SQLiteCommand("SELECT COUNT(*) FROM Patients", conn);
                    label_patients.Text = cmd1.ExecuteScalar().ToString();

                    SQLiteCommand cmd2 = new SQLiteCommand("SELECT COUNT(*) FROM Consultations", conn);
                    label_consultations.Text = cmd2.ExecuteScalar().ToString();

                    SQLiteCommand cmd3 = new SQLiteCommand("SELECT COUNT(*) FROM Medicines", conn);
                    label_medicines.Text = cmd3.ExecuteScalar().ToString();

                    SQLiteCommand cmd4 = new SQLiteCommand("SELECT COUNT(*) FROM Medicines WHERE Quantity <= 10", conn);
                    label_lowstock.Text = cmd4.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }
        private void LoadPatients()
        {
            try
            {
                using (SQLiteConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(
                        "SELECT PatientID, FirstName, LastName, Age, Gender, ContactNo FROM Patients",
                        conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPatients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
            }
        }
        private void LoadConsultations()
        {
            try
            {
                using (SQLiteConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(
                        "SELECT ConsultationID, PatientID, ConsultationDate, Diagnosis FROM Consultations",
                        conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvConsultations.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading consultations: " + ex.Message);
            }
        }
        private void LoadMedicines()
        {
            try
            {
                using (SQLiteConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(
                        "SELECT MedicineID, MedicineName, Category, Quantity, ExpirationDate FROM Medicines",
                        conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMedicines.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medicines: " + ex.Message);
            }
        }
        private void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.SelectionBackColor = Color.Teal;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.ScrollBars = ScrollBars.Both;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
            LoadPatients();
            LoadConsultations();
            LoadMedicines();

            LoadTodayEvents();

            StyleGrid(dgvPatients);
            StyleGrid(dgvConsultations);
            StyleGrid(dgvMedicines);

            lstTodayEvents.Font = new Font("Segoe UI", 10);
            lstTodayEvents.BackColor = Color.White;
            lstTodayEvents.ForeColor = Color.Black;
            lstTodayEvents.BorderStyle = BorderStyle.FixedSingle;
            lstTodayEvents.SelectionMode = SelectionMode.None;

        }
        private void LoadTodayEvents()
        {
            lstTodayEvents.Items.Clear();

            string today = DateTime.Now.ToString("yyyy-MM-dd");

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT Title, Description 
                    FROM CalendarEvents 
                    WHERE EventDate = @date
                    ORDER BY EventID DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string desc = reader["Description"].ToString();

                            lstTodayEvents.Items.Add($"📌 {title}");
                            lstTodayEvents.Items.Add($"   📝 {desc}");
                            lstTodayEvents.Items.Add(""); // spacing
                        }
                    }
                }
            }

            if (lstTodayEvents.Items.Count == 0)
            {
                lstTodayEvents.Items.Add("No events today.");
            }
        }

        private void dgvMedicines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return; // prevents header row error

            if (dgvMedicines.Rows.Count == 0) return; // prevent empty grid crash

            if (dgvMedicines.Columns.Count <= 3) return; // ensure column exists

            var value = dgvMedicines.Rows[e.RowIndex].Cells[3].Value;

            if (value == null) return;

            int quantity;

            if (int.TryParse(value.ToString(), out quantity))
            {
                if (quantity <= 10)
                {
                    dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvMedicines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void pnlTodayEvents_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
