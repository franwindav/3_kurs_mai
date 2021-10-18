using System;
using System.Threading;

namespace ConsoleApp1_Lab_4_
{
    class A
    {
        public A()
        {
            Console.WriteLine("constr A()");
            this.a = 1;
        }
        ~A()
        {
            Console.WriteLine(" destr A()");
            Thread.Sleep(80000);
        }
        public virtual int fa() { Console.WriteLine("class A fa()"); return a + 1; }
        public int Aa
        {
            set { Console.Write("set"); }
            get { Console.Write("get"); return a; }
        }
        protected int a = 1;
    }
    class B : A
    {
        public B()
        {
            Console.WriteLine("constr B()");
            this.a = 20;
            this.b = 10;
            this.b1 = -1;
        }
        ~B()
        {
            Console.WriteLine("destr B()");
        }


        public override int fa()
        {
            Console.WriteLine("class B fa()");
            base.fa();
            a = a + 10;
            return a;
        }
        public int fb()
        {
            Console.WriteLine("class B fb()");
            return a + b + 10;
        }
        protected int b { set; get; }
        public int b1 { set; get; }

    }
    class K : B
    {
        public K()
        {
            Console.WriteLine("constr K()");
            this.a = 300;

        }
        public override int fa() { Console.WriteLine("class K fa()"); return a + 100; }
        ~K()
        {
            Console.WriteLine("destr K()");

        }
    }
    abstract class C
    {
        abstract public int fc();
        public void print() { Console.WriteLine("class C print"); }

        public int Cc
        {
            set { Console.Write(""); }
            get { Console.Write("get"); return c; }
        }
        protected int c = 1;
    }
    class E : C
    {
        public E() { this.c = 22; }
        public override int fc()
        {
            Console.WriteLine("class E fc()");
            return c * 5;
        }

    }
    class F : C
    {
        public F() { this.c = 22; }
        public override int fc()
        {
            Console.WriteLine("class F fc()");
            return c * 50;
        }
    }
    interface J
    {
        int fj_1();
        int fj_2();
    }
    class D : J
    {
        public D() { }
        public int fj_1() { return 250; }
        public int fj_2() { return 500; }
    }
    class V : K
    {
        public V() { }
        public override int fa() { Console.WriteLine("not use"); return 0; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.ReadKey();

            Console.WriteLine("a.fa()= {0}", a.fa());

            a = new B();
            Console.ReadKey();

            Console.WriteLine("a.fa()= {0}", a.fa());


            if (a.GetType() == typeof(B))
                Console.WriteLine("(a.GetType() == typeof(B))");


            Console.ReadKey();
            Console.WriteLine("Expansion");
            Console.WriteLine("((B)a).fb () = {0}", ((B)a).fb());
            Console.ReadKey();

            Console.WriteLine("Specification : abstract class");
            C c = null;
            c = new E();
            c.Cc = 455;
            c.print();
            Console.WriteLine("c.fc()={0}", c.fc());
            Console.ReadKey();

            c = new F();
            c.Cc = 455;
            c.print();
            Console.WriteLine("c.fc()={0}", c.fc());
            Console.ReadKey();

            Console.WriteLine("Specification : interface");
            J j = new D();
            Console.WriteLine("j.fj_1() ={0}", j.fj_1());
            Console.WriteLine("j.fj_2() ={0}", j.fj_2());
            Console.ReadKey();

            Console.WriteLine("Specialization");
            a = new K();
            Console.WriteLine("a.fa() = {0}", a.fa());
            Console.ReadKey();

            Console.WriteLine("Construction");
            a = new V();
            Console.WriteLine(" a.fa= {0}", a.fa());

            Console.ReadKey();
        }
    }
}
