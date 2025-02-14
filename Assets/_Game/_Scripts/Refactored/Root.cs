using UnityEngine;

public class Root: Singleton<Root>
{
    //это рут класс для хранения ссылок на всю инфу,
    //которая будет использоваться во всем проекте
    
    //MainCamera
    [HideInInspector] public Camera mainCamera;
    
    //Input
    public GameInputSystem_Actions InputActions;
    public InputLogic inputLogic;
    public InputModeToggle inputModeToggle;

    // public List<IPausable> pausables;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        mainCamera = Camera.main;
        InputActions = new GameInputSystem_Actions();
    }
}