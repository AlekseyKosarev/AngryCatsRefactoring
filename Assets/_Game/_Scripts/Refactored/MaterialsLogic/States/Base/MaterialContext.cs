using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public struct MaterialContext
{
    //тут ссылки на компоненты, которые могут использовать состояния
    
    public Rigidbody2D Rb;
    public Transform Transform;
    
    //VIEW
    public MaterialView View;
    
    //INPUT
    public InputData InputData;
    
    //также можно указать, откуда включилось состояние - mode (симуляция, строительство)
    
    public MaterialMode Mode;
    public MaterialContext(Rigidbody2D rb, Transform transform, MaterialView view)
    {
        //need
        Rb = rb;
        Transform = transform;
        View = view;
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