using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab14
{
    public partial class Canvas : Panel, IMode
    {
        public IMode Mode { get; set; } = null;
        public static Color Color { get; set; } = Color.Black;
        public static Pen Pen { get; set; } = Pens.Black;

        public Canvas()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
        }

        public readonly List<Point> points = new List<Point>();

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Mode == null) return;
            Draw(e.Graphics);
        }

        public enum Modes { LINE, FILL };

        public void Draw(Graphics g) { Mode.Draw(g); }
    }

    public interface IMode { void Draw(Graphics g); }

    class LineMode : IMode
    {
        private static readonly int AMOUNT = 2;
        private readonly Pen pen;
        private readonly Canvas canvas;

        public LineMode(Canvas canvas, Pen pen)
        {
            this.canvas = canvas;
            this.pen = pen;
        }

        public void Draw(Graphics g)
        {
            int count = canvas.points.Count;
            if (count < AMOUNT) return;

            Point[] ps = canvas.points.ToArray();
            g.DrawLines(pen, ps);
        }
    }

    class CurveMode : IMode
    {
        private static readonly int AMOUNT = 3;
        private readonly Pen pen;
        private readonly Canvas canvas;

        public CurveMode(Canvas canvas, Pen pen)
        {
            this.canvas = canvas;
            this.pen = pen;
        }

        public int GetAmount() { return AMOUNT; }
        public void Draw(Graphics g)
        {
            int count = canvas.points.Count;
            if (count < AMOUNT) return;

            Point[] ps = canvas.points.ToArray();
            g.DrawCurve(pen, ps);
        }

    }

    class FillMode : IMode
    {
        private static readonly int AMOUNT = 2;
        private readonly Brush brush;
        private readonly Canvas canvas;

        public FillMode(Canvas canvas, Brush brush)
        {
            this.canvas = canvas;
            this.brush = brush;
        }

        public void Draw(Graphics g)
        {
            int count = canvas.points.Count;
            if (count < AMOUNT) return;

            int maxX = 0, maxY = 0;
            int minX = 9999, minY = 9999;

            foreach (Point p in canvas.points)
            {
                if (p.X > maxX) maxX = p.X;
                if (p.Y > maxY) maxY = p.Y;
                if (p.X < minX) minX = p.X;
                if (p.Y < minY) minY = p.Y;
            }

            Size size =
                new Size(Math.Abs(maxX - minX),
                         Math.Abs(maxY - minY));

            g.FillRectangle(brush,
                            new Rectangle(new Point(minX, minY), size));
        }
    }
}

