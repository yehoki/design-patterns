using design_patterns.Interfaces;

namespace design_patterns.Patterns;

public class CharacterFactory
{
    public static ICharacter CreateCharacter(CharacterType type)
    {
        switch (type)
        {
            case CharacterType.Mage:
                return new Mage();
            case CharacterType.Warrior:
                return new Warrior();
            case CharacterType.Archer:
                return new Archer();
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}

public class Archer : ICharacter
{
    public int Armor { get; } = 20;
    public int Agility { get; } = 40;
    public int Damage { get; } = 25;
    public int MaxHealth { get; } = 40;
    public int Mana { get; } = 10;
    public string Name { get; } = "Archer";
    public int Range { get; } = 50;

    public void Attack()
    {
        Console.WriteLine("Archer: Arrow attack");
    }
}

public class Mage : ICharacter
{
    public int Armor { get; } = 10;
    public int Agility { get; } = 30;
    public int Damage { get; } = 40;
    public int MaxHealth { get; } = 20;
    public int Mana { get; } = 70;
    public string Name { get; } = "Mage";
    public int Range { get; } = 40;

    public void Attack()
    {
        Console.WriteLine("Mage: Wand Attack");
    }
}

public class Warrior : ICharacter
{
    public int Armor { get; } = 40;
    public int Agility { get; } = 10;
    public int Damage { get; } = 20;
    public int MaxHealth { get; } = 70;
    public int Mana { get; } = 20;
    public string Name { get; } = "Mage";
    public int Range { get; } = 5;

    public void Attack()
    {
        Console.WriteLine("Warrior: Sword Attack");
    }
}
public enum CharacterType
{
    Mage,
    Warrior,
    Archer
}