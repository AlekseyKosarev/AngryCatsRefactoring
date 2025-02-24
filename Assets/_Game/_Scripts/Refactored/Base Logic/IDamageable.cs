using System;

public interface IDamageable
{
    public event Action<int> OnTryTakeDamage;  
    public void TryTakeDamage(int damage);
}