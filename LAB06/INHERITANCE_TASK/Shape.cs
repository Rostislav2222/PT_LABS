using System;

/// <summary>
/// Абстрактный базовый класс для представления геометрической фигуры на плоскости.
/// Обеспечивает единый интерфейс для расчёта площади и периметра,
/// а также сравнение фигур по площади.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Площадь фигуры. Вычисляется в производных классах.
    /// </summary>
    public double Area { get; protected set; }

    /// <summary>
    /// Периметр фигуры. Вычисляется в производных классах.
    /// </summary>
    public double Perimeter { get; protected set; }

    /// <summary>
    /// Название фигуры (для идентификации типа).
    /// </summary>
    public string ShapeName { get; protected set; } = "Фигура";

    /// <summary>
    /// Абстрактный метод для вычисления площади.
    /// Должен быть реализован в каждом производном классе.
    /// </summary>
    public abstract void CalculateArea();

    /// <summary>
    /// Абстрактный метод для вычисления периметра.
    /// Должен быть реализован в каждом производном классе.
    /// </summary>
    public abstract void CalculatePerimeter();

    /// <summary>
    /// Переопределённый метод ToString для удобного отображения информации о фигуре.
    /// </summary>
    public override string ToString()
    {
        return $"{ShapeName}: площадь = {Area:F2}, периметр = {Perimeter:F2}";
    }

    // --- Операторы сравнения по площади ---

    /// <summary>
    /// Сравнивает две фигуры на равенство по площади (с погрешностью 1e-9).
    /// </summary>
    public static bool operator ==(Shape? left, Shape? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return Math.Abs(left.Area - right.Area) < 1e-9;
    }

    /// <summary>
    /// Сравнивает две фигуры на неравенство по площади.
    /// </summary>
    public static bool operator !=(Shape? left, Shape? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Сравнивает две фигуры: левая больше правой по площади.
    /// </summary>
    public static bool operator >(Shape left, Shape right)
    {
        if (left is null || right is null)
            throw new ArgumentNullException("Нельзя сравнивать null-фигуры.");
        return left.Area > right.Area;
    }

    /// <summary>
    /// Сравнивает две фигуры: левая меньше правой по площади.
    /// </summary>
    public static bool operator <(Shape left, Shape right)
    {
        if (left is null || right is null)
            throw new ArgumentNullException("Нельзя сравнивать null-фигуры.");
        return left.Area < right.Area;
    }

    /// <summary>
    /// Обязательное переопределение Equals при перегрузке ==.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is Shape other && this == other;
    }

    /// <summary>
    /// Обязательное переопределение GetHashCode при перегрузке ==.
    /// </summary>
    public override int GetHashCode()
    {
        return Area.GetHashCode();
    }
}