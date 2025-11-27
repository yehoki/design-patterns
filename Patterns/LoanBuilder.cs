using System.Numerics;
using design_patterns.Interfaces;

namespace design_patterns.Patterns;

public class LoanBuilder : ILoanBuilder
{
    private Loan _loan = new Loan();

    public void Reset()
    {
        _loan = new Loan();
    }

    public ILoanBuilder SetType(LoanType type)
    {
        _loan.LoanType = type;
        return this;
    }

    public ILoanBuilder SetTerm(int years, int months)
    {
        _loan.Term = new Term(years, months);
        return this;
    }

    public ILoanBuilder SetAmount(long amount)
    {
        _loan.Amount = amount;
        return this;
    }

    public ILoanBuilder SetInterestRate(InterestRateType interestRateType, decimal interestRate)
    {
        _loan.InterestRateType = interestRateType;
        _loan.InterestRate = interestRate;
        return this;
    }

    public ILoanBuilder SetMonthVariance(decimal monthVariance)
    {
        _loan.MonthVariance = monthVariance;
        return this;
    }

    public Loan Build()
    {
        return _loan;
    }
}

public class Loan
{
    public LoanType LoanType { get; set; }
    public InterestRateType InterestRateType { get; set; }
    public decimal InterestRate { get; set; }
    public decimal MonthVariance { get; set; } = 0m;
    public long Amount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public Term Term { get; set; }

    public void Summarise()
    {
        Console.WriteLine($@"
        Loan Type: {Enum.Format(typeof(LoanType), LoanType, "G")}
        Interest Rate: {Enum.Format(typeof(InterestRateType), InterestRateType, "G")} {InterestRate}% with {MonthVariance} variance per month
        Amount: £{Amount}
        Term: {Term.Years} years and  {Term.Months} months
");
    }
}

public class Term(int years, int months)
{
    public int Years { get; set; } = years;
    public int Months { get; set; } = months;
}

public enum LoanType
{
    Mortgage,
    Personal,
    Car,
    Business
}

public enum InterestRateType
{
    Fixed,
    Variable
}