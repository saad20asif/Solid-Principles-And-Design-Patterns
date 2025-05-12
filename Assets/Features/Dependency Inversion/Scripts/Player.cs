using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class Player : SerializedMonoBehaviour, IDamageable
{
    [SerializeField] private IHealth _health;
    [SerializeField] private HealthBar _healthBar;

    [Inject]
    public void Construct(IHealth health, [Inject(Id = "PlayerHealthBar")] HealthBar healthBar)
    {
        _health = health;
        _healthBar = healthBar;
        _healthBar.Initialize(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
        if (_health.CurrentHealth <= 0) Die();
    }

    private void Die() => Destroy(gameObject);
}