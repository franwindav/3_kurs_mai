using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab6
{
    public partial class Lab6 : Form
    {
        public Lab6()
        {
            InitializeComponent();
            SetDefaults();
        }

        private static readonly int MIN_FONT_SIZE = 8;
        private static bool defaultBox;

        private void FontSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            int value = fontSizeTrackBar.Value + MIN_FONT_SIZE;
            fontSizeLabel.Text = value + "pt";
            ChangeFont(value);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void DefaultButton_Click(object sender, EventArgs e) { SetDefaults(); }

        private void SetLabelButton_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            if (text.Length > 15)
                text = text.Substring(0, 15) + "...";

            label1.Text = text;
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                defaultBox = true;
            else defaultBox = false;
        }
        private void MboxButton_Click(object sender, EventArgs e)
        {
            if (defaultBox)
                MessageBox.Show("default MessageBox");
            else MessageBox.Show(
                "MessageBox",
                "info",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
        }
        private void ChangeFont(int value)
        {
            textBox.Font = new Font(textBox.Font.FontFamily, value);
        }
        private void SetDefaults()
        {
            defaultBox = false;
            checkBox.Checked = false;

            ChangeFont(MIN_FONT_SIZE);
            fontSizeTrackBar.Value = 0;
            fontSizeLabel.Text = MIN_FONT_SIZE + "pt";
        }
    }
}