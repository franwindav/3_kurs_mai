using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CourseProject
{
    enum Months
    {
        January = 1, February, March, April, May, June, July, August, September, October, November, December
    }
    class Date
    {
        public Date()
        {
            this.month = Months.January;
            this.day = 1;
            this.year = 1;
        }
        public Date(int dayDate, int monthDate, int yearDate)
        {
            this.month = (Months)Enum.ToObject(typeof(Months), monthDate);
            this.day = dayDate;
            this.year = yearDate;
        }
        private int day;

        public int D
        {
            get
            {
                return day;
            }

            set
            {
                if (((value < 1 || value > 31)
                && (this.month == Months.January || this.month == Months.March || this.month == Months.May ||
                this.month == Months.July || this.month == Months.August || this.month == Months.October || this.month == Months.December)) ||
                ((value < 1 || value > 30) && (this.month == Months.April || this.month == Months.June || this.month == Months.September || this.month == Months.November)) ||
                ((value < 1 || value > 29) && this.month == Months.February))
                    throw new Exception("Not a valid type of day");
                else
                {
                    day = value;
                }
            }
        }
        private Months month;

        public Months M
        {
            get
            {
                return month;
            }

            set
            {
                if (value < Months.January || value > Months.December)
                    throw new Exception("Not a valid type of month");
                else
                {
                    month = (Months)Enum.ToObject(typeof(Months), value);
                }
            }
        }
        private int year;

        public int Y
        {
            get
            {
                return year;
            }

            set
            {
                if (year < 0 || year > int.MaxValue)
                    throw new Exception("Not a valid type of year");
                else
                {
                    year = value;
                }
            }
        }

        public void consoleOutput()
        {
            Console.WriteLine($"Current date: {this.day}.{(int)this.month}.{this.year}");
        }
    }

    class ConsoleDisp
    {
        [DllImport("Kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("Kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
}
