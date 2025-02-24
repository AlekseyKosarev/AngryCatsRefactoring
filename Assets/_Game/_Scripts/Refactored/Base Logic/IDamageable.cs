using System;

public interface IDamageable
{
    public event Action<float> OnTryTakeDamage;  
    public void TryTakeDamage(float damage);
}