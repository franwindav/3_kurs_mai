using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


/* Интерфейс для демонстрации
 * Функции: случайное заполнения, выполнения действий и отображения матрицы.
 * Для работы необходимо создать несколько матрицы
 * результат всегда сохраняется в новую матрицу.
 * 
 * Спасибо!
 * 
 */
namespace _23
{
    public partial class Form1 : Form
    {
        ArrayList matrix;
        public Form1()
        {
            matrix = new ArrayList();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n1=-1, n2 = -1;
            n1 = comboBox1.SelectedIndex;
            n2 = comboBox2.SelectedIndex;
            if (n1 >= 0 && n2 >= 0)
            {
                Matrix<double> mat2 = null ;
                try
                {
                    mat2 = (Matrix<double>)matrix[n1] + (Matrix<double>)matrix[n2];// Command+.Excecute((Matrix<double>)matrix[n1],(Matrix<double>)matrix[n2]);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                if (mat2 != null)
                {
                    matrix.Add(mat2);
                    comboBox1.Items.Add(comboBox1.Items.Count + 1);
                    comboBox2.Items.Add(comboBox2.Items.Count + 1);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a=0, b=0;
            try
            {
                a = int.Parse(textBox1.Text);
                b = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных");
            }
            int i, j;
            double[,] data=new double[a,b];
            Random ran = new Random();
            if (a > 0 && b > 0)
            {
                for (i = 0; i < a; i++)
                {
               
                    for (j = 0; j < b; j++)
                    {

                        data[i, j] = ran.Next(20);
                    }

                }
                matrix.Add(new Matrix<double>(data));
                comboBox1.Items.Add(comboBox1.Items.Count+1);
                comboBox2.Items.Add(comboBox2.Items.Count+1);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int n = -1;
            n = comboBox1.SelectedIndex;
            if (n >= 0)
            {
                showMatrix((Matrix<double>)matrix[n]);
            }
        }

        private void showMatrix(Matrix<double> mat)
        {
            int i, j;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(" ", " ");
            if (mat.SizeV > 0) dataGridView1.Rows.Add(mat.SizeV);
            for (i = 0; i < mat.SizeH; i++)
            {
                dataGridView1.Columns.Add(" ", " ");
                for (j = 0; j < mat.SizeV; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = mat[i+1, j+1].ToString();
                }

            }
            dataGridView1.Columns.RemoveAt(mat.SizeH);
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n1 = -1, n2 = -1;
            n1 = comboBox1.SelectedIndex;
            n2 = comboBox2.SelectedIndex;
            if (n1 >= 0 && n2 >= 0)
            {
                Matrix<double> mat2 = null;
                try
                {
                    mat2 = (Matrix<double>)matrix[n1] - (Matrix<double>)matrix[n2]; // Command-.Excecute((Matrix<double>)matrix[n1],(Matrix<double>)matrix[n2]);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                if (mat2 != null)
                {
                    matrix.Add(mat2);
                    comboBox1.Items.Add(comboBox1.Items.Count + 1);
                    comboBox2.Items.Add(comboBox2.Items.Count + 1);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1 = -1, n2 = -1;
            n1 = comboBox1.SelectedIndex;
            n2 = comboBox2.SelectedIndex;
            if (n1 >= 0 && n2 >= 0)
            {
                Matrix<double> mat2 = null;
                try
                {
                    mat2 = (Matrix<double>)matrix[n1] * (Matrix<double>)matrix[n2]; // Command*.Excecute((Matrix<double>)matrix[n1],(Matrix<double>)matrix[n2]);
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                if (mat2 != null)
                {
                    matrix.Add(mat2);
                    comboBox1.Items.Add(comboBox1.Items.Count + 1);
                    comboBox2.Items.Add(comboBox2.Items.Count + 1);
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int n1 = -1;
            n1 = comboBox1.SelectedIndex;
            if (n1 >= 0)
            {
                
                try
                {
                    ((Matrix<double>)matrix[n1]).transposeMatrix(); // CommandT.Excecute((Matrix<double>)matrix[n1])
                    showMatrix(((Matrix<double>)matrix[n1]));
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
}