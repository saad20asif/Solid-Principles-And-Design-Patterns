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

    public void TakeDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        OnHealthChanged?.Invoke(CurrentHealth);
    }
}