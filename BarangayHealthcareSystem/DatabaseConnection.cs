using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangayHealthcareSystem
{
    public class DatabaseConnection
    {
        private string dbPath;
        private string connectionString;

        public DatabaseConnection()
        {
            dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BHS",
                "bhs.db"
);

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            connectionString = $"Data Source={dbPath};Version=3;";

            CreateDatabaseAndTables();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        private void CreateDatabaseAndTables()
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                }

                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();

                    // ================= USERS TABLE =================
                    string usersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL DEFAULT 'Staff',
                        CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
                    );";

                    // ================= PATIENTS TABLE =================
                    string patientsTable = @"
                    CREATE TABLE IF NOT EXISTS Patients (
                        PatientID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT,
                        MiddleName TEXT,
                        LastName TEXT,
                        Age INTEGER,
                        Gender TEXT,
                        Birthdate TEXT,
                        Address TEXT,
                        ContactNo TEXT
                    );";

                    // ================= CONSULTATIONS TABLE =================
                    string consultationsTable = @"
                    CREATE TABLE IF NOT EXISTS Consultations (
                        ConsultationID INTEGER PRIMARY KEY AUTOINCREMENT,
                        PatientID INTEGER,
                        ConsultationDate TEXT,
                        Symptoms TEXT,
                        Diagnosis TEXT,
                        Prescription TEXT,
                        DoctorName TEXT,
                        FOREIGN KEY(PatientID) REFERENCES Patients(PatientID)
                    );";

                    // ================= MEDICINES TABLE =================
                    string medicinesTable = @"
                    CREATE TABLE IF NOT EXISTS Medicines (
                        MedicineID INTEGER PRIMARY KEY AUTOINCREMENT,
                        MedicineName TEXT,
                        Category TEXT,
                        Quantity INTEGER,
                        Unit TEXT,
                        ExpirationDate TEXT,
                        Supplier TEXT
                    );";

                    // ================= CALENDAR TABLE =================
                    string calendarTable = @"
                    CREATE TABLE IF NOT EXISTS CalendarEvents (
                        EventID INTEGER PRIMARY KEY AUTOINCREMENT,
                        EventDate TEXT NOT NULL,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
                    );";

                    // EXECUTE TABLES
                    new SQLiteCommand(usersTable, conn).ExecuteNonQuery();
                    new SQLiteCommand(patientsTable, conn).ExecuteNonQuery();
                    new SQLiteCommand(consultationsTable, conn).ExecuteNonQuery();
                    new SQLiteCommand(medicinesTable, conn).ExecuteNonQuery();
                    new SQLiteCommand(calendarTable, conn).ExecuteNonQuery();

                    // ================= DEFAULT ADMIN =================
                    string insertAdmin = @"
                    INSERT OR IGNORE INTO Users (Username, Password, Role)
                    VALUES ('admin', 'admin', 'Admin');
                    ";

                    new SQLiteCommand(insertAdmin, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database Initialization Error\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
