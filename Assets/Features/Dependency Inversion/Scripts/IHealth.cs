using System;

public interface IHealth
{
    int CurrentHealth { get; }
    void TakeDamage(int amount);
    event Action<int> OnHealthChanged;
}