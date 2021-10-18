using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CourseProject
{
    internal class lab1
    {
        internal void run()
        {
            ConsoleDisp.AllocConsole();
            byte b = new byte();
            int i = new int();
            short sh = new short();
            //string str = new string("0");
            sbyte sb = new sbyte();
            ushort ush = new ushort();
            uint ui = new uint();
            long l = new long();
            ulong ul = new ulong();
            char ch = new char();
            float fl = new float();
            double doub = new double();
            decimal dec = new decimal();

            int bs = Marshal.SizeOf(b), iss = Marshal.SizeOf(i), shs = Marshal.SizeOf(sh),
                /*strs = Marshal.SizeOf<string>(str),*/ sbs = Marshal.SizeOf(sb), ushs = Marshal.SizeOf(ush),
                uis = Marshal.SizeOf(ui), ls = Marshal.SizeOf(l), uls = Marshal.SizeOf(ul), chs = Marshal.SizeOf(ch),
                fls = Marshal.SizeOf(fl), doubs = Marshal.SizeOf(doub), decs = Marshal.SizeOf(dec);

            Console.WriteLine("--------Table of sizes of types in C#--------");
            Console.WriteLine($"BYTE-----------------{bs}-------From ({byte.MinValue}) to ({byte.MaxValue})");
            Console.WriteLine($"INT------------------{iss}-------From ({int.MinValue}) to ({int.MaxValue})");
            Console.WriteLine($"SHORT----------------{shs}-------From ({short.MinValue}) to ({short.MaxValue})");
            Console.WriteLine($"SBYTE----------------{sbs}-------From ({sbyte.MinValue}) to ({sbyte.MaxValue})");
            Console.WriteLine($"USHORT---------------{ushs}-------From ({ushort.MinValue}) to ({ushort.MaxValue})");
            Console.WriteLine($"UINT-----------------{uis}-------From ({uint.MinValue}) to ({uint.MaxValue})");
            Console.WriteLine($"LONG-----------------{ls}-------From ({long.MinValue}) to ({long.MaxValue})");
            Console.WriteLine($"ULONG----------------{uls}-------From ({ulong.MinValue}) to ({ulong.MaxValue})");
            Console.WriteLine($"CHAR-----------------{chs}-------From ({char.MinValue}) to ({char.MaxValue})");
            Console.WriteLine($"FLOAT----------------{fls}-------From ({float.MinValue}) to ({float.MaxValue})");
            Console.WriteLine($"DOUBLE---------------{doubs}-------From ({double.MinValue}) to ({double.MaxValue})");
            Console.WriteLine($"DECIMAL--------------{decs}------From ({decimal.MinValue}) to ({decimal.MaxValue})");

            Console.WriteLine("\n\n");

            float[] arr = new float[] { 3.5F, 7.3F, 5.5F, 3.2F };

            Console.Write("The containment of the float[] array: ");

            foreach (float a in arr)
            {
                Console.Write($"{a} ");
            }

            Console.WriteLine("\n\n");

            Date date1 = new Date();

            try
            {
                date1.M = (Months)7;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.Data}");
            }

            try
            {
                date1.D = 16;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.Data}");
            }

            try
            {
                date1.Y = 2001;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.Data}");
            }

            date1.consoleOutput();

            Console.ReadKey();

            ConsoleDisp.FreeConsole();
        }
    }

    internal class lab2
    {
        internal void run()
        {
            CourseProject.Lab2 fl2 = new CourseProject.Lab2();
            fl2.ShowDialog();
        }
    }

    internal class lab3
    {
        internal void run()
        {
            CourseProject.Lab3 fl3 = new CourseProject.Lab3();
            fl3.ShowDialog();
        }
    }

    internal class lab5
    {
        internal void run()
        {
            CourseProject.Lab5 fl5 = new CourseProject.Lab5();
            fl5.ShowDialog();
        }
    }

    internal class lab6
    {
        internal void run()
        {
            CourseProject.Lab6 fl6 = new CourseProject.Lab6();
            fl6.ShowDialog();
        }
    }

    internal class lab7
    {
        internal void run()
        {
            CourseProject.Lab7 fl7 = new CourseProject.Lab7();
            fl7.ShowDialog();
        }
    }

    internal class lab8
    {
        internal void run()
        {
            CourseProject.Lab8 fl8 = new CourseProject.Lab8();
            fl8.ShowDialog();
        }
    }

    internal class lab9
    {
        internal void run()
        {
            CourseProject.Lab9 fl9 = new CourseProject.Lab9();
            fl9.ShowDialog();
        }
    }

    internal class lab10
    {
        internal void run()
        {
            CourseProject.Lab10 fl10 = new CourseProject.Lab10();
            fl10.ShowDialog();
        }
    }

    internal class lab11
    {
        internal void run()
        {
            CourseProject.Lab11 fl11 = new CourseProject.Lab11();
            fl11.ShowDialog();
        }
    }

    internal class lab12
    {
        internal void run()
        {
            CourseProject.Lab12 fl12 = new CourseProject.Lab12();
            fl12.ShowDialog();
        }
    }

    internal class lab13
    {
        internal void run()
        {
            CourseProject.Lab13 fl13 = new CourseProject.Lab13();
            fl13.ShowDialog();
        }
    }

    internal class lab14
    {
        internal void run()
        {
            CourseProject.Lab14 fl14 = new CourseProject.Lab14();
            fl14.ShowDialog();
        }
    }

    internal class lab15
    {
        internal void run()
        {
            CourseProject.Lab15 fl15 = new CourseProject.Lab15();
            fl15.ShowDialog();
        }
    }

    internal class lab16
    {
        internal void run()
        {
            CourseProject.Lab16 fl16 = new CourseProject.Lab16();
            fl16.ShowDialog();
        }
    }


    public static class Controller
    {
        static lab1 l1 = new lab1();
        static lab2 l2 = new lab2();
        static lab3 l3 = new lab3();
        static lab5 l5 = new lab5();
        static lab6 l6 = new lab6();
        static lab7 l7 = new lab7();
        static lab8 l8 = new lab8();
        static lab9 l9 = new lab9();
        static lab10 l10 = new lab10();
        static lab11 l11 = new lab11();
        static lab12 l12 = new lab12();
        static lab13 l13 = new lab13();
        static lab14 l14 = new lab14();
        static lab15 l15 = new lab15();
        static lab16 l16 = new lab16();

        public static void run_1()
        {
            l1.run();
        }
        public static void run_2()
        {
            l2.run();
        }
        public static void run_3()
        {
            l3.run();
        }
        public static void run_5()
        {
            l5.run();
        }
        public static void run_6()
        {
            l6.run();
        }
        public static void run_7()
        {
            l7.run();
        }
        public static void run_8()
        {
            l8.run();
        }
        public static void run_9()
        {
            l9.run();
        }
        public static void run_10()
        {
            l10.run();
        }
        public static void run_11()
        {
            l11.run();
        }
        public static void run_12()
        {
            l12.run();
        }
        public static void run_13()
        {
            l13.run();
        }
        public static void run_14()
        {
            l14.run();
        }
        public static void run_15()
        {
            l15.run();
        }
        public static void run_16()
        {
            l16.run();
        }
    }
}
