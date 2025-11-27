using design_patterns.Patterns;

namespace design_patterns.Interfaces;

public interface ILoanStrategy
{
    decimal CalculateInterest(Loan loan);
}