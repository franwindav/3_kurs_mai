using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    class Facade1
    {
        static readonly lab71 l71 = new lab71();

        public static void run_7()
        {
            l71.run();
        }
    }

    abstract class ChainPart
    {
        protected ChainPart next;
        public ChainPart()
        {
            next = null;
        }
        public void attachnext(ChainPart chain)
        {
            next = chain;
        }
        abstract public void Action(int arg);
    }

    class Chain1 : ChainPart
    {
        override public void Action(int arg)
        {
            if (arg == 1) MessageBox.Show("Action on number 1", "catched!");
            else if (next != null) next.Action(arg);
        }
    }

    class Chain2 : ChainPart
    {
        override public void Action(int arg)
        {
            if (arg == 6) MessageBox.Show("Action on number 6", "catched!");
            else if (next != null) next.Action(arg);
        }
    }

    class Chain3 : ChainPart
    {
        override public void Action(int arg)
        {
            if (arg < 15) MessageBox.Show("Action on < 15", "catched!");
            else if (next != null) next.Action(arg);
        }
    }
}
