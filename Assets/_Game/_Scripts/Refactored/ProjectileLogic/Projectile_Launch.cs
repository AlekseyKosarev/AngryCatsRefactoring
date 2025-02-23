using System;
using DG.Tweening;
using UnityEngine;

public class Projectile_Launch: MonoBehaviour
{
    public event Action<Vector2, float> OnLaunch;
    public event Action OnRestart;
    public event Action OnReady;
    
    private Vector2 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    public void Launch(Vector2 direction, float force)
    {
        OnLaunch?.Invoke(direction, force);
    }

    public void Restart()//TODO переделать как-нибудь 
    {
        // Debug.Log("Restart Projectile");
        transform.position = defaultPosition;
        
        OnRestart?.Invoke();
        // вернуть снаряд в исходное положение
    }

    public void GoToLauncher(Vector3 position, float duration, Action onComplete = null)
    {
        // Выполняем анимацию прыжка к указанной позиции
        transform.DOJump(position, jumpPower: 1f, numJumps: 1, duration: duration)
            .SetEase(Ease.OutQuad) // Плавное завершение анимации
            .OnComplete(() =>
            {
                // Вызываем калбек, когда анимация завершена
                OnReady?.Invoke();
                onComplete?.Invoke();
            });
    }
}