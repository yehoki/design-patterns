// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;


while (true)
{
    Console.WriteLine("Hello, World!");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
        Console.WriteLine("Exiting Program, empty input");
    if (Enum.TryParse(typeof(Patterns), input, out var pattern))
    {
        // Get pattern
    }
    else
    {
        Console.WriteLine("Invalid input, please try again");
    }
}


public enum Patterns
{
    Factory,
    AbstractFactory,
    Builder,
}