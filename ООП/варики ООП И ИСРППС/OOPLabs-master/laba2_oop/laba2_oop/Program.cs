using System;

namespace laba1_oop
{
    class A
    {
        private B b = new B();
        private C c = new C();
        private J j = new J();

        public A() { }

        public B b_accesser
        {
            set
            {
                Console.WriteLine("set b");
                b = value;
            }
            get
            {
                Console.Write("get b->");
                return b;
            }
        }

        public C c_accesser
        {
            set
            {
                Console.WriteLine("set c");
                c = value;
            }
            get
            {
                Console.Write("get c->");
                return c;
            }
        }

        public J j_accesser
        {
            set
            {
                Console.WriteLine("set j");
                j = value;
            }
            get
            {
                Console.Write("get j->");
                return j;
            }
        }

        public void method_of_A()
        {
            Console.WriteLine("Method of A");
        }

    }

    class B
    {
        private D d = new D();
        private E e = new E();

        public B() { }

        public E e_accesser
        {
            set
            {
                Console.WriteLine("set e");
                e = value;
            }
            get
            {
                Console.Write("get e->");
                return e;
            }
        }

        public D d_accesser
        {
            set
            {
                Console.WriteLine("set d");
                d = value;
            }
            get
            {
                Console.Write("get d->");
                return d;
            }
        }

        public void method_of_B()
        {
            Console.Write("Method of B");
        }
    }

    class C
    {
        private E e = new E();
        private F f = new F();

        public C() { }

        public E e_accesser
        {
            set
            {
                Console.WriteLine("set e");
                e = value;
            }
            get
            {
                Console.Write("get e->");
                return e;
            }
        }

        public F f_accesser
        {
            set
            {
                Console.WriteLine("set f");
                f = value;
            }
            get
            {
                Console.Write("get f->");
                return f;
            }
        }

        public void method_of_C()
        {
            Console.WriteLine("Method of C");
        }
    }

    class D
    {
        public D() { }

        public void method_of_D()
        {
            Console.WriteLine("Method of D");
        }
    }

    class E
    {
        public E() { }

        public void method_of_E()
        {
            Console.WriteLine("Method of E");
        }
    }

    class F
    {
        public F() { }

        public void method_of_F()
        {
            Console.WriteLine("Method of F");
        }
    }

    class J
    {
        public J() { }

        public void method_of_J()
        {
            Console.WriteLine("Method of J");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.method_of_A();
            a.b_accesser.method_of_B();
            a.c_accesser.method_of_C();
            a.j_accesser.method_of_J();

            a.b_accesser.d_accesser.method_of_D();
            a.b_accesser.e_accesser.method_of_E();

            a.c_accesser.e_accesser.method_of_E();
            a.c_accesser.f_accesser.method_of_F();

            Console.ReadKey();
        }
    }
}
