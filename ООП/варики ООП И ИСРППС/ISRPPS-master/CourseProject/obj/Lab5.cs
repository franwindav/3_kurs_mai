using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
            richTextBox1.Text = Control.Getd();
            textBox1.Text = Control.Getn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Control.Getd();
            textBox1.Text = Control.Getn();
            Control.Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control.Save();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Control.Ch_info2(richTextBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control.Ch_info1(textBox1.Text);
        }
    }
}
