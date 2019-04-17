using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SqliteAgent {
    class KshDb {
        public enum DataType {
            INT = 0,
            TEXT,            
            FLOAT,
        };

        public class ColumnInfo {
            public bool primaryKey = false;
            public DataType dataType;
            public string columnName;
            public ColumnInfo(string columnName, DataType dataType, bool primaryKey = false) {
                this.columnName = columnName;
                this.dataType = dataType;
                this.primaryKey = primaryKey;
            }
        }

        public class TableInfo {
            public string tableName;
            public List<ColumnInfo> columnList = new List<ColumnInfo>();

            public TableInfo(string tableName) {
                this.tableName = tableName;
            }
        }

        private SQLiteConnection conn = null;

        public KshDb(string databaseFullPath) {
            // Check File
            if (!File.Exists(databaseFullPath)) {
                SQLiteConnection.CreateFile(databaseFullPath);
            }
            conn = new SQLiteConnection("Data Source=" + databaseFullPath + ";Version=1;");
            conn.Open();
        }

        public void createTable(TableInfo tableInfo) {
            if (tableInfo.tableName == null || tableInfo.tableName.Length == 0 || tableInfo.columnList.Count == 0) {
                throw new ArgumentException("not enough tableInfo");
            }
            string sql = "create table if not exists " + tableInfo.tableName + " (";
            foreach (ColumnInfo info in tableInfo.columnList) {
                if (info.primaryKey) {
                    sql += info.columnName + " " + info.dataType.ToString() + "primary key ,";
                } else {
                    sql += info.columnName + " " + info.dataType.ToString() + ",";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            new SQLiteCommand(sql, conn).ExecuteNonQuery();
        }

        public void createStockTable(string code) {
            string sql = "create table if not exists " + code + " (date char(8) primary key, open int, high int, low int, close int, vol int)";
            new SQLiteCommand(sql, conn).ExecuteNonQuery();
        }

        public void addStockChartData(string code, int open, int high, int low, int close, long volume) {

        }
    }
}
