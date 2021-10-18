using System;

namespace ConsoleApp1_Lab_4._2_
{
    class K
    {
        public K() { Console.WriteLine("constr K"); }
        public int k { get; set; }
        public virtual void fk() { Console.WriteLine("fk K"); }

    }
    class B : K
    {
        public B() { Console.WriteLine("constr B"); }
        public int b { get; set; }
        public virtual void fb() { Console.WriteLine("fb B"); }
        public override void fk() { Console.WriteLine("Override fk B"); }
    }
    interface E
    {
        double fe();
    }
    interface F
    {
        double ff();
    }

    interface C : E, F
    {
        int fc();
    }

    interface J
    {
        int fj();
        int fj1();
    }

    class A : B, C, J
    {
        public A() { Console.WriteLine("constr A"); }
        public int a { get; set; }
        public override void fb()
        {
            base.fb();
            Console.WriteLine(" fb Override A");

            Console.WriteLine(" Override fb ");
        }
        public override void fk() { Console.WriteLine("Override fk A"); }

        public double fe() { return 56.25; }
        public double ff() { return 112.5; }

        public int fc() { return 255; }
        public int fj() { return 510; }

        public int fj1() { return 1020; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.b = 11;
            b.fb();
            b.fk();
            Console.WriteLine("b.b={0}", b.b);

            b = new A();
            Console.ReadKey();

            b.fb();
            b.fk();
            Console.ReadKey();
            Console.WriteLine("Step 2 : Interface C:E,F  ");

            C c = null;
            c = new A();
            Console.WriteLine("c.fc()={0}", c.fc());
            Console.WriteLine("c.fe()={0}, c.ff()={1}", c.fe(), c.ff());

            Console.WriteLine("Step 3 : Interface J ");

            J j = null;
            j = new A();

            Console.WriteLine("j.fj()={0}", j.fj());
            Console.WriteLine("j.fj1()={0}", j.fj1());

            Console.ReadKey();


        }
    }
}
