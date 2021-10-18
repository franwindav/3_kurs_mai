using System;

namespace laba5_oop
{
    interface A
    {
        public void MethodOfA();
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("Конструктор B");
        }

        public virtual void MethodOfA()
        {
            Console.WriteLine("Это реализация метода интерфейса А классом B");
        }

        public virtual void Method()
        {
            Console.WriteLine("Это метод класса B");
        }
    }

    interface C : A
    {
        public void MethodOfC();      
    }

    class D : B, C
    {
        public D()
            : base()
        {
            Console.WriteLine("Конструктор D");
        }

        public override void MethodOfA()
        {
            Console.WriteLine("Это реализация метода интерфейса А классом D");
        }


        public void MethodOfC()
        {
            Console.WriteLine("Это реализация метода интерфейса C классом D");
        }

        public override void Method()
        {
            Console.WriteLine("Это метод класса D");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            Console.WriteLine();

            D d = new D();
            Console.WriteLine();

            b.MethodOfA();
            Console.WriteLine();
            b.Method();
            Console.WriteLine();

            d.MethodOfA();
            Console.WriteLine();

            d.MethodOfC();
            Console.WriteLine();

            d.Method();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
