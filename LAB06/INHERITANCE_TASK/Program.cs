using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Создаём массив из 10 фигур разных типов
            Shape[] shapes = new Shape[]
            {
                new Circle(5),
                new Rectangle(3, 4),
                new Triangle(3, 4, 5),
                new Circle(2),
                new Rectangle(10, 1),
                new Triangle(6, 8, 10),
                new Circle(1.5),
                new Rectangle(7, 2),
                new Triangle(5, 5, 5),
                new Circle(10)
            };

            Console.WriteLine("Созданы следующие фигуры:");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }

            // --- 1. Найти фигуру с максимальным отношением площади к периметру ---
            Shape? bestRatioShape = null;


            // Поиск максимального - поправить алгоритм (максимум на старте - первый элемент массива)
            double maxRatio = shapes[0].Area / shapes[0].Perimeter;

            foreach (var shape in shapes)
            {
                // Защита от деления на ноль (в теории Perimeter > 0, но на всякий случай)
                if (shape.Perimeter > 1e-9)
                {
                    double ratio = shape.Area / shape.Perimeter;
                    if (ratio > maxRatio)
                    {
                        maxRatio = ratio;
                        bestRatioShape = shape;
                    }
                }
            }

            // --- 2. Найти фигуру с минимальной площадью ---
            // Написать алгоритм, а не использовать LINQ запрос
            // Написать алгоритм, а не использовать LINQ запрос
            Shape minAreaShape = shapes[0]; // первый элемент — начальное значение (как требует преподаватель)
            for (int i = 1; i < shapes.Length; i++)
            {
                if (shapes[i].Area < minAreaShape.Area)
                {
                    minAreaShape = shapes[i];
                }
            }

            // --- Вывод результатов ---
            Console.WriteLine($"\nФигура с максимальным отношением площади к периметру:\n{bestRatioShape} (отношение = {maxRatio:F4})");
            Console.WriteLine($"\nФигура с минимальной площадью:\n{minAreaShape}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}