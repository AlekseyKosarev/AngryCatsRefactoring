using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public struct Material_Context
{
    //тут ссылки на компоненты, которые могут использовать состояния
    
    //Physics
    public Rigidbody2D Rb;
    public Transform Transform;
    public Material_Physics Physics;
    
    //VIEW
    public Material_View View;
    
    //INPUT
    public Material_InputHandler InputHandler;
    public InputData InputData;
    
    //также можно указать, откуда включилось состояние - mode (симуляция, строительство)
    
    public MaterialMode Mode;
    public Material_Context(Rigidbody2D rb, Transform transform, Material_View view, Material_InputHandler inputHandler, Material_Physics physics)
    {
        //need
        Rb = rb;
        Transform = transform;
        Physics = physics;
        View = view;
        InputHandler = inputHandler;
        //no need
        Mode = MaterialMode.None;
        InputData = new InputData();
    }
}
public enum MaterialMode
{
    None,
    Simulate,
    Build
}