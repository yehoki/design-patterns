using design_patterns.Interfaces;
using design_patterns.Patterns;

while (true)
{
    Console.WriteLine("""
                      Press 0 for the Factory pattern
                      Press 1 for the Builder pattern
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
            case Patterns.AbstractFactory:
            {
                break;
            }
            case Patterns.Builder:
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
    AbstractFactory,
    Prototype,
}