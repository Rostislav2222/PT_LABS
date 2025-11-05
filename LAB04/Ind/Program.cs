using System;

namespace OOP_SAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ КЛАССА POINT ===");

            // Создаем несколько объектов точки
            Point point1 = new Point(3, 4);
            Point point2 = new Point(-2, 7);
            Point point3 = new Point(0, 0);

            // Тестируем метод PrintPoint()
            Console.WriteLine("\n1. Созданные точки:");
            point1.PrintPoint();
            point2.PrintPoint();
            point3.PrintPoint();

            // Тестируем метод DistanceToOrigin()
            Console.WriteLine("\n2. Расстояние до начала координат:");
            Console.WriteLine($"Точка 1: {point1.DistanceToOrigin():F2}");
            Console.WriteLine($"Точка 2: {point2.DistanceToOrigin():F2}");
            Console.WriteLine($"Точка 3: {point3.DistanceToOrigin():F2}");

            // Тестируем метод MoveTo()
            Console.WriteLine("\n3. Перемещение точек:");
            point1.MoveTo(10, 20);
            point1.PrintPoint();
            Console.WriteLine($"Новое расстояние: {point1.DistanceToOrigin():F2}");

            // Тестируем свойства чтения/записи
            Console.WriteLine("\n4. Тестирование свойств:");
            point2.X = 15;
            point2.Y = -5;
            point2.PrintPoint();
            Console.WriteLine($"Координата X: {point2.X}");
            Console.WriteLine($"Координата Y: {point2.Y}");

            // Дополнительные тесты
            Console.WriteLine("\n5. Дополнительные тесты:");
            Point point4 = new Point(1, 1);
            point4.PrintPoint();
            Console.WriteLine($"Расстояние: {point4.DistanceToOrigin():F2}");

            point4.MoveTo(5, 12);
            point4.PrintPoint();
            Console.WriteLine($"Расстояние: {point4.DistanceToOrigin():F2}");

            // Тест с отрицательными координатами
            Console.WriteLine("\n6. Тест с отрицательными координатами:");
            Point point5 = new Point(-3, -4);
            point5.PrintPoint();
            Console.WriteLine($"Расстояние: {point5.DistanceToOrigin():F2}");

            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");

            // Ожидаем нажатия клавиши перед закрытием
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}