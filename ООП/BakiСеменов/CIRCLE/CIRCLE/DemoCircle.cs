/*
   Дисциплина:  ИСРППС
   Группа:      8О-205Б
   Студент:     Иванов Иван Иванович
   Задача:      
		        Вычисление площади круга и длины окружности
		        по заданному радиусу
   Дата:        08.09.18
*/
using System;
class DemoCicle
{
    public static void Main()
    {


        double r,         	// Радиус
                s,        	// Площадь круга
                c;        	// Длина окружности
        char rep;      	// Признак повтора вычислений
        // 	Y или y - повторное выполнение,
        // 	любой другой символ - окончание
        do
        {
            Console.Write("Введите радиус: ");
            r = double.Parse(Console.ReadLine());  	//Читаем радиус

            CIRCLE C = new CIRCLE(r);

            s = C.Area_Circle();                   		//Вычисляем площадь
            c = C.Length_Circle();              		//Вычисляем длину

            Console.WriteLine("Площадь=" + s + "  Длина окружности=" + c);

            C.InfoCircle();                             // вывод информации об объекте

            Console.Write("Для повтора вычислений нажмите клавишу Y: ");
            rep = char.Parse(Console.ReadLine()); 	 //Вводим признак завершения
            Console.WriteLine();

        } while (rep == 'Y' || rep == 'y');

    } 	  //Конец определения метода
} 	//Конец объявления класса
