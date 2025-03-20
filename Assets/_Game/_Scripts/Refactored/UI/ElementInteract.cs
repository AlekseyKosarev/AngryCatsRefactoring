using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementInteract : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int id;
    private ScrollRect scrollRect;
    private bool isDragging = false;
    private GameObject dragCopy; // Копия элемента для перетаскивания
    private RectTransform dragCopyRectTransform;
    private Canvas canvas;

    private void Start()
    {
        scrollRect = GetComponentInParent<ScrollRect>();
        canvas = GetComponentInParent<Canvas>(); // Получаем Canvas для корректного преобразования координат
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        scrollRect.enabled = false; // Отключаем ScrollRect при начале перетаскивания

        // Создаем копию элемента для перетаскивания
        CreateDragCopy();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            scrollRect.enabled = true; // Включаем ScrollRect обратно

            // Вызываем метод Spawn при отпускании
            Spawn();

            // Уничтожаем копию элемента
            Destroy(dragCopy);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging && dragCopy != null)
        {
            // Перемещаем копию элемента вместе с курсором
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPoint);

            dragCopyRectTransform.localPosition = localPoint;
        }
    }

    private void CreateDragCopy()
    {
        // Создаем копию элемента
        dragCopy = Instantiate(gameObject, canvas.transform);
        dragCopyRectTransform = dragCopy.GetComponent<RectTransform>();

        // Настраиваем копию
        dragCopyRectTransform.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        dragCopyRectTransform.localScale = Vector3.one;

        // Удаляем ненужные компоненты у копии
        var copyInteract = dragCopy.GetComponent<ElementInteract>();
        if (copyInteract != null) Destroy(copyInteract);

        var copyButton = dragCopy.GetComponent<Button>();
        if (copyButton != null) Destroy(copyButton);

        // Устанавливаем позицию копии в позицию курсора
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint);

        dragCopyRectTransform.localPosition = localPoint;
    }

    public void Spawn()
    {
        // if (Root.Instance.zoneController.ContainsRectTransform(ZoneType.Forbidden, GetComponent<RectTransform>())) return;
        // Получаем мировые координаты мыши и создаем объект
        var position = Root.Instance.inputLogic.GetMouseWorldPosition();
        var check = Root.Instance.zoneController.ContainsPoint(ZoneType.BuildZone, position);
        if(!check) return;
        Debug.Log("Spawn");
        
        Root.Instance.levelBuilder.SpawnObjectToLevel(id, position);
    }
}