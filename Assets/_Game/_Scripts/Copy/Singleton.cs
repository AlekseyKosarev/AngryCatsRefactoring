using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;
    
    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("DESTROY SINGLETON - " + Singleton<T>.Instance.gameObject);
            Destroy(Singleton<T>.Instance.gameObject);
        }
        Instance = (T)this;
    }
}