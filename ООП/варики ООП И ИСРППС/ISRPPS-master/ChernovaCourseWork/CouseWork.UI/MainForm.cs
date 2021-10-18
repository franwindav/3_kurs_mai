using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CourseWork.UI
{
    public partial class MainForm : Form
    {
        private int[,] _adjacencyMatrix = new int[0, 0]; // матрица смежности

        public MainForm()
        {
            InitializeComponent();
            verticesCountNumericUpDown.Value = 3;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphAdjacencyMatrixDataGridView.RowHeadersDefaultCellStyle.Padding = new Padding(graphAdjacencyMatrixDataGridView.RowHeadersWidth);
            graphAdjacencyMatrixDataGridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(graphAdjacencyMatrixDataGridView_RowPostPaint);
        }

        private void graphAdjacencyMatrixDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var o = graphAdjacencyMatrixDataGridView.Rows[e.RowIndex].HeaderCell.Value;
            e.Graphics.DrawString(o != null ? o.ToString() : "", graphAdjacencyMatrixDataGridView.Font, Brushes.Black, new PointF((float)e.RowBounds.Left + 2, (float)e.RowBounds.Top + 4));
        }

        private void graphAdjacencyMatrixDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            var dataGridView = sender as DataGridView;
            if (e.RowIndex == e.ColumnIndex)
            {
                if (dataGridView[e.ColumnIndex, e.RowIndex].Value?.ToString() != "0")
                {
                    dataGridView.CellValueChanged -= graphAdjacencyMatrixDataGridView_CellValueChanged;
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = "0";
                    dataGridView.CellValueChanged += graphAdjacencyMatrixDataGridView_CellValueChanged;
                    return;
                }
            }
            else
            {
                var currentValue = dataGridView[e.ColumnIndex, e.RowIndex].Value?.ToString();
                var pairedValue = dataGridView[e.RowIndex, e.ColumnIndex].Value?.ToString();
                if (currentValue != pairedValue)
                {
                    if (currentValue != null && currentValue != "0")
                    {
                        currentValue = "1";
                    }
                    dataGridView.CellValueChanged -= graphAdjacencyMatrixDataGridView_CellValueChanged;
                    dataGridView[e.RowIndex, e.ColumnIndex].Value = currentValue;
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = currentValue;
                    dataGridView.CellValueChanged += graphAdjacencyMatrixDataGridView_CellValueChanged;
                }
            }
        }

        private void verticesCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var newSize = (int)(sender as NumericUpDown).Value;
            var adjacencyMatrix = _adjacencyMatrix;
            _adjacencyMatrix = new int[newSize, newSize];
            for (var i = 0; i < Math.Min(adjacencyMatrix.GetLength(0), _adjacencyMatrix.GetLength(0)); i++)
            {
                for (var j = 0; j < Math.Min(adjacencyMatrix.GetLength(1), _adjacencyMatrix.GetLength(1)); j++)
                {
                    _adjacencyMatrix[i, j] = adjacencyMatrix[i, j];
                }
            }
            graphAdjacencyMatrixDataGridView.RowCount = newSize;
            graphAdjacencyMatrixDataGridView.ColumnCount = newSize;
            for (var i = 0; i < graphAdjacencyMatrixDataGridView.RowCount; i++)
            {

                graphAdjacencyMatrixDataGridView.Columns[i].HeaderCell.Value = (i + 1).ToString();
                graphAdjacencyMatrixDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (var j = 0; j < graphAdjacencyMatrixDataGridView.ColumnCount; j++)
                {
                    if (graphAdjacencyMatrixDataGridView[i, j].Value is null)
                    {
                        graphAdjacencyMatrixDataGridView[i, j].Value = "0";
                    }
                }
            }
        }

        private void mainTaskButton_Click(object sender, EventArgs e)
        {
            if (!ParseAdjacencyMatrix(_adjacencyMatrix))
            {
                var messageBoxText = "Check out adjacency matrix element correctness!";
                var messageBoxHeader = "Error";
                MessageBox.Show(this, messageBoxText, messageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var graphics = initialGraphPictureBox.CreateGraphics())
            {
                graphics.Clear(Color.White);
                DrawEdges(graphics);
                DrawVertices(graphics);
            }
            var articulationVerticesIndices = new Graph.Graph(_adjacencyMatrix).GetArticulationVerticesIndices();
        }

        private bool ParseAdjacencyMatrix(int[,] adjacencyMatrix)
        {
            for (var i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    var value = graphAdjacencyMatrixDataGridView[i, j].Value?.ToString();
                    if (value == null)
                    {
                        if (i != j)
                        {
                            return false;
                        }
                    }
                    else if (!int.TryParse(graphAdjacencyMatrixDataGridView[i, j].Value.ToString(), out adjacencyMatrix[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void DrawVertices(Graphics graphics)
        {
            var vertexRadius = 10;
            var vertexOuterRectangle = new Rectangle(default, new Size(vertexRadius * 2 + 1, vertexRadius * 2 + 1));
            var vertexInnerRectangle = new Rectangle(default, new Size(vertexRadius * 2 - 1, vertexRadius * 2 - 1));

            for (var i = 0; i < _adjacencyMatrix.GetLength(0); i++)
            {
                var vertexPoint = GetVertexCenterPoint(i);
                vertexOuterRectangle.Location = new Point(vertexPoint.X - vertexRadius, vertexPoint.Y - vertexRadius);
                vertexInnerRectangle.Location = new Point(vertexPoint.X - vertexRadius + 1, vertexPoint.Y - vertexRadius + 1);
                graphics.DrawEllipse(Pens.Black, vertexOuterRectangle);
                graphics.FillEllipse(Brushes.Red, vertexInnerRectangle);
                graphics.DrawString((i + 1).ToString(), SystemFonts.DefaultFont, Brushes.Black, new Point(vertexPoint.X + vertexRadius + 2, vertexPoint.Y - vertexRadius / 2 - 2));
            }
        }

        private void DrawEdges(Graphics graphics)
        {
            for (var i = 0; i < _adjacencyMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (i == j || _adjacencyMatrix[i, j] == 0)
                    {
                        continue;
                    }
                    var firstVertexCenterPoint = GetVertexCenterPoint(i);
                    var secondVertexCenterPoint = GetVertexCenterPoint(j);
                    graphics.DrawLine(Pens.Black, firstVertexCenterPoint, secondVertexCenterPoint);
                }
            }
        }

        private Point GetVertexCenterPoint(int vertexIndex)
        {
            var radius = (int)(0.85 * initialGraphPictureBox.Size.Width / 2);
            var centerPoint = new Point(initialGraphPictureBox.Size.Width / 2, initialGraphPictureBox.Size.Height / 2);
            var vertexPoint = new Point[] { new Point(centerPoint.X + radius, centerPoint.Y) };
            var angle = 360 / _adjacencyMatrix.GetLength(0) * vertexIndex;
            using (var rotateMatrix = new Matrix())
            {
                rotateMatrix.RotateAt(angle, centerPoint);
                rotateMatrix.TransformPoints(vertexPoint);
            }
            return vertexPoint[0];
        }
    }
}