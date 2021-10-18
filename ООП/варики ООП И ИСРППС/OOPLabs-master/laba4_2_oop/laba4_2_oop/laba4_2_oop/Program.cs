using System;
using System.Dynamic;

namespace laba4_2_oop
{
    interface GeometricFigure
    {
        public string Type();
        public double Perimeter();
        public double Area();
        public double Volume();
    }


    class Triangle : GeometricFigure
    {
        double[] x;
        double[] y;

        public Triangle(double[] x, double[] y)
        {
            this.x = new double[3];
            this.y = new double[3];

            for (int i = 0; i < 3; i++)
            {
                this.x[i] = x[i];
                this.y[i] = y[i];
            }
        }

        public string Type()
        {
            Console.WriteLine("This is Triangle");
            return "This is Triangle";
        }

        public double Perimeter()
        {
            double res = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    res += Math.Sqrt((x[j] - x[i]) * (x[j] - x[i]) + (y[j] - y[i]) * (y[j] - y[i]));
                }
            }
            return res;
        }

        public double Area()
        {
            double det = (x[0] - x[2]) * (y[1] - y[2]) - (y[0] - y[2]) * (x[1] - x[2]);
            if (det < 0)
            {
                det *= -0.5;
            }
            else
            {
                det *= 0.5;
            }
            return det;
        }

        public double Volume()
        {
            return 0;
        }



    }


    class Parallelogram : GeometricFigure
    {
        protected double[] x;
        protected double[] y;

        public Parallelogram(double[] x, double[] y)
        {
            this.x = new double[4];
            this.y = new double[4];

            for (int i = 0; i < 4; i++)
            {
                this.x[i] = x[i];
                this.y[i] = y[i];
            }
        }

        public string Type()
        {
            Console.WriteLine("This is Parallelogram");
            return "This is Parallelogram";
        }
      
        public virtual double Perimeter()
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += Math.Sqrt((x[i+1] - x[i]) * (x[i + 1] - x[i]) + (y[i + 1] - y[i]) * (y[i + 1] - y[i]));
            }

            return result;
        }

        private double Min(double[] x, int len)
        {
            double min = x[0];
            for (int i = 0; i < len; i++)
            {
                if (min > x[i])
                {
                    min = x[i];
                }
            }

            return min;
        }

        private double Max(double[] x, int len)
        {
            double max = x[0];
            for (int i = 0; i < len; i++)
            {
                if (max < x[i])
                {
                    max = x[i];
                }
            }

            return max;
        }

        public virtual double Area()
        {
            return (Math.Abs(Min(this.x, 4) - Max(this.x, 4)) * Math.Abs(Min(this.y, 4) - Max(this.y, 4))) / 2;
        }
        public double Volume()
        {
            return 0;
        }

    }

    class Square : Parallelogram
    {
        public Square(double[] x, double[] y)
            : base(x, y)
        {

        }

        public double Edge()
        {
            return Math.Sqrt((this.x[1] - this.x[0]) * (this.x[1] - this.x[0]) + (this.y[1] - this.y[0]) * (this.y[1] - this.y[0]));
        }

        public override double Perimeter()
        {
            return Edge() * 4;
        }

        public override double Area()
        {
            return Edge() * Edge();
        }
    } 


    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle(new double[3] { -1, 1, 0 }, new double[3] { 0, 0, 2 });
            Parallelogram par = new Parallelogram(new double[4] { -4, -1, -5, -2 }, new double[4] { 4, 5, 1, 2 });
            Square sq = new Square(new double[4] { -1, -1, 1, 1 }, new double[4] { -1, 1, 1, -1 });

            Console.WriteLine("Area of Triange is {0}, Perimeter is {1}", tr.Area(), tr.Perimeter());

            Console.WriteLine("Area of Parallelogram is {0}, Perimeter is {1}", par.Area(), par.Perimeter());

            Console.WriteLine("Area of Square is {0}, Perimeter is {1}", sq.Area(), sq.Perimeter());

            Console.ReadKey();
        }
    }
}
