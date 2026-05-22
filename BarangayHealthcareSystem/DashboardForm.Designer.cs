namespace BarangayHealthcareSystem
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.label_patients = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvConsultations = new System.Windows.Forms.DataGridView();
            this.label_consultations = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.label_lowstock = new System.Windows.Forms.Label();
            this.label_medicines = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTodayEvents = new System.Windows.Forms.Panel();
            this.lstTodayEvents = new System.Windows.Forms.ListBox();
            this.lblTodayEventsTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultations)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.pnlTodayEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "BARANGAY HEALTHCARE SYSTEM DASHBOARD";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvPatients);
            this.panel1.Controls.Add(this.label_patients);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 550);
            this.panel1.TabIndex = 1;
            // 
            // dgvPatients
            // 
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Location = new System.Drawing.Point(7, 54);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.Size = new System.Drawing.Size(375, 491);
            this.dgvPatients.TabIndex = 7;
            // 
            // label_patients
            // 
            this.label_patients.AutoSize = true;
            this.label_patients.BackColor = System.Drawing.Color.Transparent;
            this.label_patients.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_patients.Location = new System.Drawing.Point(218, 14);
            this.label_patients.Name = "label_patients";
            this.label_patients.Size = new System.Drawing.Size(21, 24);
            this.label_patients.TabIndex = 6;
            this.label_patients.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Patients:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvConsultations);
            this.panel2.Controls.Add(this.label_consultations);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(401, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 550);
            this.panel2.TabIndex = 2;
            // 
            // dgvConsultations
            // 
            this.dgvConsultations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultations.Location = new System.Drawing.Point(4, 54);
            this.dgvConsultations.Name = "dgvConsultations";
            this.dgvConsultations.Size = new System.Drawing.Size(378, 491);
            this.dgvConsultations.TabIndex = 8;
            // 
            // label_consultations
            // 
            this.label_consultations.AutoSize = true;
            this.label_consultations.BackColor = System.Drawing.Color.Transparent;
            this.label_consultations.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_consultations.Location = new System.Drawing.Point(218, 14);
            this.label_consultations.Name = "label_consultations";
            this.label_consultations.Size = new System.Drawing.Size(21, 24);
            this.label_consultations.TabIndex = 8;
            this.label_consultations.Text = "0";
            this.label_consultations.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Consultations:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgvMedicines);
            this.panel4.Controls.Add(this.label_lowstock);
            this.panel4.Controls.Add(this.label_medicines);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(792, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 550);
            this.panel4.TabIndex = 3;
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Location = new System.Drawing.Point(5, 54);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.Size = new System.Drawing.Size(375, 491);
            this.dgvMedicines.TabIndex = 8;
            this.dgvMedicines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMedicines_CellFormatting);
            // 
            // label_lowstock
            // 
            this.label_lowstock.AutoSize = true;
            this.label_lowstock.BackColor = System.Drawing.Color.Transparent;
            this.label_lowstock.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lowstock.Location = new System.Drawing.Point(218, 24);
            this.label_lowstock.Name = "label_lowstock";
            this.label_lowstock.Size = new System.Drawing.Size(21, 24);
            this.label_lowstock.TabIndex = 12;
            this.label_lowstock.Text = "0";
            // 
            // label_medicines
            // 
            this.label_medicines.AutoSize = true;
            this.label_medicines.BackColor = System.Drawing.Color.Transparent;
            this.label_medicines.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_medicines.Location = new System.Drawing.Point(218, 0);
            this.label_medicines.Name = "label_medicines";
            this.label_medicines.Size = new System.Drawing.Size(21, 24);
            this.label_medicines.TabIndex = 10;
            this.label_medicines.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Low Stock Medicines:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Medicines:";
            // 
            // pnlTodayEvents
            // 
            this.pnlTodayEvents.BackColor = System.Drawing.Color.Transparent;
            this.pnlTodayEvents.Controls.Add(this.lstTodayEvents);
            this.pnlTodayEvents.Controls.Add(this.lblTodayEventsTitle);
            this.pnlTodayEvents.Location = new System.Drawing.Point(1183, 54);
            this.pnlTodayEvents.Name = "pnlTodayEvents";
            this.pnlTodayEvents.Size = new System.Drawing.Size(240, 330);
            this.pnlTodayEvents.TabIndex = 13;
            this.pnlTodayEvents.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTodayEvents_Paint);
            // 
            // lstTodayEvents
            // 
            this.lstTodayEvents.FormattingEnabled = true;
            this.lstTodayEvents.Location = new System.Drawing.Point(13, 53);
            this.lstTodayEvents.Name = "lstTodayEvents";
            this.lstTodayEvents.Size = new System.Drawing.Size(212, 264);
            this.lstTodayEvents.TabIndex = 12;
            // 
            // lblTodayEventsTitle
            // 
            this.lblTodayEventsTitle.AutoSize = true;
            this.lblTodayEventsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTodayEventsTitle.Font = new System.Drawing.Font("Montserrat SemiBold", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayEventsTitle.Location = new System.Drawing.Point(43, 15);
            this.lblTodayEventsTitle.Name = "lblTodayEventsTitle";
            this.lblTodayEventsTitle.Size = new System.Drawing.Size(140, 24);
            this.lblTodayEventsTitle.TabIndex = 11;
            this.lblTodayEventsTitle.Text = "Today\'s Events";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::BarangayHealthcareSystem.Properties.Resources.Minimal_modern_healthcare_background__soft_202605222224;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1545, 622);
            this.Controls.Add(this.pnlTodayEvents);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultations)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.pnlTodayEvents.ResumeLayout(false);
            this.pnlTodayEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_patients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_consultations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_lowstock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_medicines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvConsultations;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.Panel pnlTodayEvents;
        private System.Windows.Forms.ListBox lstTodayEvents;
        private System.Windows.Forms.Label lblTodayEventsTitle;
    }
}