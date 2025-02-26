using System;
using UnityEngine;

public class Material_DamageHandler: MonoBehaviour, IDamageable
{
    public event Action<float> OnTryTakeDamage;
    public event Action OnDead;
    
    public float hpMax;
    private float currentHp;

    public void SetDefaultHp()
    {
        currentHp = hpMax;
    }
    public void TryTakeDamage(float damage)
    {
        damage *= Root.Instance.DamageSettings.damageModificator;
        if(damage >= Root.Instance.DamageSettings.minFixDamage)
            OnTryTakeDamage?.Invoke(damage);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            OnDead?.Invoke();
        }
    }

    public int GetCurrentPart(int countParts)
    {
        if (countParts == 0) return 0;
        if (hpMax <= 0) Debug.LogError("max hp is not assigned");
        if (currentHp <= 0) return countParts-1;
        var part = hpMax / countParts;
        var res = countParts - (currentHp / part);
        if (res <= 0) res = 0;
        
        return (int)MathF.Floor(res);
    }

    private void Start()
    {
        SetDefaultHp();
    }
}