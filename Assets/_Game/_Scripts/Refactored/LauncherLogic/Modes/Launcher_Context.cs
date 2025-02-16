public struct Launcher_Context
{
    public Launcher_View View;
    public Launcher_PhysicsController PhysicsController;
    public Launcher_InputHandler InputHandler;
    
    public Launcher_Context(Launcher_View view, Launcher_PhysicsController physicsController, Launcher_InputHandler inputHandler)
    {
        View = view;
        PhysicsController = physicsController;
        InputHandler = inputHandler;
    }
}