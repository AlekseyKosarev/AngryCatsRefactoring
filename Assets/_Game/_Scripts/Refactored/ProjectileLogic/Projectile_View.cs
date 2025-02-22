using System;
using UnityEngine;

public class Projectile_View: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite ProjectileSpriteDef;
    public Sprite ProjectileSpriteDead;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetProjectileSpriteDef() => spriteRenderer.sprite = ProjectileSpriteDef;
    public void SetProjectileSpriteDead() => spriteRenderer.sprite = ProjectileSpriteDead;
}