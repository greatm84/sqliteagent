using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SqliteAgent {
    class KshDb {
        private SQLiteConnection conn = null;

        public KshDb(string databaseFullPath) {
            // Check File
            if (!File.Exists(databaseFullPath)) {
                SQLiteConnection.CreateFile(databaseFullPath);
            }
            conn = new SQLiteConnection("Data Source=" + databaseFullPath + ";Version=1;");
            conn.Open();
        }

        public void checkTable(string tableName, string createQuery) {

        }

        public void addStockChartData(string code, int open, int high, int low, int close, long volume) {

        }
    }
}
