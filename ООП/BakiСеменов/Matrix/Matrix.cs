using System;
using System.Collections.Generic;
using System.Text;
/* ��������� �����������:
 * ������ ��������: 
 * 
 * ����� ������ ������������ ���� ��������: ��������, ��������, ��������� ������ � ��������� ������� �� �����.
 * ����� ���������� � ������������� ���������(aka ��������������� �����������, aka generics), �.�.
 * ����� ������� ���������������� ������������ ������������ ��� ���������� ������������� �� ����� ������
 * ���������� �������������� ��� ����� int, double. ���������� ����������� �������� ����������� +,-,*
 * ����� �����������: ����������, ����������, 3 �����������(������, ���������� � �������), � ������� �������������� ���
 * ������� �������� ������ � ��������( ����� ��� double, int)
 * 
 * ���������� � ������ �� ���������� ��������� � ������ Form1.
 * 
 * ������� �� ��������!
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

        private T[,] variables;//�������� �������

        public T this[int id1,int id2] //����������
        {
            set
            {
                if (id1 >= 1 && id1 <= variables.GetLength(0) && id2 >= 1 && id1 <= variables.GetLength(1))
                    variables[id1-1, id2-1] = value;
                else throw new IndexOutOfRangeException("����� �� ������� �������.");
            }
            get
            {
                if (id1 >= 1 && id1 <= variables.GetLength(0) && id2 >= 1 && id2 <= variables.GetLength(1))
                    return variables[id1-1, id2-1];
                else throw new IndexOutOfRangeException("����� �� ������� �������.");
                //return null;
            }
        }
        

        public int SizeH
        {
            get { if (variables == null) return 0; else return variables.GetLength(0); }
        }//�������� ��� ���-�� �����

        public int SizeV
        {
            get { if (variables == null) return 0; else return variables.GetLength(1); }
        }//�������� ��� ���-�� ��������
        

        public Matrix()
        {
            variables = new T[0,0];
        }//������ �����������
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
        public Matrix(Matrix<T> mat)//���������� �����������
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
        //������ ���������� ��������� ���������
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
            else throw new SizeMatrixException("������������ ��������");
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
            else throw new SizeMatrixException("������������ ��������");
            return (new Matrix<double>(a));
        }
        #endregion

        //������ ���������� ��������� ��������
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
                else throw new SizeMatrixException("������������ ��������");
               
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
                else throw new SizeMatrixException("������������ ��������");

            }
            return (new Matrix<double>(a));
        }
        #endregion

        //������ ���������� ��������� ���������
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
                else throw new SizeMatrixException("������������ ��������");


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
                else throw new SizeMatrixException("������������ ��������");

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
        }//�������������� �����
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
        }//�������������� �����

    }
    
}
