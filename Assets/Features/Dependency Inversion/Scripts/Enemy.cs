using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private IHealth _health;
    [SerializeField] private HealthBar _healthBar;

    [Inject]
    public void Construct(IHealth health, HealthBar healthBar)
    {
        _health = health;
        _healthBar = healthBar;
        _healthBar.Initialize(_health); // Initialize health bar
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
        if (_health.CurrentHealth <= 0) Die();
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Destroy enemy on death
    }
}