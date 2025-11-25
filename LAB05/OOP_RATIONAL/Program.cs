class Program
{
    static void Main()
    {
        // Создаем два уравнения
        LinearEquation eq1 = new LinearEquation(new double[] { 2, -3, 4 }, 5);
        LinearEquation eq2 = new LinearEquation(new double[] { 1, 2, -1 }, 3);

        // Проверка ToString
        Console.WriteLine("Уравнение 1: " + eq1); // 2x1 -3x2 +4x3 = 5
        Console.WriteLine("Уравнение 2: " + eq2); // x1 + 2x2 -x3 = 3

        // Проверка оператора +
        LinearEquation sum = eq1 + eq2;
        Console.WriteLine("Сумма: " + sum); // 3x1 -x2 +3x3 = 8

        // Проверка оператора -
        LinearEquation diff = eq1 - eq2;
        Console.WriteLine("Разность: " + diff); // x1 -5x2 +5x3 = 2

        // Проверка Equals
        Console.WriteLine("eq1 == eq2: " + eq1.Equals(eq2)); // True (оба имеют 3 переменные)

        LinearEquation eq3 = new LinearEquation(new double[] { 1, 2 }, 4);
        Console.WriteLine("eq1 == eq3: " + eq1.Equals(eq3)); // False (разное количество переменных)

        // Проверка свойств
        eq1.Coefficients[0] = 10;
        eq1.B = 10;
        Console.WriteLine("Измененное уравнение 1: " + eq1); // 10x1 -3x2 +4x3 = 10
    }
}