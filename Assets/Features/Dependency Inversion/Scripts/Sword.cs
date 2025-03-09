// Sword.cs
using UnityEngine;
using Zenject;

public class Sword : IWeapon
{
    public string Name => "Sword";
    public int Damage => 20;
    private ParticleSystem _effect;

    [Inject]
    public void Initialize(ParticleSystem effect)
    { // Method injection
        _effect = effect;
    }

    public void Attack(IDamageable target)
    {
        _effect.Play();
        target.ApplyDamage(Damage);
    }
}