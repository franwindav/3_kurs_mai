using System;

namespace Laba6
{


    class A
    {
        
        public A()
        {
            this.b = new B[N];
            Console.WriteLine("Constructor A");
        }
        
        public A(int N)
        {
            this.N = N;
            this.b = new B[N];//массив скрытых ссылок на объекты класса 
            Console.WriteLine("Constructor A with param");
        }


        public void setB(B b)
        {
            //ассоциация
            if (size < N)
            {
                Console.WriteLine("Proverka");
                this.b[size] = b;
                size++;
            }
        }

        //метод, позволяющий просматривать последовательно объекты класса E, связанные с объектом класса D
        public B getNext(int index)
        {
            if (index < size)
            {
                return b[index];//возвращаем ссылку
            }
            return null;
        }

        private B[] b = null;
        private int size = 0;
        //количество объектов класса B
        private int N = 5;
    }

    class B
    {
        //конструктор 1
        public B(int c) { this.c = c; Console.WriteLine("Constructor1 B"); }


        //конструктор 2
        public B(A a)
        {
            a.setB(this);
            Console.WriteLine("Constructor2 B");
        }
        ~B() { Console.WriteLine("Destructor B"); }
        public int f() { return v; }
        private int v = 11;
        //атрибут доступа
        public A a { set; get; }
        public int c { set; get; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A();
            
            B b1 = new B(2);
            a1.setB(b1);
            B b2 = new B(3);
            a1.setB(b2);
            B b3 = new B(a1);
            a1.setB(b3);

            b1.a = a1;


            Console.WriteLine("b1.a = {0}", b1.a);

            Console.WriteLine("b1.a.getNext(0) = {0}", b1.a.getNext(0).c);
            Console.WriteLine(" a1.getNext().f() = {0}", a1.getNext(0).f());
            Console.WriteLine(" a1.getNext().f() = {0}", a1.getNext(1).f() + 1);


            Console.ReadKey();

        }
    }
}
