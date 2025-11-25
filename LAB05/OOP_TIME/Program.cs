using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Тестирование класса Time ===\n");

        try
        {
            // Создание двух экземпляров класса Time
            Time time1 = new Time(14, 30, 45);
            Time time2 = new Time(9, 15, 20);

            Console.WriteLine($"Time1: {time1}");
            Console.WriteLine($"Time2: {time2}");

            // Проверка оператора + (добавление минут)
            Time time1Plus60 = time1 + 60;
            Console.WriteLine($"\n[Операция +] Time1 + 60 минут = {time1Plus60}");

            // Проверка оператора - (вычитание минут)
            Time time1Minus45 = time1 - 45;
            Console.WriteLine($"[Операция -] Time1 - 45 минут = {time1Minus45}");

            // Проверка оператора - (разница между двумя временами)
            int timeDifference = time1 - time2;
            Console.WriteLine($"[Операция -] Разница между Time1 и Time2: {timeDifference} минут");

            // Дополнительные тесты для проверки перехода через границы суток
            Console.WriteLine("\n=== Дополнительные тесты ===");
            Time lateNight = new Time(23, 45, 30);
            Time earlyMorning = new Time(1, 30, 15);

            Console.WriteLine($"Поздняя ночь: {lateNight}");
            Console.WriteLine($"Раннее утро: {earlyMorning}");

            Time lateNightPlus90 = lateNight + 90;
            Console.WriteLine($"Поздняя ночь + 90 минут = {lateNightPlus90}");

            Time earlyMorningMinus120 = earlyMorning - 120;
            Console.WriteLine($"Раннее утро - 120 минут = {earlyMorningMinus120}");

            int diffNightToMorning = earlyMorning - lateNight;
            Console.WriteLine($"Разница от поздней ночи до раннего утра: {diffNightToMorning} минут");

            // Проверка сравнения времен
            Console.WriteLine("\n=== Проверка сравнения ===");
            Time sameAsTime1 = new Time(14, 30, 45);
            Console.WriteLine($"Time1 == sameAsTime1: {time1.Equals(sameAsTime1)}");
            Console.WriteLine($"Time1 == Time2: {time1.Equals(time2)}");

            // Попытка создания некорректного времени
            Console.WriteLine("\n=== Попытка создания некорректного времени ===");
            Console.WriteLine("Попытка создать время с 25 часами...");
            Time invalidTime = new Time(25, 30, 45);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка валидации: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}