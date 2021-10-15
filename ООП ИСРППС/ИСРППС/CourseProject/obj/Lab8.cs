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
    public partial class Lab8 : Form
    {
        static int maxpt = 2048;
        static int maxln = 32;
        int[] n = new int[maxpt];
        int l;
        Point[,] points = new Point[maxln, maxpt];
        Pen p, pp, ww;


        public Lab8()
        {
            InitializeComponent();
            p = new Pen(ForeColor);
            pp = new Pen(Color.Coral, 2.5f);
            ww = new Pen(Color.Fuchsia, 2.5f);
            l = 0;


            for (int i = 0; i < maxpt; i++)
                n[i] = 0;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Invalidate();
                l++;
            }
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < maxpt; i++)
                    n[i] = 0;
                l = 0;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < n[i] - 1; j++)
                {
                    g.DrawLine(pp, points[i, j], points[i, j + 1]);
                    for (int k = j + 10; k + 2 < n[i]; k++)
                        g.DrawLine(ww, points[i, j], points[i, j + 5]);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = CreateGraphics();
                g.DrawLine(new Pen(ForeColor), e.X, e.Y, e.X + 1, e.Y + 1);
                points[l, n[l]].X = e.X;
                points[l, n[l]].Y = e.Y;
                if (n[l] < maxpt) n[l]++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
