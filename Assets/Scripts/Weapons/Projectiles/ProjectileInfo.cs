using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileInfo
{
    [Header("Projectile Components")]
    public GameObject ProjectilePrefab;
    public GameObject ProjectileSprite;

    [Header("Projectile Stats")]
    public float Speed;
    public float Damage;
    public float DropRate;

    [Header("Projectile Type")]
    public bool IsExplosiveType;
    public bool IsLaserType;
}
