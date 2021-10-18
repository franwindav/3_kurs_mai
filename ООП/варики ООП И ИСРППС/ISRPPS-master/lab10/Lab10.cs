using System;
using System.IO;
using System.Windows.Forms;

namespace lab10
{
    public partial class Lab10 : Form
    {
        public Lab10()
        {
            InitializeComponent();
        }

        private static readonly string TXT_FILTER = "txt files (*.txt)|*.txt";

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }


        private void SaveFile()
        {
            if (richTextBox1.Text == string.Empty) return;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = TXT_FILTER;
                saveFileDialog.Title = "Save file";

                var result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    File.WriteAllText(fileName, richTextBox1.Text);
                }
            }

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = TXT_FILTER;
                openFileDialog.Title = "Open file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    richTextBox1.Text = File.ReadAllText(fileName);
                }
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = string.Empty;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result =
                MessageBox.Show("Save before quiting?",
                    "Exit",
                    MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Yes:
                    SaveFile();
                    Close();
                    break;
                case DialogResult.No:
                    Close();
                    break;
                case DialogResult.Cancel: break;
            }
        }

        private void SetFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Font = fontDialog.Font;
                }
            }
        }

    }
}