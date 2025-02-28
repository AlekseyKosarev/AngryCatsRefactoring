using System.Collections.Generic;
using _Game._Scripts.Copy;
using UnityEngine;
using UnityEngine.Serialization;

public class Root: Singleton<Root>
{
    //это рут класс для хранения ссылок на всю инфу,
    //которая будет использоваться во всем проекте
    
    //MainCamera
    [HideInInspector] public Camera mainCamera;
    
    //Global Modes
    public GlobalModesToggle globalModesToggle;
    
    //Input
    public GameInputSystem_Actions InputActions;
    public InputLogic inputLogic;
    public InputModeToggle inputModeToggle;
    public AnyClickHandlerRegistry AnyClickHandlerRegistry;
    
    //Registry systems
    public FORTESET_GameObject_Container gameObjectContainer;
    public PausableRegistry PausableRegistry;
    public BuildableRegistry BuildableRegistry;
    public PlayableRegistry PlayableRegistry;
    
    //UI
    public UIScreenSwitcher uiScreenSwitcher;
    
    //Damage system
    public DamageSettings DamageSettings;
    
    //Level system
    public LevelData LevelData;
    public LevelBuilder levelBuilder;
    public LevelBuildSettings levelBuildSettings;
    //VIEW Settings
    public AnimationsSettings animationsSettings;
    //ACTIVE STATES
    
    //GLOBAL
    public bool Global_BuildMode = false;
    public bool Global_MenuMode = false;
    public bool Global_PauseMode = false;
    public bool Global_PlayMode = false;
    //INPUT
    public bool Input_BuildMode = false;
    public bool Input_GlobalMode = false;
    public bool Input_MenuMode = false;
    public bool Input_PlayMode = false;
    //MATERIAL
    public bool Material_BuildMode = false;
    public bool Material_PlayMode = false;
    public bool Material_PauseMode = false;
    //LAUNCHER
    public bool LAUNCHER_BuildMode = false;
    public bool LAUNCHER_PlayMode = false;
    public bool LAUNCHER_PauseMode = false;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        mainCamera = Camera.main;
        InputActions = new GameInputSystem_Actions();
        inputModeToggle.Init();
        
        globalModesToggle = new GlobalModesToggle();
        globalModesToggle.ActivateMenuMode();//TODO refactor later maybe
        
        //Init Level System
        LevelData = new LevelData();
        LevelData.Init();
        levelBuilder.levelData = LevelData;
        levelBuilder.LoadLevelOnScene();
        
        //Init Registry
        PausableRegistry = new PausableRegistry();
        PausableRegistry.AddRange(gameObjectContainer.GetIPausableObjects());
        BuildableRegistry = new BuildableRegistry();
        BuildableRegistry.AddRange(gameObjectContainer.GetIBuildableObjects());
        PlayableRegistry = new PlayableRegistry();
        PlayableRegistry.AddRange(gameObjectContainer.GetIPlayableObjects());
        
        AnyClickHandlerRegistry = new AnyClickHandlerRegistry();
        AnyClickHandlerRegistry.AddRange(gameObjectContainer.GetIAnyClickHanblers());
    }
}