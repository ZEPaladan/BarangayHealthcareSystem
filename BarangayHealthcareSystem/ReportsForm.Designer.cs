namespace BarangayHealthcareSystem
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPatientsReport = new System.Windows.Forms.Button();
            this.btnConsultationReport = new System.Windows.Forms.Button();
            this.btnMedicineReport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Montserrat SemiBold", 11.13402F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Search Report:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "GENERATE REPORTS";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Montserrat SemiBold", 11.13402F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(140, 83);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(267, 26);
            this.txtSearch.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(332, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(12, 211);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.Size = new System.Drawing.Size(902, 383);
            this.dgvReports.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 11.13402F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "REPORT DATA";
            // 
            // btnPatientsReport
            // 
            this.btnPatientsReport.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientsReport.Location = new System.Drawing.Point(12, 182);
            this.btnPatientsReport.Name = "btnPatientsReport";
            this.btnPatientsReport.Size = new System.Drawing.Size(120, 23);
            this.btnPatientsReport.TabIndex = 28;
            this.btnPatientsReport.Text = "Patient Report";
            this.btnPatientsReport.UseVisualStyleBackColor = true;
            this.btnPatientsReport.Click += new System.EventHandler(this.btnPatientsReport_Click);
            // 
            // btnConsultationReport
            // 
            this.btnConsultationReport.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultationReport.Location = new System.Drawing.Point(138, 182);
            this.btnConsultationReport.Name = "btnConsultationReport";
            this.btnConsultationReport.Size = new System.Drawing.Size(140, 23);
            this.btnConsultationReport.TabIndex = 29;
            this.btnConsultationReport.Text = "Consultation Report";
            this.btnConsultationReport.UseVisualStyleBackColor = true;
            this.btnConsultationReport.Click += new System.EventHandler(this.btnConsultationReport_Click);
            // 
            // btnMedicineReport
            // 
            this.btnMedicineReport.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicineReport.Location = new System.Drawing.Point(284, 182);
            this.btnMedicineReport.Name = "btnMedicineReport";
            this.btnMedicineReport.Size = new System.Drawing.Size(140, 23);
            this.btnMedicineReport.TabIndex = 30;
            this.btnMedicineReport.Text = "Medicine Report";
            this.btnMedicineReport.UseVisualStyleBackColor = true;
            this.btnMedicineReport.Click += new System.EventHandler(this.btnMedicineReport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Cyan;
            this.btnRefresh.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(823, 182);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(91, 23);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportPDF.Font = new System.Drawing.Font("Montserrat SemiBold", 8.907216F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.Location = new System.Drawing.Point(726, 182);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(91, 23);
            this.btnExportPDF.TabIndex = 33;
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::BarangayHealthcareSystem.Properties.Resources.Minimal_modern_healthcare_background__soft_202605222224;
            this.ClientSize = new System.Drawing.Size(926, 606);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnMedicineReport);
            this.Controls.Add(this.btnConsultationReport);
            this.Controls.Add(this.btnPatientsReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPatientsReport;
        private System.Windows.Forms.Button btnConsultationReport;
        private System.Windows.Forms.Button btnMedicineReport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportPDF;
    }
}