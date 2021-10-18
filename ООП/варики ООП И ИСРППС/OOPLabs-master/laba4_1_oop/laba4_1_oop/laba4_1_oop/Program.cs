using System;

namespace laba4_1_oop
{
    abstract class AbstractClass
    {
        protected int data;

        public AbstractClass()
        {
            Console.WriteLine("Constructor of AbstractClass");
        }

        public abstract void Method();
    }

    class A : AbstractClass
    {
        public A(int data)
            : base()
        {
            Console.WriteLine("Constructor of A");
            this.data = data;
        }

        public override void Method()
        {
            Console.WriteLine("Method of A");
            Console.WriteLine("Data of A is {0}", this.data);
        }
    }

    class B : A
    {
        public B(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of B");
            this.data += data;
        }

        public override void Method()
        {
            Console.WriteLine("Method of B");
            Console.WriteLine("Data of B is {0}", this.data);
        }
    }

    class C : A
    {
        public C(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of C");
            this.data += data + 1;
        }

        public override void Method()
        {
            Console.WriteLine("Method of C");
            Console.WriteLine("Data of C is {0}", this.data);
        }
    }

    class J : A
    {
        public J(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of J");
            this.data += data + 2;
        }

        public override void Method()
        {
            Console.WriteLine("Method of J");
            Console.WriteLine("Data of J is {0}", this.data);
        }
    }

    class D : B
    {
        public D(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of D");
            this.data += data + 3;
        }

        public override void Method()
        {
            Console.WriteLine("Method of D");
            Console.WriteLine("Data of D is {0}", this.data);
        }
    }

    class E : B
    {
        public E(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of E");
            this.data += data + 4;
        }

        public override void Method()
        {
            Console.WriteLine("Method of D");
            Console.WriteLine("Data of D is {0}", this.data);
        }
    }

    class F : C
    {
        public F(int data)
            : base(data)
        {
            Console.WriteLine("Constructor of F");
            this.data += data + 5;
        }

        public override void Method()
        {
            Console.WriteLine("Method of F");
            Console.WriteLine("Data of F is {0}", this.data);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(2);
            a.Method();
            Console.WriteLine();

            a = new B(1);
            a.Method();
            Console.WriteLine();

            a = new C(1);
            a.Method();
            Console.WriteLine();

            a = new J(1);
            a.Method();
            Console.WriteLine();

            a = new D(1);
            a.Method();
            Console.WriteLine();

            a = new E(1);
            a.Method();
            Console.WriteLine();

            a = new F(1);
            a.Method();
            Console.WriteLine();
        }
    }
}