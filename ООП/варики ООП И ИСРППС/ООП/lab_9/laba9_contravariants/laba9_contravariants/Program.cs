using System;

namespace laba9_contravariants
{
    // Пример с машинами на ковариантность:
    abstract class Engine
    {

    }

    class V8Engine : Engine
    {

    }

    interface ICar<out T> where T : Engine
    {
        T GetEngine();
    }

    class Lada : ICar<V8Engine>
    {
        public V8Engine GetEngine()
        {
            return new V8Engine();
        }

        public Lada()
        {
            Console.WriteLine("Создана машина");
        }
    } 
    // Конец примера с машинами на ковариантность


    // Пример с животными на контравариантность
    abstract class Animal
    {

    }

    class Cat : Animal
    {

    }

    interface IPushable<in T> where T : Animal
    {
        void Push(T obj);
    }

    class StackOfPushable<T> : IPushable<T> where T : Animal
    {
        public void Push(T obj)
        {
            
        }

        public StackOfPushable()
        {
            Console.WriteLine("Создан стэк с глажабельными животными");
        }
    }
    // Конец примера с животными



    class Program
    {
        static void Main(string[] args)
        {
            Lada lada = new Lada();

            ICar<V8Engine> vEightCar = lada;

            ICar<Engine> someCar = lada;



            IPushable<Cat> cats = new StackOfPushable<Animal>();

            Console.ReadKey();
        }
    }
}
