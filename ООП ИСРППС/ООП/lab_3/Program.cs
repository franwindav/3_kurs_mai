using System;

namespace Laba3
{
    public class A
    {
        public A()
        {
            Console.WriteLine("Method of A");
            this.varA = 55;
        }
        ~A()
        {
            Console.WriteLine("Destructor of A");
        }

        public virtual int Function()
        {
            Console.WriteLine("Func of class A");
            return this.varA + 445;
        }

        protected int varA { get; set; }

    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine("Method of B");
            this.varA = 78;
        }

        ~B()
        {
            Console.WriteLine("Destructor of B");
        }

        public override int Function()
        {
            Console.WriteLine("Func of class B");
            return this.varA + 78;
        }
    }

    public class C : B
    {
        public C()
        {
            Console.WriteLine("Method of C");
            this.varA = 4;
        }

        ~C()
        {
            Console.WriteLine("Destructor of C");
        }
        public override int Function()
        {
            Console.WriteLine("Func of class C");
            return (this.varA + 32);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.ReadKey();
            Console.WriteLine("Function : {0}", a.Function());
            a = new B();
            Console.ReadKey();
            Console.WriteLine("Function : {0}", a.Function());
            a = new C();
            Console.ReadKey();
            Console.WriteLine("Function : {0}", a.Function());
            if (a.GetType() == typeof(B))
                Console.WriteLine("(a.GetType() == typeof(B))");
            else
            {
                Console.WriteLine("(a.GetType() != typeof(B))");
                if (a.GetType() == typeof(C))
                    Console.WriteLine("(a.GetType() == typeof(C))");
                else
                    Console.WriteLine("(a.GetType() != typeof(C))");
            }
            {
                C c = new C();
            }
            Console.ReadKey();
        }
    }
}
