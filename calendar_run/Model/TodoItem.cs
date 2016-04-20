using calendar_run.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Model {
    /// <summary>
    /// Present one specific todo item.
    /// </summary>
    public class TodoItem {
        public string Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        /// <summary>
        /// Initialize fields.
        /// Author: ChuyangLiu
        /// </summary>
        public TodoItem() {
            Id = "";
            Year = -1;
            Month = -1;
            Day = -1;
            Title = "";
            Details = "";
        }

        /// <summary>
        /// Save the TodoItem to database.
        /// Author: ChuyangLiu
        /// </summary>
        public void Save() {
            if (Id.Length == 0) {  // New Item
                Id = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO Todo
                              (Id, Title, Details, Year, Month, Day)
                              VALUES (?, ?, ?, ?, ?, ?)";
                using (var statement = DBConnection.GetDB().Prepare(sql)) {
                    statement.Bind(1, Id);
                    statement.Bind(2, Title);
                    statement.Bind(3, Details);
                    statement.Bind(4, Year);
                    statement.Bind(5, Month);
                    statement.Bind(6, Day);
                    statement.Step();
                }
            } else {  // Existed item
                string sql = @"UPDATE Todo
                               SET Title = ?, Details = ?, Year = ?, Month = ?, Day = ?
                               WHERE Id = ?";
                using (var statement = DBConnection.GetDB().Prepare(sql)) {
                    statement.Bind(1, Title);
                    statement.Bind(2, Details);
                    statement.Bind(3, Year);
                    statement.Bind(4, Month);
                    statement.Bind(5, Day);
                    statement.Bind(6, Id);
                    statement.Step();
                }
            }
        }

        /// <summary>
        /// Remove the TodoItem from db.
        /// Author: ChuyangLiu
        /// </summary>
        public void Remove() {
            string sql = @"DELETE FROM Todo WHERE Id = ?";
            using (var statement = DBConnection.GetDB().Prepare(sql)) {
                statement.Bind(1, Id);
                statement.Step();
            }
        }

        /// <summary>
        /// Get items with the specific year,month,day from the db.
        /// Author: ChuyangLiu
        /// </summary>
        public static List<TodoItem> GetItems(int year, int month, int day) {
            List<TodoItem> res = new List<TodoItem>();

            string sql = @"SELECT Id, Title, Details, Year, Month, Day
                           FROM Todo
                           WHERE Year = ? AND Month = ? AND Day = ?";
            using (var statement = DBConnection.GetDB().Prepare(sql)) {
                statement.Bind(1, year);
                statement.Bind(2, month);
                statement.Bind(3, day);
                while (statement.Step() != SQLitePCL.SQLiteResult.DONE) {
                    TodoItem newItem = new TodoItem {
                        Id = statement[0] as string,
                        Title = statement[1] as string,
                        Details = statement[2] as string,
                        Year = Convert.ToInt32(statement[3]),
                        Month = Convert.ToInt32(statement[4]),
                        Day = Convert.ToInt32(statement[5])
                    };
                    res.Add(newItem);
                }
            }

            return res;
        }

        /// <summary>
        /// Get all items from database
        /// Author: ChuyangLiu
        /// </summary>
        public static List<TodoItem> GetAllItems() {
            List<TodoItem> res = new List<TodoItem>();

            string sql = @"SELECT Id, Title, Details, Year, Month, Day
                           FROM Todo";
            using (var statement = DBConnection.GetDB().Prepare(sql)) {
                while (statement.Step() != SQLitePCL.SQLiteResult.DONE) {
                    TodoItem newItem = new TodoItem {
                        Id = statement[0] as string,
                        Title = statement[1] as string,
                        Details = statement[2] as string,
                        Year = Convert.ToInt32(statement[3]),
                        Month = Convert.ToInt32(statement[4]),
                        Day = Convert.ToInt32(statement[5])
                    };
                    res.Add(newItem);
                }
            }

            return res;
        }

        /// <summary>
        /// Override ToString() to show messages about the object.
        /// Author: ChuyangLiu
        /// </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ Id: ");
            sb.Append(Id);
            sb.Append(", Title: ");
            sb.Append(Title);
            sb.Append(", Details: ");
            sb.Append(Details);
            sb.Append(", Year: ");
            sb.Append(Year);
            sb.Append(", Month: ");
            sb.Append(Month);
            sb.Append(", Day: ");
            sb.Append(Day);
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
