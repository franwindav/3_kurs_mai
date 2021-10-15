using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        int[] request = new int[] { 3, 2, 1 };
        ChainofResponsibility chr = new ChainofResponsibility();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chr.run(request);
        }
    }

    public class ChainofResponsibility
    {
        Handler h1 = new Handler1();
        Handler h2 = new Handler2();
        Handler h3 = new Handler3();

        public ChainofResponsibility()
        {
            h1.next = h2;
            h2.next = h3;
            h3.next = null;

        }

        public void run(int[] request)
        {
            foreach (int i in request)
            {
                h1.HandlerRequest(i);
            }
        }

    }

    abstract public class Handler
    {

        public Handler next { set; get; }
        abstract public void HandlerRequest(int request);
    }

    public class Handler1 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request == 1) { MessageBox.Show("request 1"); }
            else
                if (next != null)
                next.HandlerRequest(request);
        }
    } 
    public class Handler2 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request == 2) { MessageBox.Show("request 2"); }
            else
                if (next != null)
                next.HandlerRequest(request);
        }
    } 

    public class Handler3 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request == 3) { MessageBox.Show("request 3"); }
            else
                if (next != null)
                next.HandlerRequest(request);
        }


    }
}
