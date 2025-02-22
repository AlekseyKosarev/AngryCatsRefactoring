using UnityEngine;

public struct Launcher_Context
{
    public Launcher_View View;
    public Launcher_Physics Physics;
    public Launcher_InputHandler InputHandler;
    public Launcher_Magazine Magazine;
    public Transform PointOfLaunch;
    public Launcher_Context(Launcher_View view, Launcher_Physics physics, Launcher_InputHandler inputHandler, Launcher_Magazine magazine, Transform pointOfLaunch)
    {
        View = view;
        Physics = physics;
        InputHandler = inputHandler;
        Magazine = magazine;
        PointOfLaunch = pointOfLaunch;
    }
}