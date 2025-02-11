using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatsData", menuName = "ScriptableObjects/CatsData", order = 2)]
public class CatsDataSO: ScriptableObject
{
    //тут вся изменяемая инфа о конкретном коте -
    //множители урона
    //ресурсы
    //спрайт - в префабе
    //эффект
    public List<StringFloatPair> damageMultipliers;

    public float GetDamageMultiplier(MaterialsEnum materialName)
    {
        foreach (var pair in damageMultipliers)
        {
            if (pair.key == materialName)
            {
                return pair.value;
            }
        }
        return 1f; // Возвращаем 1, если материал не найден
    }
}

[System.Serializable]
public class StringFloatPair
{
    public MaterialsEnum key;
    public float value = 1f;
}