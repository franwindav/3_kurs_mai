namespace CourseWork.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphAdjacencyMatrixDataGridView = new System.Windows.Forms.DataGridView();
            this.verticesCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.initialGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.verticesCountLabel = new System.Windows.Forms.Label();
            this.mainTaskButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphAdjacencyMatrixDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticesCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialGraphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // graphAdjacencyMatrixDataGridView
            // 
            this.graphAdjacencyMatrixDataGridView.AllowUserToAddRows = false;
            this.graphAdjacencyMatrixDataGridView.AllowUserToResizeRows = false;
            this.graphAdjacencyMatrixDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.graphAdjacencyMatrixDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.graphAdjacencyMatrixDataGridView.ColumnHeadersHeight = 20;
            this.graphAdjacencyMatrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.graphAdjacencyMatrixDataGridView.Location = new System.Drawing.Point(12, 12);
            this.graphAdjacencyMatrixDataGridView.MultiSelect = false;
            this.graphAdjacencyMatrixDataGridView.Name = "graphAdjacencyMatrixDataGridView";
            this.graphAdjacencyMatrixDataGridView.RowHeadersWidth = 20;
            this.graphAdjacencyMatrixDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.graphAdjacencyMatrixDataGridView.RowTemplate.Height = 23;
            this.graphAdjacencyMatrixDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.graphAdjacencyMatrixDataGridView.Size = new System.Drawing.Size(240, 240);
            this.graphAdjacencyMatrixDataGridView.TabIndex = 0;
            this.graphAdjacencyMatrixDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.graphAdjacencyMatrixDataGridView_CellValueChanged);
            // 
            // verticesCountNumericUpDown
            // 
            this.verticesCountNumericUpDown.Location = new System.Drawing.Point(96, 258);
            this.verticesCountNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.verticesCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticesCountNumericUpDown.Name = "verticesCountNumericUpDown";
            this.verticesCountNumericUpDown.Size = new System.Drawing.Size(156, 20);
            this.verticesCountNumericUpDown.TabIndex = 1;
            this.verticesCountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.verticesCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticesCountNumericUpDown.ValueChanged += new System.EventHandler(this.verticesCountNumericUpDown_ValueChanged);
            // 
            // initialGraphPictureBox
            // 
            this.initialGraphPictureBox.Location = new System.Drawing.Point(258, 12);
            this.initialGraphPictureBox.Name = "initialGraphPictureBox";
            this.initialGraphPictureBox.Size = new System.Drawing.Size(406, 426);
            this.initialGraphPictureBox.TabIndex = 2;
            this.initialGraphPictureBox.TabStop = false;
            // 
            // verticesCountLabel
            // 
            this.verticesCountLabel.AutoSize = true;
            this.verticesCountLabel.Location = new System.Drawing.Point(12, 260);
            this.verticesCountLabel.Name = "verticesCountLabel";
            this.verticesCountLabel.Size = new System.Drawing.Size(78, 13);
            this.verticesCountLabel.TabIndex = 3;
            this.verticesCountLabel.Text = "Vertices count:";
            // 
            // mainTaskButton
            // 
            this.mainTaskButton.Location = new System.Drawing.Point(12, 284);
            this.mainTaskButton.Name = "mainTaskButton";
            this.mainTaskButton.Size = new System.Drawing.Size(240, 23);
            this.mainTaskButton.TabIndex = 4;
            this.mainTaskButton.Text = "Do!";
            this.mainTaskButton.UseVisualStyleBackColor = true;
            this.mainTaskButton.Click += new System.EventHandler(this.mainTaskButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 450);
            this.Controls.Add(this.mainTaskButton);
            this.Controls.Add(this.verticesCountLabel);
            this.Controls.Add(this.initialGraphPictureBox);
            this.Controls.Add(this.verticesCountNumericUpDown);
            this.Controls.Add(this.graphAdjacencyMatrixDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course work by Chernova O.";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphAdjacencyMatrixDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticesCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialGraphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView graphAdjacencyMatrixDataGridView;
        private System.Windows.Forms.NumericUpDown verticesCountNumericUpDown;
        private System.Windows.Forms.PictureBox initialGraphPictureBox;
        private System.Windows.Forms.Label verticesCountLabel;
        private System.Windows.Forms.Button mainTaskButton;
    }
}

