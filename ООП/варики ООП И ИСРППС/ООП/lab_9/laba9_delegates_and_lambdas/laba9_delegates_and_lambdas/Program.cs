using System;


namespace laba9_delegate
{
    class Program
    {
        delegate int IntegerOperation(int a, int b);
        delegate void MultyTypeOperation<T2, T3>(T2 a, T3 b);
        delegate void GetMessage();

        public static void Concatenate<T1, T2>(T1 a, T2 b)
        {
            Console.WriteLine($"Конкатенация {a} и {b}");
            Console.WriteLine($"{a}{b}");
        }

        public static int Sum(int a, int b)
        {
            Console.WriteLine($"Ищем сумму {a} + {b}");
            return a + b;
        }

        public static int Diff(int a, int b)
        {
            Console.WriteLine($"Ищем разность {a} - {b}");
            return a - b;
        }

        private static void Show_Message(GetMessage _del)
        {
            _del?.Invoke();
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }


        static void Main(string[] args)
        {
            IntegerOperation op0 = Sum;
            op0(1, 2);
            Console.WriteLine();

            op0 += Diff;
            op0(2, 3);
            Console.WriteLine();

            MultyTypeOperation<double, double> op1 = Concatenate;
            MultyTypeOperation<int, int> op2 = Concatenate;
            op1.Invoke(1.1, 2.2);
            op2.Invoke(1, 2);
            Console.WriteLine();

            Action<int, int> op3 = Concatenate;
            op3(3, 4);
            Console.WriteLine();

            Predicate<int> IsPositive = (x) => x > 0;
            Console.WriteLine(IsPositive(6));
            Console.WriteLine();

            Func<int, int, double> op4 = (x, y) => { return (double)x + (double)y; };
            op4(2, 3);

            if (DateTime.Now.Hour < 12)
            {
                Show_Message(GoodMorning);
            }
            else
            {
                Show_Message(GoodEvening);
            }



            Console.ReadKey();
        }
    }
}

