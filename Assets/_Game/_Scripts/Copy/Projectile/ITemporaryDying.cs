using System;
using System.Collections;
using UnityEngine;

public interface ITemporaryDying: IDying
{
    public float TimeLife { get; set; }
    public Action TimeEnded { get; set; }
    protected internal Coroutine Counter { get; set; }
    protected internal IEnumerator CountTimeLife();
    protected internal void StartTimer();
}
