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
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "insert into Student values('" + textBox1.Text + "','" + textBox2.Text + "')";

            SQLConn db = new SQLConn();

            bool verify = db.manipulateData(sql);
            if (verify == false)
            {
                MessageBox.Show("Some ERROR occured!");
            }
            else
            {
                MessageBox.Show("Record has sucessfully added!");
            }
            this.Close();
        }
    }
}

