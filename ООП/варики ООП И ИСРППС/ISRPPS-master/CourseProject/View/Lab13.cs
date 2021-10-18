using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Lab13 : Form
    {
        public Lab13() { InitializeComponent(); }

        private void TextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Copy;
        }

        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string text = (string)e.Data.GetData(typeof(string));
            if (text == null) return;

            textBox1.AppendText(text + Environment.NewLine);
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e) { Cut(sender, e); }
        private void ToolStripLabel2_Click(object sender, EventArgs e) { Copy(sender, e); }
        private void ToolStripLabel3_Click(object sender, EventArgs e) { Paste(sender, e); }

        private void Cut(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == string.Empty) return;

            Clipboard.SetText(textBox1.Text);
            textBox1.Text = string.Empty;
        }
        private void Copy(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == string.Empty) return;

            Clipboard.SetText(textBox1.Text);
        }
        private void Paste(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText()) return;

            textBox1.AppendText(Clipboard.GetText() + Environment.NewLine);
        }

        private void Panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Panel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Image image;
            try
            {
                image = Image.FromFile(files[0]);
            }
            catch (Exception)
            {
                ShowError("Unable to open image");
                return;
            }

            pictureBox1.Image = image;
        }

        private void CutItemContextMenu_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Clipboard.SetImage(pictureBox1.Image);
            pictureBox1.Image = null;
        }

        private void CopyItemContextMenu_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Clipboard.SetImage(pictureBox1.Image);
        }

        private void PasteItemContextMenu_Click(object sender, EventArgs e)
        {
            Image image = Clipboard.GetImage();
            if (image != null) pictureBox1.Image = image;
        }

        private void ShowError(string caption)
        {
            MessageBox.Show(caption, "Error",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
