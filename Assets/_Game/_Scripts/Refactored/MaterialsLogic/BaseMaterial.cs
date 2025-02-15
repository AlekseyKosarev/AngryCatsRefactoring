using StateMachine.StateMachineSystems;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseMaterial: MonoBehaviour, IPausable, IBuildable, IPlayable
{
    private StateMachine<MaterialContext> _states;
    private MaterialContext materialData;
    
    //materialData
    private Rigidbody2D rb;
    private MaterialView view;
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<MaterialView>();
        materialData = new MaterialContext(rb, transform, view);
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        _states = new StateMachineBuilder<MaterialContext>()
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
    
    //TODO build mode logic
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