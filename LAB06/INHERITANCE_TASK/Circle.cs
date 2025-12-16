/// <summary>
/// Класс, представляющий окружность.
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Радиус окружности. Должен быть > 0.
    /// </summary>
    public double Radius { get; private set; }

    /// <summary>
    /// Конструктор окружности.
    /// Проверяет корректность радиуса.
    /// </summary>
    /// <param name="radius">Радиус окружности</param>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус окружности должен быть положительным.", nameof(radius));
        Radius = radius;
        ShapeName = "Окружность";
        CalculateArea();
        CalculatePerimeter();
    }

    /// <summary>
    /// Вычисляет площадь окружности: π * r².
    /// </summary>
    public override void CalculateArea()
    {
        Area = Math.PI * Radius * Radius;
    }

    /// <summary>
    /// Вычисляет длину окружности (периметр): 2 * π * r.
    /// </summary>
    public override void CalculatePerimeter()
    {
        Perimeter = 2 * Math.PI * Radius;
    }
}