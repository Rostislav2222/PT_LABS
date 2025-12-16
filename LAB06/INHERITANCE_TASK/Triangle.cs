/// <summary>
/// Класс, представляющий треугольник по трём сторонам.
/// </summary>
public class Triangle : Shape
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }

    /// <summary>
    /// Конструктор треугольника.
    /// Проверяет: 1) стороны > 0; 2) выполняется неравенство треугольника.
    /// </summary>
    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Все стороны треугольника должны быть положительными.", "a/b/c");
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Невозможно построить треугольник с такими сторонами (нарушено неравенство треугольника).");
        SideA = a;
        SideB = b;
        SideC = c;
        ShapeName = "Треугольник";
        CalculatePerimeter(); // сначала периметр — нужен для полупериметра
        CalculateArea();
    }

    /// <summary>
    /// Вычисляет площадь по формуле Герона: √(p(p−a)(p−b)(p−c)), где p — полупериметр.
    /// </summary>
    public override void CalculateArea()
    {
        double p = Perimeter / 2;
        Area = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    /// <summary>
    /// Вычисляет периметр как сумму сторон.
    /// </summary>
    public override void CalculatePerimeter()
    {
        Perimeter = SideA + SideB + SideC;
    }
}