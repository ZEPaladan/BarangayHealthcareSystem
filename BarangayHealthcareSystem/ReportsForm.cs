using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangayHealthcareSystem
{
    public partial class ReportsForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public ReportsForm()
        {
            InitializeComponent();
        }
        // DATAGRIDVIEW STYLE
        private void StyleDataGridView()
        {
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReports.BackgroundColor = System.Drawing.Color.White;

            dgvReports.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
            dgvReports.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dgvReports.RowHeadersVisible = false;
            dgvReports.EnableHeadersVisualStyles = false;

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvReports.ColumnHeadersHeight = 35;
            dgvReports.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.RowTemplate.Height = 30;
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int y = 100;

                System.Drawing.Font titleFont =
                new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);

                System.Drawing.Font headerFont =
                    new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

                System.Drawing.Font cellFont =
                    new System.Drawing.Font("Segoe UI", 9);

                e.Graphics.DrawString(
                    "BARANGAY HEALTHCARE SYSTEM REPORT",
                    titleFont,
                    Brushes.Black,
                    250,
                    40
                );

                int x = 50;

                // PRINT COLUMN HEADERS
                foreach (DataGridViewColumn column in dgvReports.Columns)
                {
                    e.Graphics.DrawString(
                        column.HeaderText,
                        headerFont,
                        Brushes.Black,
                        x,
                        y
                    );

                    x += 150;
                }

                y += 40;

                // PRINT ROWS
                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    x = 50;

                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = "";

                            if (cell.Value != null)
                            {
                                value = cell.Value.ToString();
                            }

                            e.Graphics.DrawString(
                                value,
                                cellFont,
                                Brushes.Black,
                                x,
                                y
                            );

                            x += 150;
                        }

                        y += 30;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Print rendering error.\n\n" +
                    ex.Message,
                    "Printing Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // LOW STOCK HIGHLIGHT
        private void HighlightLowStock()
        {
            try
            {
                foreach (DataGridViewRow row in dgvReports.Rows)
                {
                    if (row.Cells["Quantity"].Value != null)
                    {
                        int quantity =
                            Convert.ToInt32(row.Cells["Quantity"].Value);

                        if (quantity <= 10)
                        {
                            row.DefaultCellStyle.BackColor =
                                System.Drawing.Color.LightCoral;

                            row.DefaultCellStyle.ForeColor =
                                System.Drawing.Color.White;
                        }
                    }
                }
            }
            catch
            {
                // Prevent formatting crash
            }
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            StyleDataGridView();

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void btnPatientsReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Patients", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReports.DataSource = dt;

                    MessageBox.Show("Patient report loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultationReport_Click(object sender, EventArgs e)
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
                            c.Diagnosis,
                            c.Prescription,
                            c.DoctorName
                        FROM Consultations c
                        INNER JOIN Patients p ON c.PatientID = p.PatientID", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReports.DataSource = dt;

                    MessageBox.Show("Consultation report loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMedicineReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Medicines", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReports.DataSource = dt;

                    HighlightLowStock();

                    MessageBox.Show("Medicine report loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReports.DataSource == null)
                {
                    MessageBox.Show("No data to search.");
                    return;
                }

                DataTable dt = (DataTable)dgvReports.DataSource;

                string search = txtSearch.Text.Trim().Replace("'", "''");

                if (string.IsNullOrEmpty(search))
                {
                    dt.DefaultView.RowFilter = "";
                    return;
                }

                // SAFE: generic search using only existing columns dynamically
                string filter = "";

                foreach (DataColumn col in dt.Columns)
                {
                    if (filter != "") filter += " OR ";

                    filter += $"Convert([{col.ColumnName}], 'System.String') LIKE '%{search}%'";
                }

                dt.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n\n" + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.DataSource = null;
                txtSearch.Clear();

                MessageBox.Show(
                    "Reports refreshed.",
                    "Refresh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error refreshing reports.\n\n" +
                    ex.Message,
                    "Refresh Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReports.DataSource == null || dgvReports.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.");
                    return;
                }

                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    FileName = "BarangayHealthcareReport.pdf",
                    Title = "Save PDF",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };

                if (save.ShowDialog() != DialogResult.OK)
                    return;

                string path = save.FileName;

                var columns = dgvReports.Columns.Cast<DataGridViewColumn>().ToList();
                var rows = dgvReports.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .ToList();

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(QuestPDF.Helpers.PageSizes.A4.Landscape());
                        page.Margin(20);

                        page.Header().Text("BARANGAY HEALTHCARE SYSTEM REPORT")
                            .FontSize(16)
                            .Bold()
                            .AlignCenter();

                        page.Content().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                foreach (var c in columns)
                                    cols.RelativeColumn();
                            });

                            // HEADER
                            table.Header(header =>
                            {
                                foreach (var col in columns)
                                {
                                    header.Cell()
                                        .Background("#D3D3D3")
                                        .Padding(5)
                                        .Text(col.HeaderText)
                                        .Bold();
                                }
                            });

                            // ROWS
                            foreach (var row in rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.Cell()
                                        .BorderBottom(1)
                                        .Padding(5)
                                        .Text(cell.Value?.ToString() ?? "");
                                }
                            }
                        });

                        page.Footer()
                            .AlignCenter()
                            .Text("Generated by Barangay Healthcare System");
                    });
                })
                .GeneratePdf(path);

                MessageBox.Show("PDF exported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Error: " + ex.Message);
            }
        }
    }
}
