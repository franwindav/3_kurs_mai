using System;

namespace Lab_4
{
    interface A
    {
        void Display();
        int Returning();
        double Div();
    }

    class B : A
    {
        public void Display()
        {
            Console.WriteLine("Class B\nSpecification type of inheritancce");
        }

        public int Returning()
        {
            return 67;
        }

        public double Div()
        {
            return 67.7;
        }
    }

    class C : A
    {
        public virtual void Display()
        {
            Console.WriteLine("Class C");
        }

        public int Returning()
        {
            return 45;
        }

        public double Div()
        {
            return 45.7;
        }

        public virtual void Constr()
        {
            Console.WriteLine("C's method for Integration");
        }
    }

    class D : B
    {
        public void Fin()
        {
            Console.WriteLine("Extension from B: B ---> D");
        }
    }

    class E : C
    {
        public void Constr(int h)
        {
            Console.WriteLine($"Integration C ---> E ---- {h}");
        }
    }

    class J : C
    {
        public override void Display()
        {
            Console.WriteLine("Class J\nSpecialization type of inheritance");
        }
    }

    
    class K : C
    {
        public override void Display()
        {
            Console.WriteLine("Class K\nSpecialization type of inheritance");
        }
    }

    class S
    {
        public virtual int Combi()
        {
            return 10 + 5;
        }
    }

    class X : S, A
    {
        public void Display()
        {
            Console.WriteLine("Combination type");
        }

        public int Returning()
        {
            return 1;
        }

        public double Div()
        {
            return 2.2;
        }

        public override int Combi()
        {
            return 3 + 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            C c = new C();
            D d = new D();
            E e = new E();
            J j = new J();
            K k = new K();
            X comb = new X();

            
            b.Display();
            Console.WriteLine($"Value of redefined method of A in B - {b.Returning()}");

            c.Display();

            Console.WriteLine("Class D");
            d.Fin();

            e.Display();
            e.Constr();

            j.Display();

            k.Display();

            comb.Display();
            Console.Write($"Changed Div() method of A, so in X class it returns {comb.Div()} and it has also changed a Combi() method of S class ");
            comb.Combi();
        }
    }
}

