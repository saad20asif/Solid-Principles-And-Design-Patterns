// Player.cs
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IDamageable
{
    private IWeapon _currentWeapon;
    private IHealth _health;
    private RuntimeAnimatorController _anim;

    [Inject]
    public void Construct(IWeapon weapon, IHealth health, RuntimeAnimatorController anim)
    {
        _currentWeapon = weapon;
        _health = health;
        _anim = anim;
    }

    public void Attack(IDamageable target)
    {
        //_anim.PlayAttack();
        _currentWeapon.Attack(target);
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
        //_anim.PlayHit();
    }
}