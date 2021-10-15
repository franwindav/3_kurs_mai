using System;
class CIRCLE
{
    private double r;         	// Радиус

    public CIRCLE(double r_prm)			// Конструктор
    {
        r = r_prm;
    }

    public double Area_Circle()		//Вычисление площади
    {
        return Math.PI * r * r;
    }

    public double Length_Circle()		//Вычисление длины окружности
    {
        return 2.0 * Math.PI * r;

    }
    public void InfoCircle()		//Информация об объекте
    {
        Console.WriteLine("Радиус=" + r);
        Console.WriteLine("Площадь круга =" + Area_Circle() + "  Длина окружности=" + Length_Circle());


    }


}