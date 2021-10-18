using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    internal class lab71
    {
        internal void run()
        {
            MessageBox.Show("Running ChainResponsibility");
            Chain1 c1 = new Chain1();
            Chain2 c2 = new Chain2();
            Chain3 c3 = new Chain3();

            c1.attachnext(c2);
            c2.attachnext(c3);

            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7};

            foreach (int t in arr)
                c1.Action(t);
        }
    }
}
