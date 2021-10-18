using System;
using System.Collections.Generic;
using System.Text;
/* Некоторые комментарии:
 * Работу выполнил: 
 * 
 * Класс матриц поддерживает след действия: сложения, вчитание, умножение матриц и умножение матрицы на число.
 * Класс реализован с использование обобщения(aka параметрический полиморфизм, aka generics), т.к.
 * автор считает нецелесообразным использовать наследования для реализация независимости от типов данных
 * Вычисления поддерживается для типов int, double. Вычисления вызываеются обычными операторами +,-,*
 * Также реализованы: исключения, индексатор, 3 конструктор(пустой, копирующий и обычный), и неявные преобразования для
 * большой гибкости работы с классами( также для double, int)
 * 
 * Информацию и помощь по интерфейсу находится в классе Form1.
 * 
 * Спасибо за внимание!
 */
namespace _23
{
    class SizeMatrixException:Exception
    {
        public SizeMatrixException(string s):base(s)
        { 
          
        }
    }
    class Matrix<T> where T:new()
    {

        private T[,] variables;//элементы матрицы

        public T this[int id1,int id2] //индексатор
        {
            set
            {
                if (id1 >= 1 && id1 <= variables.GetLength(0) && id2 >= 1 && id1 <= variables.GetLength(1))
                    variables[id1-1, id2-1] = value;
                else throw new IndexOutOfRangeException("Выход за границы массива.");
            }
            get
            {
                if (id1 >= 1 && id1 <= variables.GetLength(0) && id2 >= 1 && id2 <= variables.GetLength(1))
                    return variables[id1-1, id2-1];
                else throw new IndexOutOfRangeException("Выход за границы массива.");
                //return null;
            }
        }
        

        public int SizeH
        {
            get { if (variables == null) return 0; else return variables.GetLength(0); }
        }//свойство для кол-ва строк

        public int SizeV
        {
            get { if (variables == null) return 0; else return variables.GetLength(1); }
        }//свойство для кол-ва столбцов
        

        public Matrix()
        {
            variables = new T[0,0];
        }//пустой конструктор
        public Matrix(T[,] data)
        {
            variables = new T[data.GetLength(0), data.GetLength(1)];
            int i, j;
            
            for (i = 0; i < data.GetLength(0); i++)
            {
                for (j = 0; j < data.GetLength(1); j++)
                {
                    variables[i, j] = data[i, j];
                }
            }
        }
        public Matrix(Matrix<T> mat)//копирующий конструктор
        {
            variables = new T[mat.SizeH, mat.SizeV];
            int i, j;
            for (i = 0; i < mat.SizeH; i++)
            {
                for (j = 0; j < mat.SizeV; j++)
                {
                    variables[i, j] = mat.variables[i, j];
                }
            }
        }
        //разные перегрузки оператора умножения
        #region muliply

