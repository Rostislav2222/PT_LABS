using System;
using System.Text;
using System.Collections.Generic;

namespace CS_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("  Лабораторная работа №3 - CS_Basics");
                Console.WriteLine("  Основы языка программирования C#");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Блок 1. Переменные и операторы");
                Console.WriteLine("2. Блок 2. Условные операторы");
                Console.WriteLine("3. Блок 3. Циклы");
                Console.WriteLine("4. Блок 4. Массивы");
                Console.WriteLine("5. Блок 5. Функции");
                Console.WriteLine("9. Выход");
                Console.Write("\nВыберите блок: ");

                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1": Block1(); break;
                    case "2": Block2(); break;
                    case "3": Block3(); break;
                    case "4": Block4(); break;
                    case "5": Block5(); break;
                    case "9":
                        exit = true;
                        Console.WriteLine("Закрывается...");
                        break;
                    default:
                        Console.WriteLine("Неправильная опция. Введите корректный вариант.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ===== Блок 1: Переменные и операторы (2, 4, 6) =====
        static void Block1()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 1. Переменные и операторы");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Индекс массы тела (ИМТ)");
                Console.WriteLine("4. Перевод времени (секунды → ч:м:с)");
                Console.WriteLine("6. Цена со скидкой");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Введите вес (кг): ");
                        double.TryParse(Console.ReadLine(), out double weight);
                        Console.Write("Введите рост (см): ");
                        double.TryParse(Console.ReadLine(), out double heightCm);
                        if (heightCm > 0 && weight > 0)
                        {
                            double heightM = heightCm / 100.0;
                            double bmi = weight / (heightM * heightM);
                            Console.WriteLine($"ИМТ: {bmi:F1}");
                        }
                        else
                        {
                            Console.WriteLine("Рост и вес должны быть больше нуля.");
                        }
                        Pause();
                        break;

                    case "4":
                        Console.Write("Введите количество секунд: ");
                        if (int.TryParse(Console.ReadLine(), out int totalSeconds) && totalSeconds >= 0)
                        {
                            int h = totalSeconds / 3600;
                            int m = (totalSeconds % 3600) / 60;
                            int s = totalSeconds % 60;
                            Console.WriteLine($"Результат: {h:D2}:{m:D2}:{s:D2}");
                        }
                        else
                        {
                            Console.WriteLine("Неправильный ввод. Введите целое число ≥ 0.");
                        }
                        Pause();
                        break;

                    case "6":
                        Console.Write("Введите цену: ");
                        double.TryParse(Console.ReadLine(), out double price);
                        Console.Write("Введите скидку (%): ");
                        double.TryParse(Console.ReadLine(), out double discount);
                        if (price >= 0 && discount >= 0)
                        {
                            double finalPrice = price * (1 - discount / 100);
                            Console.WriteLine($"Итоговая цена: {finalPrice:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Цена и скидка должны быть неотрицательными.");
                        }
                        Pause();
                        break;

                    case "9":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }

        // ===== Блок 2: Условные операторы (2, 4, 6) =====
        static void Block2()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 2. Условные операторы");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Тип треугольника");
                Console.WriteLine("4. Оценка по числу");
                Console.WriteLine("6. Конвертация валют");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Сторона A: ");
                        double.TryParse(Console.ReadLine(), out double a);
                        Console.Write("Сторона B: ");
                        double.TryParse(Console.ReadLine(), out double b);
                        Console.Write("Сторона C: ");
                        double.TryParse(Console.ReadLine(), out double c);
                        if (a > 0 && b > 0 && c > 0)
                        {
                            if (a + b > c && a + c > b && b + c > a)
                            {
                                if (a == b && b == c) Console.WriteLine("Равносторонний");
                                else if (a == b || b == c || a == c) Console.WriteLine("Равнобедренный");
                                else Console.WriteLine("Разносторонний");
                            }
                            else
                            {
                                Console.WriteLine("Треугольник не существует.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Стороны должны быть положительными.");
                        }
                        Pause();
                        break;

                    case "4":
                        Console.Write("Введите оценку (1-5): ");
                        int.TryParse(Console.ReadLine(), out int grade);
                        string desc = grade switch
                        {
                            1 => "Плохо",
                            2 => "Неудовлетворительно",
                            3 => "Удовлетворительно",
                            4 => "Хорошо",
                            5 => "Отлично",
                            _ => "Неправильный ввод"
                        };
                        Console.WriteLine(desc);
                        Pause();
                        break;

                    case "6":
                        Console.Write("Введите сумму в рублях: ");
                        double.TryParse(Console.ReadLine(), out double amount);
                        Console.Write("Выберите валюту (1:USD, 2:EUR, 3:GBP): ");
                        string? ch = Console.ReadLine();
                        if (amount >= 0)
                        {
                            switch (ch)
                            {
                                case "1": Console.WriteLine($"{amount * 0.011:F2} USD"); break;
                                case "2": Console.WriteLine($"{amount * 0.010:F2} EUR"); break;
                                case "3": Console.WriteLine($"{amount * 0.0087:F2} GBP"); break;
                                default: Console.WriteLine("Неправильный ввод валюты."); break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сумма должна быть неотрицательной.");
                        }
                        Pause();
                        break;

                    case "9":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }

        // ===== Блок 3: Циклы (2, 4, 6) =====
        static void Block3()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 3. Циклы");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Переворот числа");
                Console.WriteLine("4. Максимальное нечётное");
                Console.WriteLine("6. Арифметическая прогрессия");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Введите целое число: ");
                        int.TryParse(Console.ReadLine(), out int numToReverse);
                        int reversed = 0;
                        int inputCopy = Math.Abs(numToReverse);
                        while (inputCopy != 0)
                        {
                            reversed = reversed * 10 + inputCopy % 10;
                            inputCopy /= 10;
                        }
                        reversed *= Math.Sign(numToReverse);
                        Console.WriteLine($"Перевернутое число: {reversed}");
                        Pause();
                        break;

                    case "4":
                        Console.Write("Начало диапазона (a): ");
                        int.TryParse(Console.ReadLine(), out int start);
                        Console.Write("Конец диапазона (b): ");
                        int.TryParse(Console.ReadLine(), out int end);
                        if (start > end)
                        {
                            int tmp = start; start = end; end = tmp;
                        }
                        bool found = false;
                        for (int i = end; i >= start; i--)
                        {
                            if (i % 2 != 0)
                            {
                                Console.WriteLine($"Максимальное нечётное число: {i}");
                                found = true;
                                break;
                            }
                        }
                        if (!found) Console.WriteLine("Нечётных не найдено.");
                        Pause();
                        break;

                    case "6":
                        Console.Write("Количество членов ряда (n): ");
                        int.TryParse(Console.ReadLine(), out int terms);
                        Console.Write("Первый член ряда (a1): ");
                        double.TryParse(Console.ReadLine(), out double firstTerm);
                        Console.Write("Разность ряда (d): ");
                        double.TryParse(Console.ReadLine(), out double diff);
                        if (terms > 0)
                        {
                            double currentTerm = firstTerm;
                            double progressionSum = 0;
                            Console.Write("Ряд: ");
                            for (int i = 0; i < terms; i++)
                            {
                                Console.Write(currentTerm + " ");
                                progressionSum += currentTerm;
                                currentTerm += diff;
                            }
                            Console.WriteLine($"\nСумма: {progressionSum}");
                        }
                        else
                        {
                            Console.WriteLine("n должно быть > 0.");
                        }
                        Pause();
                        break;

                    case "9":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }

        // ===== Блок 4: Массивы (2, 4, 6) =====
        static void Block4()
        {
            bool back = false;
            Random rand = new Random();
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 4. Массивы");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Второй по величине элемент (1D)");
                Console.WriteLine("4. Чётные элементы в столбцах (2D)");
                Console.WriteLine("6. Диагонали матрицы (2D квадратная)");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Введите размер массива: ");
                        if (int.TryParse(Console.ReadLine(), out int size) && size >= 2)
                        {
                            int[] arr = new int[size];
                            for (int i = 0; i < size; i++) arr[i] = rand.Next(1, 101);
                            Console.WriteLine("Массив: " + string.Join(", ", arr));

                            int largest = int.MinValue;
                            int secondLargest = int.MinValue;
                            foreach (int num in arr)
                            {
                                if (num > largest)
                                {
                                    secondLargest = largest;
                                    largest = num;
                                }
                                else if (num > secondLargest && num != largest)
                                {
                                    secondLargest = num;
                                }
                            }
                            if (secondLargest == int.MinValue)
                                Console.WriteLine("Нет второго по величине элемента (все элементы одинаковые).");
                            else
                                Console.WriteLine($"Второй по величине элемент: {secondLargest}");
                        }
                        else
                        {
                            Console.WriteLine("Размер должен быть целым числом ≥ 2.");
                        }
                        Pause();
                        break;

                    case "4":
                        Console.Write("Количество строк: ");
                        int.TryParse(Console.ReadLine(), out int rowsEven);
                        Console.Write("Количество столбцов: ");
                        int.TryParse(Console.ReadLine(), out int colsEven);
                        if (rowsEven > 0 && colsEven > 0)
                        {
                            int[,] matrix = new int[rowsEven, colsEven];
                            Console.WriteLine("\nМатрица:");
                            for (int i = 0; i < rowsEven; i++)
                            {
                                for (int j = 0; j < colsEven; j++)
                                {
                                    matrix[i, j] = rand.Next(1, 101);
                                    Console.Write(matrix[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }

                            int[] evenCounts = new int[colsEven];
                            for (int j = 0; j < colsEven; j++)
                            {
                                for (int i = 0; i < rowsEven; i++)
                                {
                                    if (matrix[i, j] % 2 == 0)
                                    {
                                        evenCounts[j]++;
                                    }
                                }
                            }
                            Console.WriteLine("\nЧётных в столбцах: " + string.Join(", ", evenCounts));

                            int maxCol = 0;
                            for (int j = 1; j < colsEven; j++)
                                if (evenCounts[j] > evenCounts[maxCol]) maxCol = j;
                            Console.WriteLine($"Столбец с максимумом чётных: {maxCol} (кол-во {evenCounts[maxCol]})");
                        }
                        else
                        {
                            Console.WriteLine("Размеры матрицы должны быть > 0.");
                        }
                        Pause();
                        break;

                    case "6":
                        Console.Write("Размер матрицы (n x n): ");
                        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                        {
                            int[,] matrix = new int[n, n];
                            Console.WriteLine("\nМатрица:");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++)
                                {
                                    matrix[i, j] = rand.Next(1, 101);
                                    Console.Write(matrix[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }

                            int maxMain = int.MinValue;
                            int maxSecondary = int.MinValue;
                            for (int i = 0; i < n; i++)
                            {
                                if (matrix[i, i] > maxMain) maxMain = matrix[i, i];
                                if (matrix[i, n - 1 - i] > maxSecondary) maxSecondary = matrix[i, n - 1 - i];
                            }
                            Console.WriteLine($"\nМаксимум на главной диагонали: {maxMain}");
                            Console.WriteLine($"Максимум на побочной диагонали: {maxSecondary}");
                            Console.WriteLine($"Сумма максимумов: {maxMain + maxSecondary}");
                        }
                        else
                        {
                            Console.WriteLine("n должно быть > 0.");
                        }
                        Pause();
                        break;

                    case "9":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }

        // ===== Блок 5: Функции (2, 4, 6, 8 для удобства демонстрации) =====
        static void Block5()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("Блок 5. Функции");
                Console.WriteLine("========================================");
                Console.WriteLine("2. Генерация массива");
                Console.WriteLine("4. Сумма цифр числа (рекурсия)");
                Console.WriteLine("6. Разделение числа (целая/дробная)");
                Console.WriteLine("8. Длины строк (params)");
                Console.WriteLine("9. Вернуться в меню");
                Console.Write("\nВыберите задачу: ");

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Write("Количество: ");
                        int.TryParse(Console.ReadLine(), out int count);
                        Console.Write("Мин значение: ");
                        int.TryParse(Console.ReadLine(), out int min);
                        Console.Write("Макс значение: ");
                        int.TryParse(Console.ReadLine(), out int max);
                        if (count >= 0 && min <= max)
                        {
                            int[] randomArray = GenerateArray(count, min, max);
                            Console.WriteLine("Массив: " + string.Join(", ", randomArray));
                        }
                        else
                        {
                            Console.WriteLine("Проверьте параметры (count ≥ 0, min ≤ max).");
                        }
                        Pause();
                        break;

                    case "4":
                        Console.Write("Число для суммы цифр: ");
                        int.TryParse(Console.ReadLine(), out int numToSum);
                        Console.WriteLine($"Сумма цифр: {DigitSum(numToSum)}");
                        Pause();
                        break;

                    case "6":
                        Console.Write("Введите число: ");
                        double.TryParse(Console.ReadLine(), out double number);
                        Split(number, out int whole, out double fraction);
                        Console.WriteLine($"Целая часть: {whole}, Дробная часть: {fraction}");
                        Pause();
                        break;

                    case "8":
                        Console.Write("Введите строки через пробел: ");
                        string[] strings = (Console.ReadLine() ?? "")
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int[] lengths = GetLengths(strings);
                        Console.WriteLine("Длины строк: " + string.Join(", ", lengths));
                        Pause();
                        break;

                    case "9":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Неправильный ввод.");
                        Pause();
                        break;
                }
            }
        }

        // ===== Вспомогательные функции для блока 5 =====
        static int[] GenerateArray(int count, int min, int max)
        {
            Random rand = new Random();
            int[] arr = new int[count];
            for (int i = 0; i < count; i++) arr[i] = rand.Next(min, max + 1);
            return arr;
        }

        static int DigitSum(int number)
        {
            number = Math.Abs(number);
            if (number == 0) return 0;
            return number % 10 + DigitSum(number / 10);
        }

        static void Split(double number, out int whole, out double fraction)
        {
            whole = (int)Math.Truncate(number);
            fraction = number - whole;
        }

        static int[] GetLengths(params string[] strings)
        {
            int[] lengths = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                lengths[i] = strings[i]?.Length ?? 0;
            }
            return lengths;
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey(true);
        }
    }
}
