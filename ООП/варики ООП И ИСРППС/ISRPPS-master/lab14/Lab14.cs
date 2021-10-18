using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab14
{
    public partial class Lab14 : Form
    {
        public Lab14() { InitializeComponent(); }

        private static readonly Color color = Color.Black;
        private static readonly float DEFAULT_WIDTH = 2;

        private void Button4_Click(object sender, EventArgs e)
        {
            canvas.points.Clear();
            canvas.Invalidate();
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            canvas.points.Add(new Point(e.X, e.Y));
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            canvas.Mode = new LineMode(canvas, new Pen(color, GetWidth()));
            canvas.Invalidate();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            canvas.Mode = new CurveMode(canvas, new Pen(color, GetWidth()));
            canvas.Invalidate();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            canvas.Mode = new FillMode(canvas, new SolidBrush(color));
            canvas.Invalidate();
        }
        private float GetWidth()
        {
            return float.TryParse(textBox1.Text, out float width) ? width : DEFAULT_WIDTH;
        }
    }
}