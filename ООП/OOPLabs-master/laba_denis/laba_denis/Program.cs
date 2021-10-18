using System;

namespace laba_denis
{
    interface A
    {
        public void MethodOfAInterface();
        public static int AData;
    }

    interface B : A
    {
        public void MethodOfBInterface();
        public static int BData;
    }

    public class C : A
    {
        public static int AData = 10;

        public C()
        {
            Console.WriteLine("Конструктор С");
        }

        public virtual void MethodOfAInterface()
        {
            Console.WriteLine("Реализация метода интерфейса А классом C");
        }

        public virtual void Method()
        {
            Console.WriteLine("Метод класса C");
        }
    }

    public class D : C, B
    {
        public static int BData = 20;
        public D()
            : base()
        {
            Console.WriteLine("Конструктор D");
        }

        public void MethodOfBInterface()
        {
            Console.WriteLine("Реализация метода интерфейса B классом D");
        }

        public override void Method()
        {
            Console.WriteLine("Метод класса D");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
            Console.WriteLine();

            D d = new D();
            Console.WriteLine();

            c.MethodOfAInterface();
            c.Method();
            Console.WriteLine(C.AData);
            Console.WriteLine();

            d.MethodOfAInterface();
            d.MethodOfAInterface();
            d.Method();
            Console.WriteLine(D.AData);
            Console.WriteLine(D.BData);

            Console.ReadKey();
        }
    }
}
