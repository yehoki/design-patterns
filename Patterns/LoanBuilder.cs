using System.Numerics;
using System;
using design_patterns.Interfaces;

namespace design_patterns.Patterns;

public class LoanBuilder : ILoanBuilder
{
    private readonly Loan _loan = new Loan();

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

    public ILoanBuilder SetAmount(BigInteger amount)
    {
        _loan.Amount = amount;
        return this;
    }

    public ILoanBuilder SetInterestRate(InterestRateType interestRateType, double interestRate)
    {
        _loan.InterestRateType = interestRateType;
        _loan.InterestRate = interestRate;
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
    public double InterestRate { get; set; }
    public BigInteger Amount { get; set; }
    public Term Term { get; set; }

    public void Summarise()
    {
        Console.WriteLine($@"
        Loan Type: {Enum.Format(typeof(LoanType), LoanType, "G")}
        Interest Rate: {Enum.Format(typeof(InterestRateType), InterestRateType, "G")} {InterestRate}%
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