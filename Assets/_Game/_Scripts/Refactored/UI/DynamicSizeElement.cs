using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DynamicSizeElement : MonoBehaviour
{
    public Image objImage; // Ссылка на объектный спрайт
    public Image backImage; // Ссылка на рамку
    private LayoutElement layoutElement;
    private RectTransform rectTransform;
    

    // Отступы для рамки
    public float paddingHorizontal = 10f;
    public float paddingVertical = 10f;

    void Start()
    {
        Init();        
        UpdateSize();
    }

    void Init()
    {
        layoutElement = GetComponent<LayoutElement>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateSize()
    {
        // Получаем размеры спрайта объекта
        if (objImage.sprite != null)
        {
            // Получаем размеры спрайта
            Vector2 spriteSize = objImage.sprite.rect.size;

            // Устанавливаем размеры пустышки
            layoutElement.preferredWidth = spriteSize.x + paddingHorizontal;
            layoutElement.preferredHeight = spriteSize.y + paddingVertical;
            
            rectTransform.sizeDelta = new Vector2(spriteSize.x + paddingHorizontal, spriteSize.y + paddingVertical);
            // Устанавливаем размеры рамки с учетом отступов
            backImage.rectTransform.sizeDelta = new Vector2(spriteSize.x + paddingHorizontal, spriteSize.y + paddingVertical);
        }
    }

    // Метод для установки нового спрайта
    public void SetObjectSprite(Sprite newSprite)
    {
        objImage.sprite = newSprite;
        UpdateSize(); // Обновляем размеры после установки нового спрайта
    }

    // Метод для обновления размеров в редакторе
#if UNITY_EDITOR
    private void OnValidate()
    {
        Init();
        UpdateSize();
    }
#endif
}