using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Projectile_View: ViewBase
{
    public Sprite ProjectileSpriteDef;
    public Sprite ProjectileSpriteDead;
    private Tween deadAnim;

    public override void Init()
    {
        base.Init();
        InitComplete();
    }

    public void SetProjectileSpriteDef() => SpriteRenderer.sprite = ProjectileSpriteDef;
    public void SetProjectileSpriteDead() => SpriteRenderer.sprite = ProjectileSpriteDead;

    public void DeadAnimation()
    {
        deadAnim = SpriteRenderer.DOFade(0f, 0.5f * AnimationsSettings.multiplySpeedAnimations);
    }
    public void ReviveAnimation()
    {
        deadAnim = SpriteRenderer.DOFade(1f, 0.5f * AnimationsSettings.multiplySpeedAnimations);
    }

    public void ResumeTweenAnimations()
    {
        deadAnim.Play();
    }
    public void PauseTweenAnimations()
    {
        deadAnim.Pause();
    }
    
}