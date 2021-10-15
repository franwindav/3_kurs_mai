using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public static class Control
    {
        static string info1;
        static string info2;

        static public void Ch_info1(string s)
        {
            info1 = s;
        }

        static public void Ch_info2(string s)
        {
            info2 = s;
        }

        static public void Save()
        {
            Singletone_Programmer.name = info1;
            Singletone_Programmer.description = info2;
        }

        static public string Getn() { return Singletone_Programmer.name; }
        static public string Getd() { return Singletone_Programmer.description; }

        static public void Reset()
        {
            info1 = "";
            info2 = "";
        }
    }
}
