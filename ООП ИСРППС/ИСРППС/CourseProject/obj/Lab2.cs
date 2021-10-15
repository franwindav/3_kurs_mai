using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Lab2 : Form
    {
        public Lab2() { InitializeComponent(); }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hello world!");
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            ShowMessageBox();
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            ShowFolder();
        }
            
        private void ShowMessageBox()
        {
            string text = "Do you want to exit?";
            string caption = "Message Box";

            var result = MessageBox.Show(text,
                caption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            switch (result)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Exiting", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void ShowFolder()
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string caption = "Windows Folder";

            MessageBox.Show(text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
        }

        private void Lab2_Load(object sender, EventArgs e)
        {

        }
    }
}
