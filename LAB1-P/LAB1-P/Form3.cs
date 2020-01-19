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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string sql = "select * from Student";
            SQLConn db = new SQLConn();
            DataTable dt = new DataTable();
            dt = db.selectData(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ID";
            textBox1.DataBindings.Add("Text", dt, "firstName");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "update Student SET firstName = '" + textBox1.Text + "' where ID = " + Convert.ToInt16(comboBox1.Text.ToString()) + "";
            SQLConn db = new SQLConn();
            bool verify = db.manipulateData(sql);
            if (verify == false)
            {
                MessageBox.Show("Some ERROR occured!");
            }
            else
            {
                MessageBox.Show("Record has sucessfully updated!");
            }
            this.Close();
        }
    }
}
