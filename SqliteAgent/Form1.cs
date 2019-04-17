using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SqliteAgent {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        /*
         * 2017/12
         * mc : 매출액
         * bp : 영익
         * bpo :영익 오피셜
         * bbp : 세전계속사업익
         * qp : 당기순익
         * bt : 자산총계
         * minust : 부채총계
         * moneyt : 자본총계
         * money : 자본금
         * af : 영업활동현금흐름
         * if : 투자활동흐름
         * mf : 재무활동흐름
         * 
         */        

        private void Form1_Load(object sender, EventArgs e) {
            List<KshDb.ColumnInfo> stockColumnInfo = new List<KshDb.ColumnInfo> {
                new KshDb.ColumnInfo("date", KshDb.DataType.TEXT, true),
                new KshDb.ColumnInfo("open", KshDb.DataType.INT),
                new KshDb.ColumnInfo("high", KshDb.DataType.INT),
                new KshDb.ColumnInfo("low", KshDb.DataType.INT),
                new KshDb.ColumnInfo("close", KshDb.DataType.INT)
            };


        }
    }
}
