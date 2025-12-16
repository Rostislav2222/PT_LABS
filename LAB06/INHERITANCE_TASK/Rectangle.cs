/// <summary>
/// Класс, представляющий прямоугольник.
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Ширина прямоугольника (> 0).
    /// </summary>
    public double Width { get; private set; }

    /// <summary>
    /// Высота прямоугольника (> 0).
    /// </summary>
    public double Height { get; private set; }

    /// <summary>
    /// Конструктор прямоугольника.
    /// Проверяет корректность сторон.
    /// </summary>
    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Ширина и высота должны быть положительными.", "width/height");
        Width = width;
        Height = height;
        ShapeName = "Прямоугольник";
        CalculateArea();
        CalculatePerimeter();
    }

    /// <summary>
    /// Вычисляет площадь: ширина * высота.
    /// </summary>
    public override void CalculateArea()
    {
        Area = Width * Height;
    }

    /// <summary>
    /// Вычисляет периметр: 2 * (ширина + высота).
    /// </summary>
    public override void CalculatePerimeter()
    {
        Perimeter = 2 * (Width + Height);
    }
}