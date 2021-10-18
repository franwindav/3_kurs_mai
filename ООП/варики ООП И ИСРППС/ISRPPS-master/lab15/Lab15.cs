using System;
using System.Windows.Forms;

namespace Lab15
{
    public partial class Lab15 : Form
    {
        public Lab15() { InitializeComponent(); }

        private static bool stop = false;

        private void Button1_Click(object sender, EventArgs e) { SetTimer(); }

        private void Button2_Click(object sender, EventArgs e) { stop = true; }

        private void SetTimer()
        {
            stop = false;
            button1.Enabled = false;
            timer.Interval = 100; //ms
            timer.Tick += OnTimedEvent;
            timer.Enabled = true;

            while (stop == false)
            {
                Application.DoEvents();
                if (stop) break;
                timer.Enabled = true;
                
            }

            button1.Enabled = true;
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Stop();
        }
    }
}
