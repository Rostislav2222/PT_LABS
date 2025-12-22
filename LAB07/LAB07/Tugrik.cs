public class Tugrik : Koupon, IConvertable
{
    public Tugrik(int denomination, DateTime issueDate)
        : base(new[] { 10, 20, 50, 100, 500, 1000, 5000, 10000, 20000 }, denomination, issueDate) { }

    public double Course => 0;
    public double ConvertToUSD() => 0;
}