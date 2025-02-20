using StateMachine.StateMachineSystems;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Material_Physics))]
[RequireComponent(typeof(Material_View))]
[RequireComponent(typeof(Material_InputHandler))]
public class Material_Base: MonoBehaviour, IPausable, IBuildable, IPlayable
{
    private StateMachine<Material_Context> _states;
    private Material_Context materialData;
    
    //materialData
    private Rigidbody2D rb;
    private Material_Physics physics;
    private Material_View view;
    private Material_InputHandler inputHandler;
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        physics = GetComponent<Material_Physics>();
        view = GetComponent<Material_View>();
        inputHandler = GetComponent<Material_InputHandler>();
        materialData = new Material_Context(rb, transform, view, inputHandler, physics);
    }

    private void Start()
    {
        Init();
        _states = new StateMachineBuilder<Material_Context>()
            .AddState(new Material_PlayMode())
            .AddState(new Material_BuildMode())
            .AddState(new Material_PauseMode())
            .Build();
    }

    private void Update()
    {
        _states.Update(materialData);
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

    public void EnterPlayMode()
    {
        _states.SwitchToState<Material_PlayMode>(materialData);
    }
    
    public void BuildMode_Enable()
    {
        _states.SwitchToState<Material_BuildMode>(materialData);
    }
    public void BuildMode_Disable()
    {
        _states.SetStateActive<Material_BuildMode>(false, materialData);//TODO лучше deactivate all states прокинуть и использовать
    }

    public void PlayMode_Enable()
    {
        _states.SwitchToState<Material_PlayMode>(materialData);
    }

    public void PlayMode_Disable()
    {
        _states.SetStateActive<Material_PlayMode>(false, materialData);//TODO лучше deactivate all states прокинуть и использовать
    }
}