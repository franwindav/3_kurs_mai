using System;

namespace laba1_oop
{
    class A
    {
        private B b = null;
        private C c = null;
        private J j = null;

        public A(B b, C c, J j)
        {
            this.b = b;
            this.c = c;
            this.j = j;
        }

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
        private D d = null;
        private E e = null;

        public B(D d, E e)
        {
            this.d = d;
            this.e = e;
        }

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
        private E e = null;
        private F f = null;

        public C(E e, F f)
        {
            this.e = e;
            this.f = f;
        }

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
            J j = new J();
            F f = new F();
            E e = new E();
            D d = new D();

            C c = new C(e, f);
            B b = new B(d, e);

            A a = new A(b, c, j);

            a.method_of_A();

            a.b_accesser.method_of_B();
            a.c_accesser.method_of_C();
            a.j_accesser.method_of_J();

            a.b_accesser.d_accesser.method_of_D();
            a.b_accesser.e_accesser.method_of_E();

            a.c_accesser.f_accesser.method_of_F();
            a.c_accesser.e_accesser.method_of_E();

            Console.ReadKey();
        }
    }
}
