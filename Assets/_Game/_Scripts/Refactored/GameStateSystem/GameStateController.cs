using UnityEngine;

public class GameStatesToggle: MonoBehaviour//TODO тот скрипт пока удален, доделать на стейт машине
{
    public BaseMaterial materialPrefab;//pausable
    
    // private StateMachine<EmptyContext> _statesGame; // эти состояния можно охарактеризовать как состояния игры и что важно МЕНЮ - то есть экран
    // // то есть пауза, строительство, игра - это экраны меню
    // // так же могут быть такие - всплывающие окна, которые могут быть только в определенном режиме ИЛИ наоборот в любом режиме
    // // например предупреждение о выходе из текущего режима в другой режим 
    // private void Init()
    // {
    //     _statesGame = new StateMachineBuilder<EmptyContext>()
    //         .AddState(new PauseState<EmptyContext>())
    //         .AddState(new BuildState<EmptyContext>())
    //         .AddState(new PlayState<EmptyContext>())
    //         .Build();
    // }
    private void Update()
    {
        //switch pause|game - space
        if (Input.GetKeyDown(KeyCode.P))
        {
            materialPrefab.Pause();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            materialPrefab.Resume();
        }

        //build mode
        if (Input.GetKeyDown(KeyCode.B))
        {
            materialPrefab.EnterBuildMode();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            materialPrefab.ExitBuildMode();
        }
    }
    // public void TogglePauseMode()
    // {
    //     materialPrefab.PauseModeToggle();
    // }
    
    
}