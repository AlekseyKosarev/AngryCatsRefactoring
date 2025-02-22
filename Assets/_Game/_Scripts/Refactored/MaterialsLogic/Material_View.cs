using UnityEngine;

public class Material_View: MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color selectedColor;
    public Color defaultColor;
    
    // public void SetMaterial(BaseMaterial material)
    // {
    //     spriteRenderer.sprite = material.sprite;
    // }

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