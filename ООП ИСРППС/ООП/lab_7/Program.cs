using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{


    class D//клиент
    {
        public D() { Console.WriteLine("Constructor D"); }
        ~D() { }
        public int f()
        {
            this.d = 5;
            return this.d * 2;
        }
        public int d { set; get; }
    }

    class E//сервер
    {
        public E() { Console.WriteLine("Constructor E"); }
        public int e { set; get; }
        public int fe() { return 888; }
        public static int fs() { return 333; } //можем обратиться не создавая объект        
        ~E() { }
        public void me(D d) { Console.WriteLine("class E client me() = {0}", d.f()); }
    }


    static class Es
    {
        public static int fe() { return 888; } //можем вызвать от класса тилиты а не от объекта класса
        public static int fentry() { return 1111; }
    }




    class Program
    {
        static void Main(string[] args)
        {
            D d = new D(); //сервер
            E e = new E(); //клиент
            e.me(d); 
            
            
            Console.WriteLine("E.fs() = {0}", E.fs());
            Console.WriteLine("E.fe() = {0}", Es.fe());
            Console.WriteLine("E.fentry() = {0}", Es.fentry());
            
            Console.ReadKey();


        }
    }
}
