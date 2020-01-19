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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Retrieve rt = new Retrieve();
            rt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Insert it = new Insert();
            it.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Delete dl = new Delete();
            dl.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Update up = new Update();
            up.Show();
        }
    }
}