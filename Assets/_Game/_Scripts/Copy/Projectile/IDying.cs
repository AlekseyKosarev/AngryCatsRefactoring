using System;

public interface IDying
{
    public Action DieCallback { get; set; }
    protected internal void Die();// maybe IEnumerator....
}
