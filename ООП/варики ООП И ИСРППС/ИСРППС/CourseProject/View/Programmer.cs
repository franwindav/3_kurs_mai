using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class Singletone_Programmer
    {
        protected static Singletone_Programmer Prog = new Singletone_Programmer();

        private string Name;
        private string Description;

        static public string name
        {
            get { return Prog.Name; }
            set { Prog.Name = value; }
        }
        static public string description
        {
            get { return Prog.Description; }
            set { Prog.Description = value; }
        }
        static public Singletone_Programmer prog
        {
            get
            {
                return Prog;
            }
        }

        protected Singletone_Programmer()
        {
            Name = "David Merkgof";
            Description = "Simple programmer's description";
        }
    }
}
