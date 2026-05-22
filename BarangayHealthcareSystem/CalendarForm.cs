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
    public partial class Calendar_Form : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        Button[] dayButtons = new Button[42];
        DateTime currentMonth = DateTime.Now;
        
        DateTime selectedDate;
        Dictionary<string, EventData> eventCache = new Dictionary<string, EventData>();
        ToolTip eventTooltip = new ToolTip();
        public Calendar_Form()
        {
            InitializeComponent();
            BuildCalendarGrid();
        }
        public class EventData
        {
            public int EventID;
            public string Title;
            public string Description;
        }
        private void LoadEventsForMonth(DateTime month)
        {
            eventCache.Clear();

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT EventID, EventDate, Title, Description
                    FROM CalendarEvents
                    WHERE strftime('%Y-%m', EventDate) = @month";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@month", month.ToString("yyyy-MM"));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string date = reader["EventDate"].ToString();

                    eventCache[date] = new EventData
                    {
                        EventID = Convert.ToInt32(reader["EventID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }
            }
        }

        // CREATE 42 BUTTON GRID (6x7)
        private void BuildCalendarGrid()
        {
            pnlCalendar.Controls.Clear();
            ///134, 76
            int width = 136;
            int height = 78;

            int columns = 7; // 7 days per week

            for (int i = 0; i < 42; i++)
            {
                Button btn = new Button();

                int row = i / columns;
                int col = i % columns;

                btn.Width = width;
                btn.Height = height;

                btn.Left = col * width;
                btn.Top = row * height;

                btn.TextAlign = ContentAlignment.TopLeft;   // ✔ TOP LEFT
                btn.Padding = new Padding(5, 5, 0, 0);      // ✔ push number slightly inward

                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;

                btn.Click += Day_Click;

                pnlCalendar.Controls.Add(btn);
                dayButtons[i] = btn;

                btn.MouseHover += Btn_MouseHover;
            }

            
        }
        private string GetEventText(DateTime date)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT Title, Description 
                    FROM CalendarEvents 
                    WHERE EventDate = @date
                    LIMIT 1";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string title = reader.IsDBNull(0) ? "" : reader.GetString(0);
                        string desc = reader.IsDBNull(1) ? "" : reader.GetString(1);

                        if (string.IsNullOrWhiteSpace(title))
                            return null;

                        return $"📌 {title}\n📝 {desc}";
                    }
                }
            }

            return null;
        }
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn?.Tag == null) return;

            DateTime date = (DateTime)btn.Tag;
            string key = date.ToString("yyyy-MM-dd");

            if (eventCache.ContainsKey(key))
            {
                var ev = eventCache[key];
                string text = $"📌 {ev.Title}\n📝 {ev.Description}";

                eventTooltip.Show(text, btn, 40, 40, 2000);
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Calendar_Form_Load(object sender, EventArgs e)
        {
            LoadCalendar(currentMonth);
            LoadEventsForMonth(currentMonth);
        }
        private void LoadCalendar(DateTime month)
        {
            lblMonthYear.Text = month.ToString("MMMM yyyy");

            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int startIndex = (int)firstDay.DayOfWeek;

            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

            // LOAD EVENTS FIRST (IMPORTANT)
            LoadEventsForMonth(month);

            // RESET ALL BUTTONS
            for (int i = 0; i < 42; i++)
            {
                dayButtons[i].Text = "";
                dayButtons[i].BackColor = Color.White;
                dayButtons[i].Tag = null;
                dayButtons[i].Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }

            // FILL DAYS
            for (int day = 1; day <= daysInMonth; day++)
            {
                int index = startIndex + day - 1;

                DateTime date = new DateTime(month.Year, month.Month, day);
                string key = date.ToString("yyyy-MM-dd");

                dayButtons[index].Text = day.ToString();
                dayButtons[index].Tag = date;

                // EVENT MARKING
                if (eventCache.ContainsKey(key))
                {
                    dayButtons[index].BackColor = Color.LightGreen;
                }

                // TODAY HIGHLIGHT
                if (date.Date == DateTime.Now.Date)
                {
                    dayButtons[index].BackColor = Color.LightSkyBlue;
                    dayButtons[index].Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }
        private void Day_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Tag == null) return;

            DateTime date = (DateTime)btn.Tag;
            string key = date.ToString("yyyy-MM-dd");

            if (eventCache.TryGetValue(key, out var ev))
            {
                EventForm frm = new EventForm(date, ev.EventID, ev.Title, ev.Description);
                frm.ShowDialog();
            }
            else
            {
                EventForm frm = new EventForm(date);
                frm.ShowDialog();
            }

            LoadCalendar(currentMonth);
        }
        // SHOW DOT IF EVENT EXISTS
        private void HighlightEvent(DateTime date, Button btn)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM CalendarEvents WHERE EventDate=@date";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    btn.BackColor = Color.LightGreen;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            LoadCalendar(currentMonth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            LoadCalendar(currentMonth);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlCalendar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }
    }
}
