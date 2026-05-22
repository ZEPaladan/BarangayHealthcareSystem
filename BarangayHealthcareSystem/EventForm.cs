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
    public partial class EventForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public DateTime eventDate;
        int eventID = -1;
        public EventForm(DateTime date)
        {
            InitializeComponent();
            eventDate = date;
        }
        public EventForm(DateTime date, int id, string title, string desc)
        {
            InitializeComponent();

            eventDate = date;
            eventID = id;

            txtTitle.Text = title;
            txtDescription.Text = desc;
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = eventDate.ToString("yyyy-MM-dd");

            txtTitle.Text = "";
            txtDescription.Text = "";
            txtTitle.Clear();
            txtDescription.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                if (eventID == -1)
                {
                    // INSERT
                    string query = @"
                        INSERT INTO CalendarEvents (EventDate, Title, Description)
                        VALUES (@date, @title, @desc)";

                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", eventDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // UPDATE
                    string query = @"
                        UPDATE CalendarEvents 
                        SET Title=@title, Description=@desc
                        WHERE EventID=@id";

                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", eventID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Saved!");
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (eventID == -1)
            {
                MessageBox.Show("No event to delete.");
                return;
            }

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM CalendarEvents WHERE EventID=@id";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", eventID);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Deleted!");
            this.Close();
        }
    }
}
