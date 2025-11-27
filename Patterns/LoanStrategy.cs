using System.Numerics;
using design_patterns.Interfaces;

namespace design_patterns.Patterns;

public class LoanContext
{
    private ILoanStrategy _strategy;

    public LoanContext(ILoanStrategy strategy)
    {
        _strategy = strategy;
    }

    public LoanContext()
    {
    }

    public void SetStrategy(ILoanStrategy strategy)
    {
        _strategy = strategy;
    }

    public void RunStrategy(Loan loan)
    {
        decimal interest = Math.Round(_strategy.CalculateInterest(loan), 2);
        Console.WriteLine($"""
                          Using the current strategy, we'd get £{interest} worth of interest. 
                          """);
    }
}

public class FixedInterestStrategy : ILoanStrategy
{
    public decimal CalculateInterest(Loan loan)
    {
        int loanMonths = 12 * loan.Term.Years + loan.Term.Months;
        decimal interest = (loan.Amount * (loanMonths / 12m)) * loan.InterestRate;
        return interest;
    }
}

public class VariableInterestStrategy : ILoanStrategy
{
    public decimal CalculateInterest(Loan loan)
    {
        int loanMonths = 12 * loan.Term.Years + loan.Term.Months;
        decimal interest = 0m;
        for (int month = 0; month < loanMonths; month++)
        {
            decimal monthlyRate = (loan.InterestRate + month * loan.MonthVariance) / 12;
            interest += monthlyRate * loan.Amount;
        }

        return interest;
    }
}