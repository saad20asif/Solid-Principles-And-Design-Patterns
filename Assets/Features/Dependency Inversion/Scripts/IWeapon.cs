public interface IWeapon
{
    string Name { get; }
    int Damage { get; }
    void Attack(IDamageable target);
}
