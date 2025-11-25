using System;

public class Time
{
    private int _hours;
    private int _minutes;
    private int _seconds;

    // Свойства с валидацией
    public int Hours
    {
        get { return _hours; }
        set
        {
            if (value < 0 || value > 23)
                throw new ArgumentException("Часы должны быть в диапазоне от 0 до 23");
            _hours = value;
        }
    }

    public int Minutes
    {
        get { return _minutes; }
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentException("Минуты должны быть в диапазоне от 0 до 59");
            _minutes = value;
        }
    }

    public int Seconds
    {
        get { return _seconds; }
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentException("Секунды должны быть в диапазоне от 0 до 59");
            _seconds = value;
        }
    }

    // Конструктор с параметрами
    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    // Метод нормализации времени после арифметических операций
    private void Normalize()
    {
        // Нормализация секунд
        if (_seconds >= 60)
        {
            _minutes += _seconds / 60;
            _seconds %= 60;
        }
        else if (_seconds < 0)
        {
            _minutes += (_seconds - 59) / 60;
            _seconds = (_seconds % 60 + 60) % 60;
        }

        // Нормализация минут
        if (_minutes >= 60)
        {
            _hours += _minutes / 60;
            _minutes %= 60;
        }
        else if (_minutes < 0)
        {
            _hours += (_minutes - 59) / 60;
            _minutes = (_minutes % 60 + 60) % 60;
        }

        // Нормализация часов (в пределах суток)
        _hours = (_hours % 24 + 24) % 24;
    }

    // Перегрузка оператора + для сложения времени и числа минут
    public static Time operator +(Time time, int minutesToAdd)
    {
        Time result = new Time(time.Hours, time.Minutes, time.Seconds);
        result._minutes += minutesToAdd;
        result.Normalize();
        return result;
    }

    // Перегрузка оператора - для вычитания числа минут из времени
    public static Time operator -(Time time, int minutesToSubtract)
    {
        Time result = new Time(time.Hours, time.Minutes, time.Seconds);
        result._minutes -= minutesToSubtract;
        result.Normalize();
        return result;
    }

    // Перегрузка оператора - для вычитания двух времён (результат в минутах)
    public static int operator -(Time time1, Time time2)
    {
        // Преобразуем оба времени в минуты с начала суток
        int totalMinutes1 = time1.Hours * 60 + time1.Minutes;
        int totalMinutes2 = time2.Hours * 60 + time2.Minutes;

        // Вычисляем разницу
        int difference = totalMinutes1 - totalMinutes2;

        // Корректируем для случая, когда первое время раньше второго
        if (difference < 0)
        {
            difference += 24 * 60; // Добавляем минуты в сутках
        }

        return difference;
    }

    // Переопределение ToString()
    public override string ToString()
    {
        return $"[{Hours:D2} : {Minutes:D2} : {Seconds:D2}]";
    }

    // Переопределение Equals()
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Time other = (Time)obj;
        return _hours == other._hours &&
               _minutes == other._minutes &&
               _seconds == other._seconds;
    }

    // Переопределение GetHashCode()
    public override int GetHashCode()
    {
        return (_hours * 3600 + _minutes * 60 + _seconds).GetHashCode();
    }
}
