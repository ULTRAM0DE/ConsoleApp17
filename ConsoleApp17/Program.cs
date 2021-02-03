using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triangle
{
    class Program
    {
        static void Main()


        {
            
            double x1 = InputData("X1 = ");
        double y1 = InputData("Y1 = ");
        
            double x2 = InputData("X2 = ");
        double y2 = InputData("Y2 = ");
        
            double x3 = InputData("X3 = ");
        double y3 = InputData("Y3 = ");

        Triangle triangle = new Triangle (
            x1, y1, x2, y2, x3, y3);
 
            while (true)
            {
                if (triangle.angleA >= 180 || triangle.angleB >= 180 || triangle.angleC >= 180) // Исключение
                {
                    Console.WriteLine("Не удалось построить треугольник!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Стороны треугольника равны: AB = {0}; BC = {1}; AC = {2}", triangle.AB, triangle.BC, triangle.AC);
                    Console.WriteLine("Периметр треугольника равен = {0}", triangle.p);
                    Console.WriteLine("Площадь треугольника равна = {0}", triangle.s);
                    Console.WriteLine("Точка пересечения медиан равна: М ({0:F3} : {1:F3}) ", triangle.x0, triangle.y0);
                    Console.WriteLine("Тип треугольника: {0}", triangle.type);
                    Console.ReadKey();
                    break;
                }
            }
        }
 
        private static Double InputData(String message) // Контроль ввода данных.
{
    Double Control = 0;
    while (true)
    {
        try
        {
            Console.Write(message);
            String str = Console.ReadLine();
            Control = Convert.ToDouble(str);
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Неправильный ввод!!!");
            Console.WriteLine("Для ввода дробных чисел используйте запятую, другие символы недопустимы. Повторите ввод.");
            continue;
        }
    }
    return Control;
}
    }
}

namespace Triangle
{
    public class Triangle
    {
        public double x0 { get; private set; }
        public double y0 { get; private set; }
        public double AB { get; private set; }
        public double AC { get; private set; }
        public double BC { get; private set; }
        public double s { get; private set; }
        public double p { get; set; }
        public double angleA { get; private set; }
        public double angleB { get; private set; }
        public double angleC { get; private set; }
        public string type { get; private set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            AB = GetSideAB(x1, y1, x2, y2);
            BC = GetSideBC(x2, y2, x3, y3);
            AC = GetSideAC(x3, y3, x1, y1);
            p = GetPerimetr(AB, BC, AC);
            s = Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)) / 2;
            x0 = GetX0(x1, x2, x3);
            y0 = GetY0(y1, y2, y3);
            angleA = GetAngleA(AB, BC, AC);
            angleB = GetAngleB(AB, BC, AC);
            angleC = GetAngleC(AB, BC, AC);
            type = GetType(AB, BC, AC);
        }

        // Нахождение длин сторон треугольника.
        static double GetSideAB(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static double GetSideBC(double x1, double y1, double x3, double y3)
        {
            return Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
        }

        static double GetSideAC(double x3, double y3, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
        }

        // Вычисление периметра треугольника.
        private double GetPerimetr(double AB, double BC, double AC)
        {
            return AB + BC + AC;
        }

        // Нахождение точки X пересечение медианы
        private double GetX0(double x1, double x2, double x3)
        {
            return (x1 + x2 + x3) / 3;
        }

        // Нахождение точки Y пересечение медианы
        private double GetY0(double y1, double y2, double y3)
        {
            return (y1 + y2 + y3) / 3;
        }

        // Вычисление углов треугольника.
        private double GetAngleA(double AB, double BC, double AC)
        {
            return Math.Acos((AB * AB + AC * AC - BC * BC) / (2 * AB * AC)) * 180 / Math.PI;
        }

        private double GetAngleB(double AB, double BC, double AC)
        {
            return Math.Acos((AB * AB + BC * BC - AC * AC) / (2 * AB * BC)) * 180 / Math.PI;
        }

        private double GetAngleC(double AB, double BC, double AC)
        {
            return Math.Acos((BC * BC + AC * AC - AB * AB) / (2 * BC * AC)) * 180 / Math.PI;
        }

        // тип треугольника
        private string GetType(double AB, double BC, double AC)
        {
            if (AB < BC + AC && BC < AB + AC && AC < AB + BC)
            {
                if (AB == BC && BC == AC)
                    return "Равносторонний";
                else
                    if (AB == BC || AB == AC || BC == AC)
                    return "Равнобедренный";
            }
            return "Разносторонний";
        }
    }
}