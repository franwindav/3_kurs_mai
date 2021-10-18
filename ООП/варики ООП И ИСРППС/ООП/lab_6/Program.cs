using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{


    class A
    {
        public A() { }
        public A (B b)
        {
            this.b = b;
            Console.WriteLine("Constr with param");
        }
        ~A() { }
        public int F() { return 0; }

        public B b { set; get; }
    }

    class B
    {
        public B()
        {
            Console.WriteLine("Constr without param");

        }
        public B(A a)
        {
            this.a = a;
            Console.WriteLine("Constr with param");


        }
        ~B() { }
        public int F() { return 1; }

        public A a { set; get; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B(a); // связь в одну сторону
            a.b = b; //в обе стороны


            Console.WriteLine("a.F = {0}", a.F());
            Console.WriteLine("b.F = {0}", b.F());
            Console.WriteLine("a.b.F = {0}", a.b.F());
            Console.WriteLine("b.a.F = {0}", b.a.F());
        }
    }
}
