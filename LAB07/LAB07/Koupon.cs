using System;

public abstract class Koupon
{
    protected int[] _allowedDenominations;
    protected int _denomination;
    protected DateTime _issueDate;

    public Koupon(int[] allowedDenominations, int denomination, DateTime issueDate)
    {
        _allowedDenominations = allowedDenominations ?? throw new ArgumentNullException(nameof(allowedDenominations));
        if (!Array.Exists(_allowedDenominations, d => d == denomination))
            throw new ArgumentException("Номинал не входит в разрешённый набор.", nameof(denomination));

        _denomination = denomination;
        _issueDate = issueDate;
    }

    public int Denomination => _denomination;
    public DateTime IssueDate => _issueDate;

    public override string ToString()
    {
        return $"Номинал: {_denomination}, Дата выпуска: {_issueDate:yyyy-MM-dd}";
    }
}