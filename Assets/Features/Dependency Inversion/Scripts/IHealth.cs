using System;

public interface IHealth
{
    int CurrentHealth { get; }
    void TakeDamage(int damage);
    void Heal(int amount);
    event Action<int> OnHealthChanged;
}