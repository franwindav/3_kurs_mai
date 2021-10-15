using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab16
{
    public partial class Lab16 : Form
    {
        public Lab16() { InitializeComponent(); }

        private bool flip = false;
        private bool rotate = false;

        private static readonly string FILTER =
            "Image files (*.jpeg, *.jpg, *.png, *.bmp) | *.jpeg; *.jpg; *.png, *.bmp";

        private void Button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap result = new Bitmap(pictureBox1.Image);
            Transform(result);
            pictureBox1.Image = result;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = FILTER;
                dialog.Title = "Open file";

                if (dialog.ShowDialog() != DialogResult.OK) return;

                Bitmap bitmap = new Bitmap(dialog.FileName);
                pictureBox1.Image = bitmap;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void Transform(Bitmap image)
        {
            if (rotate)
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (flip)
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void CheckBoxFlip_CheckedChanged(object sender, EventArgs e)
        {
            flip = checkBoxFlip.Checked;
        }

        private void CheckBoxRotate_CheckedChanged(object sender, EventArgs e)
        {
            rotate = checkBoxRotate.Checked;
        }
    }
}
