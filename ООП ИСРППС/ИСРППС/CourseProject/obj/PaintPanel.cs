using System.Drawing;
using System.Windows.Forms;

namespace CourseProject
{

    public class SingletonPen
    {
        private static readonly Pen instance = new Pen(Color.Gray, 2F);
        public static Pen Instance
        {
            get { return instance; }
        }

        protected SingletonPen() { }
    }

    public interface ModeFactory { Mode Create(Panel canvas); }

    class WebFactory : ModeFactory
    {
        public Mode Create(Panel canvas) { return new WebDrawer(canvas); }
    }

    class CurveFactory : ModeFactory
    {
        public Mode Create(Panel panel) { return new CurveDrawer(); }
    }

    public interface Mode
    {
        void Draw(PaintEventArgs e);
        void Clear();
        void AddPoint(Point p);
    }

    class WebDrawer : Mode
    {
        private readonly Panel canvas;

        private Point end;
        private Point center;
        private Point current;
        private Point[] positions;

        public WebDrawer(Panel panel)
        {
            this.canvas = panel;
            Resize();
            current = center;
        }

        private void Resize()
        {

            Size size = canvas.Size;
            end = new Point(size.Width, size.Height);
            center = new Point(end.X / 2, end.Y / 2);

            positions = new Point[] {
                new Point(0, end.Y / 2), new Point(end.X / 2, 0),
                new Point(end.X, end.Y / 2), new Point(end.X / 2, end.Y),
            };
        }

        public void Draw(PaintEventArgs e)
        {
            Resize();

            Pen pen = SingletonPen.Instance;

            foreach (Point p in positions)  e.Graphics.DrawLine(pen, p, current);
        }
        public void Clear() { current = center; }
        public void AddPoint(Point p) { current = p; }
        public override string ToString() { return "WEB"; }
    }

    class CurveDrawer : Mode
    {
        private static readonly int AMOUNT = 1000;
        private Point[] points = new Point[AMOUNT];
        private int counter = 0;

        public void Draw(PaintEventArgs e)
        {
            Pen pen = SingletonPen.Instance;

            for (int i = 1; i < counter; i++)
            {
                if (points[i - 1] == Point.Empty) continue;
                e.Graphics.DrawLine(pen, points[i - 1], points[i]);
            }
        }
        public void Clear()
        {
            points = new Point[AMOUNT];
            counter = 0;
        }
        public void AddPoint(Point p)
        {
            points[counter] = p;
            counter = (counter + 1) % AMOUNT;
        }
        public override string ToString() { return "DRAW"; }
    }

    public partial class PaintPanel : Panel, Mode
    {
        private Mode mode = new CurveDrawer();
        public string ModeName { get { return mode.ToString(); } }

        public PaintPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        public void SwitchToMode(ModeFactory factory)
        {
            Clear();
            mode = factory.Create(this);
        }
        protected override void OnPaint(PaintEventArgs e) { Draw(e); }
        public void Draw(PaintEventArgs e) { mode.Draw(e); }
        public void Clear() { mode.Clear(); }
        public void AddPoint(Point p) { mode.AddPoint(p); }
        public override string ToString()
        {
            return mode.ToString();
        }
    }
}
