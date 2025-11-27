using System.Numerics;
using design_patterns.Patterns;

namespace design_patterns.Interfaces;

public interface ILoanBuilder
{
    ILoanBuilder SetType(LoanType type);
    ILoanBuilder SetAmount(long amount);
    ILoanBuilder SetTerm(int years, int months);
    ILoanBuilder SetInterestRate(InterestRateType interestRateType, decimal interestRate);
    ILoanBuilder SetMonthVariance(decimal monthVariance);
    Loan Build();
}