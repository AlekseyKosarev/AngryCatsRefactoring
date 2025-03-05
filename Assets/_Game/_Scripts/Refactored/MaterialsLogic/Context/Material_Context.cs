using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public struct Material_Context
{
    //тут ссылки на компоненты, которые могут использовать состояния
    public Material_Base MaterialBase;
    //Physics
    public Rigidbody2D Rb;
    public Transform Transform;
    public Material_Physics Physics;
    
    //VIEW
    public Material_View View;
    
    //INPUT
    public Material_InputHandler InputHandler;
    public InputData InputData;
    
    //Damage
    public Material_DamageHandler DamageHandler;
    
    //также можно указать, откуда включилось состояние - mode (симуляция, строительство)
    
    public MaterialMode Mode;
    public Material_Context(Material_Base materialBase, Rigidbody2D rb, Transform transform, Material_View view, Material_InputHandler inputHandler, Material_Physics physics, Material_DamageHandler damageHandler)
    {
        //need
        MaterialBase = materialBase;
        Rb = rb;
        Transform = transform;
        Physics = physics;
        View = view;
        InputHandler = inputHandler;
        DamageHandler = damageHandler;
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