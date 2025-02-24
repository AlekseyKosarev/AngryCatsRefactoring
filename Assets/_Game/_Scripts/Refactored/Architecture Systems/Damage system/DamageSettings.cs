using UnityEngine;
using UnityEngine.Serialization;

public class DamageSettings: MonoBehaviour
{
    public float damageModificator = 0.1f;
    [FormerlySerializedAs("fixDamage")] public float minFixDamage = 5f;
    public float lifeTimeDefault = 1f;
}