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
    public partial class Lab15 : Form
    {
        public Lab15()
        {
            InitializeComponent();
        }

        int h, m, s;

        private void button1_Click(object sender, EventArgs e)
        {
            h = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);
            s = Convert.ToInt32(textBox3.Text);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
            }
            if (m==-1)
            {
                h = h - 1;
                m = 59;
            }

            if (h==0 && m==0 && s==0)
            {
                timer1.Stop();
                MessageBox.Show("The time is over!");
            }

            label1.Text = Convert.ToString(h);
            label3.Text = Convert.ToString(m);
            label5.Text = Convert.ToString(s);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label1.Text = "0";
            label3.Text = "0";
            label5.Text = "0";
        }
    }
}
