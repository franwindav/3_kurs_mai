using System;
using System.Collections.Generic;
using System.Text;

namespace laba0_oop
{
    class Matrix
    {
        private int width { get; set; }
        private int height { get; set; }
        private int[,] array { get; set; }

        public Matrix()
        {
            Console.Write("Введите количество строк матрицы: ");
            this.height = Int16.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: ");
            this.width = Int16.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Введите матрицу построчно: ");
            this.array = new int[this.height, this.width];
            for (int i = 0; i < this.array.GetLength(0); i++)
            {
                Console.Write(">> ");
                string enterString = Console.ReadLine();
                string[] massiveString = enterString.Split(new Char[] { ' ' });
                for (int j = 0; j < massiveString.Length; j++)
                {
                    this.array[i, j] = int.Parse(massiveString[j]);
                }
            }
        }

        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void PrintSize()
        {
            Console.WriteLine($"Matrix's size is {this.height}x{this.width}");
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    Console.Write($"{this.array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        /*public static Matrix operator +(Matrix a, Matrix b)
        {

      
        }*/
    }
}
