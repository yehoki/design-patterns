using System.Numerics;
using design_patterns.Patterns;

namespace design_patterns.Interfaces;

public interface ILoanBuilder
{
    ILoanBuilder SetType(LoanType type);
    ILoanBuilder SetAmount(BigInteger amount);
    ILoanBuilder SetTerm(int years, int months);
    ILoanBuilder SetInterestRate(InterestRateType interestRateType, double interestRate);
    Loan Build();
}