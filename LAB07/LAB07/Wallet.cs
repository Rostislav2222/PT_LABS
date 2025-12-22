using System;
using System.Collections.Generic;
using System.Linq;

public class Wallet
{
    public List<Koupon> Koupons { get; private set; } = new List<Koupon>();

    public void AddToWallet(Koupon k)
    {
        if (k == null) throw new ArgumentNullException(nameof(k));
        if (DateTime.Now.Year - k.IssueDate.Year > 10)
            throw new ArgumentException("Купюра старше 10 лет и не может быть добавлена.");
        Koupons.Add(k);
    }

    public void RemoveFromWallet(Koupon k)
    {
        Koupons.Remove(k);
    }

    public double SumInUSD()
    {
        double total = 0;
        foreach (var k in Koupons)
        {
            if (k is IConvertable convertible)
                total += convertible.ConvertToUSD();
        }
        return Math.Round(total, 2);
    }

    public override string ToString()
    {
        if (Koupons.Count == 0) return "Кошелёк пуст.";
        return string.Join("\n", Koupons);
    }

    public static bool operator ==(Wallet w1, Wallet w2)
    {
        if (ReferenceEquals(w1, w2)) return true;
        if (w1 is null || w2 is null) return false;
        return w1.SumInUSD() == w2.SumInUSD();
    }

    public static bool operator !=(Wallet w1, Wallet w2) => !(w1 == w2);

    public override bool Equals(object obj) => obj is Wallet other && this == other;
    public override int GetHashCode() => SumInUSD().GetHashCode();
}