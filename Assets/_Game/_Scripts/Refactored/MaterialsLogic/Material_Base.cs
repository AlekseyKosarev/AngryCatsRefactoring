using System;
using StateMachine.StateMachineSystems;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Material_Physics))]
[RequireComponent(typeof(Material_View))]
[RequireComponent(typeof(Material_InputHandler))]
[RequireComponent(typeof(Material_DamageHandler))]
public class Material_Base: MonoBehaviour, IPausable, IBuildable, IPlayable
{
    
    [SerializeField] public ItemData itemData;
    //state machine 
    private StateMachine<Material_Context> _states;
    private Material_Context materialData;
    
    //materialData
    private Rigidbody2D rb;
    private Material_Physics physics;
    private Material_View view;
    private Material_InputHandler inputHandler;
    private Material_DamageHandler damageHandler;
    
    private bool _isInit = false;
    public void Init()
    {
        if(_isInit) return;
        
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<Material_Physics>();
        view = GetComponent<Material_View>();
        inputHandler = GetComponent<Material_InputHandler>();
        damageHandler = GetComponent<Material_DamageHandler>();
        
        materialData = new Material_Context(this, rb, transform, view, inputHandler, physics, damageHandler);
        
        Root.Instance.LevelData.AddObjectOnLevel(gameObject);
        
        _states = new StateMachineBuilder<Material_Context>()
            .AddState(new Material_PlayMode())
            .AddState(new Material_BuildMode())
            .AddState(new Material_PauseMode())
            .Build();
        
        materialData.Physics.SaveTransform();
        _isInit = true;
    }

    // private void Start()
    // {
    //     Init();
    //     Debug.Log("Start Tile");
    // }
    public void SpawnFromBuilder()
    {
        Init();
        materialData.Physics.Init();
        materialData.Physics.SaveTransform();
        BuildMode_Enable();
    }

    private void Update()
    {
        if (_isInit == false) return;
        _states.Update(materialData);
    }
    
    public void RestartData()
    {
        materialData.Physics.SetDefaultPhysics();
        materialData.Physics.LoadTransform();
        materialData.DamageHandler.SetDefaultHp();
        materialData.View.SetDefaultView();
    }

    public void SetInputData(InputData inputData)
    {
        InputData input = inputData;
        materialData.InputData = input;
    }
    public void PauseMode_Enable()
    {
        _states.SaveCurrentStatesToPrevious();
        _states.SwitchToState<Material_PauseMode>(materialData);
    }
    public void PauseMode_Disable()
    {
        _states.SetStateActive<Material_PauseMode>(false, materialData);
        _states.ActivatePreviousStates(materialData);
    }
    
    public void BuildMode_Enable()
    {
        RestartData();
        _states.SwitchToState<Material_BuildMode>(materialData);
    }
    public void BuildMode_Disable()
    {
        // _states.DeactivateAllStates(materialData);
        _states.SetStateActive<Material_BuildMode>(false, materialData);//TODO лучше deactivate all states прокинуть и использовать
    }

    public void PlayMode_Enable()
    {
        RestartData();
        _states.SwitchToState<Material_PlayMode>(materialData);
    }

    public void PlayMode_Disable()
    {
        // _states.DeactivateAllStates(materialData);
        _states.SetStateActive<Material_PlayMode>(false, materialData);//TODO лучше deactivate all states прокинуть и использовать
    }
    
    public bool CheckConflict()//TODO это часто вызывается, но пока не важно
    {
        var check = Root.Instance.zoneController.ContainsCollider(ZoneType.BuildZone, physics.GetComponent<Collider2D>());
        var contacts = physics.CheckContactsWithDepth(0.15f);
        
        // Debug.Log(check);
        return  !check || contacts;
    }
}