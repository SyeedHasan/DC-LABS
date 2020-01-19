using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB1_P
{
    public partial class Retrieve : Form
    {
        DataTable dt = new DataTable();
        public Retrieve()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = "select * from Student";
            SQLConn db = new SQLConn();
            dt = db.selectData(sql);
            dataGridView1.DataSource = dt;
        }
    }
}
