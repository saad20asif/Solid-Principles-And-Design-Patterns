// Health.cs
using System;
using UnityEngine;

public class Health : IHealth
{
    public int CurrentHealth { get; private set; }
    public event Action<int> OnHealthChanged;

    public Health(int maxHealth)
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
}