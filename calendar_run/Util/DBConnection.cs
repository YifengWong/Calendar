using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar_run.Util {
    /// <summary>
    /// A class to connect the local database.
    /// </summary>
    public class DBConnection {
        /// <summary>
        /// The database instance.
        /// Author: ChuyangLiu
        /// </summary>
        private static SQLiteConnection db = null;

        /// <summary>
        /// Initialize the SQLiteConnection db.
        /// Author: ChuyangLiu
        /// </summary>
        public static void Init() {
            if (db != null) {
                return;
            }

            string sql = @"CREATE TABLE IF NOT EXISTS Todo
                            (Id VARCHAR(100) PRIMARY KEY,
                             Title VARCHAR(20),
                             Details VARCHAR(100),
                             Year INT,
                             Month INT,
                             Day INT);";

            db = new SQLiteConnection("Calendar.db");
            using (var statement = db.Prepare(sql)) {
                statement.Step();
            }
        }

        /// <summary>
        /// Get the db instance
        /// Author: ChuyangLiu
        /// </summary>
        public static SQLiteConnection GetDB() {
            return db;
        }
    }
}
