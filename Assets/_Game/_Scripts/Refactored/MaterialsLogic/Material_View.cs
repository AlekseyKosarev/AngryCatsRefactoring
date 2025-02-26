using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Material_View: MonoBehaviour
{
    [SerializeField] private List<Sprite> materialParts;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;

    private int currentSpritePart;

    public void SetDefaultView()
    {
        SetDefaultColor();
        SetDefaultSpritePart();
    }
    public void DeadView()
    {
        StopActiveEffects();
        spriteRenderer.DOFade( 0f, 0.2f);
    }
    public void SetDefaultSpritePart()
    {
        SetSpritePartByIndex(0);
    }
    public void SetSpritePartByIndex(int indexPart)
    {
        if (materialParts.Count <= indexPart)
        {
            //Debug.LogError(indexPart);
            return;
        }
        spriteRenderer.sprite = materialParts[indexPart];
    }

    public int GetCountSpriteParts()
    {
        return materialParts.Count;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
    public void SetSelectedColor()
    {
        spriteRenderer.color = selectedColor;
    }
    public void SetDefaultColor()
    {
        spriteRenderer.color = defaultColor;
    }

    public void StopActiveEffects()
    {
        // Debug.Log("StopActiveEffects");
    }
    public void ResumeActiveEffects()
    {
        // Debug.Log("ResumeActiveEffects");
    }
}