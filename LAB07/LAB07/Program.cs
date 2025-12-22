using System;
using System.Collections.Generic;

// Предполагается, что у тебя уже есть классы Employee, Manager, Worker, Programmer, Trainee и т.д.
// Этот файл дополняет их тестом индивидуального задания.

class Program
{
    static void Main(string[] args)
    {
        // ============= ЗАДАНИЕ 0 (уже существующая логика) =============
        // Пример (если у тебя есть свой код — оставь его здесь):
        /*
        var dep = new Department("IT");
        var emp1 = new Worker("Иван", "Петров", 45000);
        var emp2 = new Manager("Анна", "Сидорова", 70000, "IT");
        var emp3 = new Programmer("Алексей", "Козлов", 60000, "C#");
        var emp4 = new Trainee("Мария", "Волкова", "Java");

        dep.AddEmployee(emp1);
        dep.AddEmployee(emp2);
        dep.AddEmployee(emp3);
        dep.AddEmployee(emp4);

        dep.PrintAllEmployees();
        */

        // ⚠️ Если у тебя уже есть свой рабочий код в Main — оставь его выше.
        // Ниже — запуск индивидуального задания.

        // ============= ИНДИВИДУАЛЬНОЕ ЗАДАНИЕ №4 (кошелёк) =============
        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("ТЕСТ ИНДИВИДУАЛЬНОГО ЗАДАНИЯ: КОШЕЛЁК С КУПЮРАМИ");
        Console.WriteLine(new string('=', 60));
        TestWalletTask();
    }

    // Метод для тестирования кошелька и купюр
    static void TestWalletTask()
    {
        var wallet1 = new Wallet();
        var wallet2 = new Wallet();

        // Добавление купюр (все — не старше 10 лет на 2025 год)
        try
        {
            wallet1.AddToWallet(new Pound(20, new DateTime(2020, 1, 1)));   // 20 фунтов
            wallet1.AddToWallet(new Ruble(1000, new DateTime(2018, 5, 10))); // 1000 руб
            wallet1.AddToWallet(new Tugrik(10000, new DateTime(2022, 3, 15))); // 10000 тугриков
            wallet1.AddToWallet(new Pound(50, new DateTime(2023, 11, 1))); // 50 фунтов
            wallet1.AddToWallet(new Ruble(500, new DateTime(2024, 7, 20))); // 500 руб

            wallet2.AddToWallet(new Ruble(2000, new DateTime(2021, 2, 14))); // 2000 руб
            wallet2.AddToWallet(new Pound(10, new DateTime(2019, 8, 30)));  // 10 фунтов
            wallet2.AddToWallet(new Tugrik(5000, new DateTime(2023, 12, 1))); // 5000 тугриков
            wallet2.AddToWallet(new Ruble(100, new DateTime(2025, 1, 10)));  // 100 руб
            wallet2.AddToWallet(new Pound(5, new DateTime(2024, 6, 18)));   // 5 фунтов
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"❌ Ошибка при добавлении купюры: {ex.Message}");
            return;
        }

        // Вывод содержимого кошельков
        Console.WriteLine("🪙 Кошелёк 1:");
        Console.WriteLine(wallet1);
        Console.WriteLine($"➡ Сумма в USD: ${wallet1.SumInUSD()}");

        Console.WriteLine("\n🪙 Кошелёк 2:");
        Console.WriteLine(wallet2);
        Console.WriteLine($"➡ Сумма в USD: ${wallet2.SumInUSD()}");

        // Сравнение кошельков
        Console.WriteLine($"\n⚖️ Кошельки равны по стоимости в USD? {(wallet1 == wallet2 ? "Да" : "Нет")}");

        // Удаление купюры
        if (wallet1.Koupons.Count > 0)
        {
            var removed = wallet1.Koupons[0];
            wallet1.RemoveFromWallet(removed);
            Console.WriteLine($"\n🗑️ Удалена купюра: {removed}");
            Console.WriteLine($"Новая сумма кошелька 1: ${wallet1.SumInUSD()}");
        }
    }
}
