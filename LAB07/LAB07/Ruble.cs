public class Ruble : Koupon, IConvertable
{
    public Ruble(int denomination, DateTime issueDate)
        : base(new[] { 50, 100, 200, 500, 1000, 2000, 5000 }, denomination, issueDate) { }

    public double Course => 0.011;
    public double ConvertToUSD() => Denomination * Course;
}