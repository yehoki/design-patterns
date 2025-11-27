using design_patterns.Interfaces;
using design_patterns.MultiThreading;
using design_patterns.Patterns;

while (true)
{
    Console.WriteLine("""
                      Press 0 for the Factory pattern
                      Press 1 for the Builder pattern
                      Press 2 for the Strategy pattern
                      Press M for the MultiThreader
                      Press Q to quit
                      """);
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Exiting Program, empty input");
        return;
    }

    if (input.ToLower() == "q")
        return;
    if (input.ToLower() == "m")
    {
        // MultiThreader
        Thread thread = new Thread(MultiThreader.WriteThreadId);
        Thread thread1 = new(MultiThreader.WriteThreadId);
        thread.Priority = ThreadPriority.Highest;
        thread.Priority = ThreadPriority.Lowest;
        Thread.CurrentThread.Priority = ThreadPriority.Normal;
        thread.Start();
        thread1.Start();
        // Current thread
        MultiThreader.WriteThreadId();
        continue;
    }
    if (Enum.TryParse(typeof(Patterns), input, out var pattern))
    {
        Console.WriteLine(pattern);
        // Get pattern
        switch (pattern)
        {
            case Patterns.Factory:
            {
                Console.WriteLine(
                    "We have created a factory pattern that can initialise different characters based on " +
                    "the types necessary");
                ICharacter mage = CharacterFactory.CreateCharacter(CharacterType.Mage);
                mage.Attack();
                ICharacter warrior = CharacterFactory.CreateCharacter(CharacterType.Warrior);
                warrior.Attack();
                break;
            }
            case Patterns.Builder:
            {
                Console.WriteLine("""
                                  We have created a builder pattern, which can stack multiple properties and features based on conditions required
                                  In this scenario, we are building a customisable loan.
                                  """);
                LoanBuilder loanBuilder = new LoanBuilder();
                Loan mortgageLoan = loanBuilder
                    .SetAmount(550000)
                    .SetInterestRate(InterestRateType.Fixed, 39.9m)
                    .SetTerm(30, 0)
                    .SetType(LoanType.Mortgage)
                    .Build();
                loanBuilder.Reset();
                Loan carLoan = loanBuilder
                    .SetAmount(25000)
                    .SetInterestRate(InterestRateType.Variable, 15.0m)
                    .SetTerm(5, 0)
                    .SetType(LoanType.Car)
                    .Build();
                mortgageLoan.Summarise();
                carLoan.Summarise();
                break;
            }
            case Patterns.Strategy:
            {
                Console.WriteLine("""
                                  We have created a strategy pattern, which can sets of behaviours in an object interchangeably
                                  In this scenario, we can run different loans based on what we require
                                  """);
                LoanBuilder loanBuilder = new();
                Loan mortgageLoan = loanBuilder
                    .SetAmount(550000)
                    .SetInterestRate(InterestRateType.Fixed, 4.9m)
                    .SetTerm(30, 0)
                    .SetType(LoanType.Mortgage)
                    .Build();
                LoanContext context = new();
                context.SetStrategy(new FixedInterestStrategy());
                context.RunStrategy(mortgageLoan);
                loanBuilder.Reset();
                Loan carLoan = loanBuilder
                    .SetAmount(25000)
                    .SetInterestRate(InterestRateType.Variable, 5.0m)
                    .SetMonthVariance(0.0001m)
                    .SetTerm(5, 0)
                    .SetType(LoanType.Car)
                    .Build();
                context.SetStrategy(new VariableInterestStrategy());
                context.RunStrategy(carLoan);
                break;
            }
            case Patterns.AbstractFactory:
            {
                break;
            }
            default:
                throw new NotImplementedException("Unknown pattern");
        }
    }
    else
    {
        Console.WriteLine("Invalid input, please try again");
        return;
    }
}


public enum Patterns
{
    Factory,
    Builder,
    Strategy,
    AbstractFactory,
}