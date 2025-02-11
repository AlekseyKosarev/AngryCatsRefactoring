
using System;

public interface IDamageable
{
    public float MaxHp { get; set; }
    public float Hp { get; set; }
    public bool Alive { get; set; }
    public Action OnDead { get; set; }
    public void GetDamage(float dmg);
}