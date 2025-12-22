public class Pound : Koupon, IConvertable
{
    public Pound(int denomination, DateTime issueDate)
        : base(new[] { 5, 10, 20, 50 }, denomination, issueDate) { }

    public double Course => 1.27;
    public double ConvertToUSD() => Denomination * Course;
}