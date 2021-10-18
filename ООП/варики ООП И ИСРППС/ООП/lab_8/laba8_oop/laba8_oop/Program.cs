using System;

namespace laba8_oop
{
    class Account<T>
    {
        public T Id { get; set; }
        public int Sum { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account<int> account1 = new Account<int> { Sum = 5000 };
            Account<string> account2 = new Account<string> { Sum = 4000 };
            account1.Id = 2;        // упаковка не нужна
            account2.Id = "4356";
            int id1 = account1.Id;  // распаковка не нужна
            string id2 = account2.Id;
            Console.WriteLine(id1);
            Console.WriteLine(id2);


            int x = 7;
            int y = 25;
            Swap<int>(ref x, ref y); // или так Swap(ref x, ref y);
            Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

            string s1 = "hello";
            string s2 = "bye";
            Swap<string>(ref s1, ref s2); // или так Swap(ref s1, ref s2);
            Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello

            Console.Read();
        }

        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
