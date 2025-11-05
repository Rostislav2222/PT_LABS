using System;

namespace OOP_SAMPLE
{
    public class Point
    {
        // Приватные поля для инкапсуляции
        private double x;
        private double y;

        // Конструктор класса
        public Point(double x, double y)
        {
            this.X = x; // Используем свойство для валидации
            this.Y = y; // Используем свойство для валидации
        }

        // Конструктор по умолчанию (начало координат)
        public Point() : this(0, 0)
        {
        }

        // Свойство для координаты X
        public double X
        {
            get { return x; }
            set
            {
                x = value;
            }
        }

        // Свойство для координаты Y
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
            }
        }

        // Метод для перемещения точки
        public void MoveTo(double newX, double newY)
        {
            this.X = newX;
            this.Y = newY;
            Console.WriteLine($"Точка перемещена в позицию ({newX}, {newY})");
        }

        // Метод для вычисления расстояния до начала координат
        public double DistanceToOrigin()
        {
            // Формула расстояния: sqrt(x^2 + y^2)
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        // Метод для представления точки в читаемом виде
        public void PrintPoint()
        {
            Console.WriteLine($"Точка: ({X}, {Y})");
        }
    }
}