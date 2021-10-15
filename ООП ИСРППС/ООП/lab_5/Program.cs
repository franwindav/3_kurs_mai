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
            this.b = 1;
        }
        public B(int d) 
        {            
            this.b = d;
            Console.WriteLine("Конструктор B с параметрами");
        }
        public new void MethodOfA()
        {
            Console.WriteLine("Это реализация метода интерфейса А классом B");
        }
        public virtual void Method()
        {
            Console.WriteLine("Это метод класса B");
        }

        protected int b { get; set; }
    }

    interface C : A
    {
        public void MethodOfC();
    }

    class D : B, C
    {
        public D()
        {
            this.d = 1;
            Console.WriteLine("Конструктор D");
        }
        public D (int d) : base(d)
        {
            this.d = d;
            Console.WriteLine("Конструктор D c параметрами");
        }
        public void MethodOfA() 
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

        public int d { get; set; }
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            A a = new D();

            a.MethodOfA();
            
            B b = new B();
            Console.WriteLine();

            D d = new D();
            d = new D(15);
            Console.WriteLine();

            b.MethodOfA();
            Console.WriteLine();
            b.Method(); //метод класса В реализованный интерфейсом А
            Console.WriteLine();

            d.MethodOfA(); //Это реализация метода интерфейса А классом D
            Console.WriteLine(); 

            d.MethodOfC(); //Это реализация метода интерфейса C классом D
            Console.WriteLine();

            d.Method();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}