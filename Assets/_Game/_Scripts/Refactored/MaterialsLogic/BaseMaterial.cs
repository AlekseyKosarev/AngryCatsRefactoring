using _Project.System.StateMachine.StateMachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseMaterial: MonoBehaviour, IPausable
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
            .AddState(new SimulateMode())
            .AddState(new BuildMode())
            .AddState(new PauseMode())
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

    public void Pause()
    {
        _states.SwitchToState<PauseMode>(materialData);
    }

    public void Resume()
    {
        _states.SwitchToState<SimulateMode>(materialData);
    }
    
    //TODO build mode logic
    public void EnterBuildMode()
    {
        _states.SwitchToState<BuildMode>(materialData);
    }
    public void ExitBuildMode()
    {
        _states.SetStateActive<BuildMode>(false, materialData);//TODO лучше deactivate all states прокинуть и использовать
    }
}