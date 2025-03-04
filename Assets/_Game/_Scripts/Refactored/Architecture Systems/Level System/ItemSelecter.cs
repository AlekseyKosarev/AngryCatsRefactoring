using System.Collections.Generic;
using UnityEngine;

public class ItemSelecter: MonoBehaviour
{
    public List<ISelectable> selectedItems = new();
    public GameObject rotatePointerPrefab;
    private GameObject rotatePointer;
    
    public void SelectOneItem(ISelectable item)
    {
        ClearSelectedItems();
        selectedItems.Add(item);
        RotatePointerActive(item);
    }
    // public void SelectMultipleItems(List<GameObject> items)
    // {
    //     ClearSelectedItems();
    //     selectedItems.AddRange(items);
    // }
    public void ClearSelectedItems()
    {
        foreach (var item in selectedItems)
        {
            item.Deselect();
        }
        selectedItems.Clear();
        Destroy(rotatePointer);
    }
    
    private void RotatePointerActive(ISelectable item)
    {
        rotatePointer = Instantiate(rotatePointerPrefab, item.gameObject.transform);
        rotatePointer.transform.position = item.gameObject.transform.position + item.gameObject.transform.up*2f;
        rotatePointer.SetActive(true);
    }
}