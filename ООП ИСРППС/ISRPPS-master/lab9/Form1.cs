using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab9
{
    public partial class Lab9 : Form
    {
        public Lab9()
        {
            InitializeComponent();
            opened = new List<ToolStripButton>();
            menuStrip1.ContextMenuStrip = contextMenuStrip1;
            panel1.ContextMenuStrip = contextMenuStrip2;
        }

        private int counter = 0;
        private List<ToolStripButton> opened;
        private ToolStripButton selected;

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButton button = new ToolStripButton();
            button.Text = "file(" + (++counter) + ")";
            
            opened.Add(button);
            toolStrip2.Items.Add(button);

            EventHandler action = (s, ev) =>
            {
                foreach (ToolStripButton btn in opened)
                    btn.BackColor = Color.Transparent;
                
                button.BackColor = SystemColors.ActiveCaption;
                selected = button;
            };

            button.Click += new EventHandler(action);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected == null) return;

            toolStrip2.Items.Remove(selected);
            selected = null;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
