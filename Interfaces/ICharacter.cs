using design_patterns.Patterns;

namespace design_patterns.Interfaces;

public interface ICharacter
{
    int Armor { get; }
    int Agility { get; }
    int Damage { get; }
    int MaxHealth { get; }
    int Mana { get; }
    string Name { get; }
    int Range { get; }
    void Attack();
}