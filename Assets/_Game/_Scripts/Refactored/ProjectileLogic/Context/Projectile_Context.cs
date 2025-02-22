using System;
using UnityEngine;

public struct Projectile_Context
{
    //Physics
    public Rigidbody2D Rb;
    public Transform Transform;
    public Projectile_Physics Physics;

    //Launch
    public Projectile_Launch LaunchHandler;
    public bool IsLaunched;

    public Projectile_PlayMode PlayModeStates{ get; set; }
    //VIEW
    public Projectile_View View;
    
    //INPUT
    public Projectile_InputHandler InputHandler;
    public InputData InputData;

    public Projectile_Context(Rigidbody2D rb, Transform transform, Projectile_View view,
        Projectile_InputHandler inputHandler, Projectile_Physics physics, Projectile_Launch launchHandler)
    {
        Rb = rb;
        Transform = transform;
        View = view;
        InputHandler = inputHandler;
        Physics = physics;
        LaunchHandler = launchHandler;
        //no need
        InputData = new InputData();
        IsLaunched = false;
        PlayModeStates = null;
    }
}