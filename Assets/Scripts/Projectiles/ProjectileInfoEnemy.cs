using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileInfoEnemy
{
    [Header("Projectile Components")] public GameObject ProjectilePrefab;
    public Sprite ProjectileSprite;

    [Header("Explosion VFX - Only if it's a explosive")] public GameObject ExplosionVFX;

    [Header("Projectile Stats")] public float Speed;
    public int Damage;
    public float DropRate;

    [Header("Projectile Type")] public bool IsExplosiveType;
}