        public static Matrix<double> operator *(Matrix<T> mat1, double num)
        {
            int i, j;
            object a1;
            double[,] a = new double[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = Double.Parse(a1.ToString()) *num;

                }
            }
            return (new Matrix<double>(a));
        }
        public static Matrix<double> operator *(double num,Matrix<T> mat1 )
        {
            int i, j;
            object a1;
            double[,] a = new double[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = Double.Parse(a1.ToString()) * num;

                }
            }
            return (new Matrix<double>(a));
        }
        public static Matrix<double> operator *( Matrix<T> mat1,int num)
        {
            int i, j;
            object a1;
            double[,] a = new double[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = Double.Parse(a1.ToString()) * num;

                }
            }
            return (new Matrix<double>(a));
        }
        public static Matrix<double> operator *(int num,Matrix<T> mat1 )
        {
            int i, j;
            object a1;
            double[,] a = new double[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = Double.Parse(a1.ToString()) * num;

                }
            }
            return (new Matrix<double>(a));
        }
        public static Matrix<double> operator *(Matrix<T> mat1, Matrix<int> mat2)
        {
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (mat1.SizeH == mat2.SizeV)
            {
                int i, j,k;
                object a1;
                
                for (i = 0; i < mat1.SizeH; i++)
                {
                    for (j = 0; j < mat1.SizeV; j++)
                    {
                        for (k = 0; k < mat2.SizeV; k++)
                        {
                            a1 = mat1.variables[i, k];
                            a[i, j] += Double.Parse(a1.ToString()) * mat2.variables[j,k];
                        }
                    }
                }
            }
            else throw new SizeMatrixException("Несовпадение размеров");
            return (new Matrix<double>(a));
        }
        public static Matrix<double> operator *(Matrix<T> mat1, Matrix<double> mat2)
        {
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (mat1.SizeH == mat2.SizeV)
            {
                int i, j, k;
                object a1;

                for (i = 0; i < mat1.SizeH; i++)
                {
                    for (j = 0; j < mat1.SizeV; j++)
                    {
                        for (k = 0; k < mat2.SizeV; k++)
                        {
                            a1 = mat1.variables[i, k];
                            a[i, j] += Double.Parse(a1.ToString()) * mat2.variables[j, k];
                        }
                    }
                }
            }
            else throw new SizeMatrixException("Несовпадение размеров");
            return (new Matrix<double>(a));
        }
        #endregion

        //разные перегрузки оператора сложения
        #region add

        public static Matrix<double> operator+(Matrix<T> mat1,Matrix<int> mat2)
        {
           
            object a1;
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (typeof(T) == typeof(double) || typeof(T) == typeof(int))
            {
                int i, j;
               
                if (mat1.SizeH == mat2.SizeH && mat2.SizeV == mat1.SizeV)
                {
                    for (i = 0; i < mat1.SizeH; i++)
                    {
                        for (j = 0; j < mat1.SizeV; j++)
                        {

                            a1 = mat1.variables[i, j];
                            a[i, j] = Double.Parse(a1.ToString()) +(double)mat2.variables[i, j];


                        }
                    }
                }
                else throw new SizeMatrixException("Несовпадение размеров");
               
            }
            return (new Matrix<double>(a));
        }
        
        public static Matrix<double> operator +( Matrix<T> mat1,Matrix<double> mat2)
        {

            object a1;
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (typeof(T) == typeof(double) || typeof(T) == typeof(int))
            {
                int i, j;

                if (mat1.SizeH == mat2.SizeH && mat2.SizeV == mat1.SizeV)
                {
                    for (i = 0; i < mat1.SizeH; i++)
                    {
                        for (j = 0; j < mat1.SizeV; j++)
                        {

                            a1 = mat1.variables[i, j];
                            a[i, j] = Double.Parse(a1.ToString()) + (double)mat2.variables[i, j];


                        }
                    }
                }
                else throw new SizeMatrixException("Несовпадение размеров");

            }
            return (new Matrix<double>(a));
        }
        #endregion

        //разные перегрузки оператора вычитания
        #region sub

        public static Matrix<double> operator -(Matrix<T> mat1, Matrix<int> mat2)
        {

            object a1;
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (typeof(T) == typeof(double) || typeof(T) == typeof(int))
            {
                int i, j;

                if (mat1.SizeH == mat2.SizeH && mat2.SizeV == mat1.SizeV)
                {
                    for (i = 0; i < mat1.SizeH; i++)
                    {
                        for (j = 0; j < mat1.SizeV; j++)
                        {

                            a1 = mat1.variables[i, j];

                            a[i, j] = Double.Parse(a1.ToString()) - (double)mat2.variables[i, j];


                        }
                    }
                }
                else throw new SizeMatrixException("Несовпадение размеров");


            }
            return (new Matrix<double>(a));
        }

        
        public static Matrix<double> operator -( Matrix<T> mat1,Matrix<double> mat2)
        {

            object a1;
            double[,] a = new double[mat1.SizeH, mat2.SizeV];
            if (typeof(T) == typeof(double) || typeof(T) == typeof(int))
            {
                int i, j;

                if (mat1.SizeH == mat2.SizeH && mat2.SizeV == mat1.SizeV)
                {
                    for (i = 0; i < mat1.SizeH; i++)
                    {
                        for (j = 0; j < mat1.SizeV; j++)
                        {

                            a1 = mat1.variables[i, j];

                            a[i, j] =  Double.Parse(a1.ToString())-(double)mat2.variables[i, j];


                        }
                    }
                }
                else throw new SizeMatrixException("Несовпадение размеров");

            }
            return (new Matrix<double>(a));
        }

        #endregion
        public void transposeMatrix()
        {
            int i, j;
            T[,] data = new T[SizeV, SizeH];
            for (i = 0; i < data.GetLength(0); i++)
            {
                for (j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = variables[j, i]; 
                }
            }
            variables = data;
        }
        public static implicit operator Matrix<double>(Matrix<T> mat1)
        {
            object a1;
            int i, j;
            double[,] a = new double[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = Double.Parse(a1.ToString());


                }
            }
            return (new Matrix<double>(a));
        }//преобразование типов
        public static implicit operator Matrix<int>(Matrix<T> mat1)
        {
            object a1;
            int i, j;
            int[,] a = new int[mat1.SizeH, mat1.SizeV];
            for (i = 0; i < mat1.SizeH; i++)
            {
                for (j = 0; j < mat1.SizeV; j++)
                {

                    a1 = mat1.variables[i, j];
                    a[i, j] = (int)double.Parse(a1.ToString());

                }
            }
            return (new Matrix<int>(a));
        }//преобразование типов

    }
    
}
