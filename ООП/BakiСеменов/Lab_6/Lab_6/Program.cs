using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class B1 {
      public B1() { }
      ~B1() { }
      public A1 a { set; get; }
      public int f() { return 2; }
    }
    class A1 // 1:1 
    {
        public A1() { }
        ~A1() { }
        public B1 b { set; get; }
        public int f() { return 5;}
    }

        // 1: N   A:B 
    class A {
      public A() { N = 5; this.b = new B[N]; }
      public A(int N) {
         this.N = N;
         this.b = new B[N];
      }
        ~A() { }
      public void setB(B b) { if (size < N) { this.b[size] = b; size++; } }
      public B getNext(int index) {
        if (index < size) {
//Console.WriteLine(" deb {0} ", index);
          return b[index];
        }
        return null;
      } 
      
      private int N = 0;

      private B[] b = null; 
      private int size = 0;
    }

    class B {
      public B() { }
      public B(A a) { a.setB(this);}
        ~B() { }
      public int f() { return v; }
      private int v = 11; 
      public A a { set; get;}
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            // association 1:1
            B1 b1 = new B1();
            A1 a1 = new A1();
            b1.a = a1;
            a1.b = b1;

            Console.WriteLine(" b1.a.f() = {0}", b1.a.f());
            Console.WriteLine(" a1.b.f() = {0}", a1.b.f());

            // association 1:N
            A a  = new A();  A aS = new A(8);

            B b_1 = new B();
            a.setB(b_1);
            b_1.a = a;
            Console.WriteLine(" b_1.a.getNext().f() = {0}", b_1.a.getNext(0).f());

            Console.WriteLine(" a.getNext().f() = {0}", a.getNext(0).f());
            B b_2 = new B(a);
            //a.setB(b_2);
            //b_2.a = a;

            Console.ReadKey();

        }
    }
}
