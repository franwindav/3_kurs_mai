using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Lab3 : Form
    {
        public Lab3() { InitializeComponent(); }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canvas.AddPoint(e.Location);
                canvas.Invalidate();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            canvas.Invalidate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (canvas.ToString())
            {
                case "WEB": canvas.SwitchToMode(new CurveFactory());
                    break;
                case "DRAW": canvas.SwitchToMode(new WebFactory());
                    break;
            }
            canvas.Invalidate();
        }

        private void Lab3_Load(object sender, EventArgs e)
        {

        }
    }
}
