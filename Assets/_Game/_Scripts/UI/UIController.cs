using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController: MonoBehaviour
{
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        var button = root.Q<Button>("PlayButton");

        button.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
    }
    private void OnOpenButtonClicked(ClickEvent evt)
    {
        Debug.Log("Button Clicked");
    }
}