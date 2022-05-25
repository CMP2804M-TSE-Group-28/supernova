using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAttacks_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("Components")] public Transform ShotOrigin;

    [Header("General Stats")] public float AttackDistancePhase1;
    public float AttackDistancePhase2;

    [Header("Projectile Stats")] public ProjectileInfoEnemy BasicProjectile;
    public ProjectileInfoEnemy ChargedProjectile;
    public ProjectileInfoEnemy SwarmProjectile;

    [Header("Phase 1 Attacks")] public float BasicAttackDelay;
    public float ChargedShotDelay;

    [Header("Phase 2 Attacks")] public float MissileSwarmDelay;

    [HideInInspector] public bool IsPreformingSwarmAttack = false;
    [HideInInspector] public bool IsChargingShot = false;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    public void FireProjectile()
    {
        GameObject _basicProjectile = Instantiate(BasicProjectile.ProjectilePrefab, ShotOrigin.position, Quaternion.identity);

        _basicProjectile.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
        _basicProjectile.GetComponent<ProjectileController>().Info.Damage = BasicProjectile.Damage;
        _basicProjectile.GetComponent<ProjectileController>().Info.ExplosionVFX = BasicProjectile.ExplosionVFX;
        _basicProjectile.GetComponent<ProjectileController>().Info.IsExplosiveType = BasicProjectile.IsExplosiveType;
        _basicProjectile.GetComponent<ProjectileController>().ProjectileSprite = BasicProjectile.ProjectileSprite;
        _basicProjectile.GetComponent<ProjectileController>().Info.Speed = BasicProjectile.Speed;
    }

    public IEnumerator FireChargedShot()
    {
        Controller.Behaviour.IsChargingUpShot = true;

        yield return new WaitForSeconds(2f);

        GameObject _chargedProjectile = Instantiate(ChargedProjectile.ProjectilePrefab, ShotOrigin.position, Quaternion.identity);

        _chargedProjectile.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
        _chargedProjectile.GetComponent<ProjectileController>().Info.Damage = ChargedProjectile.Damage;
        _chargedProjectile.GetComponent<ProjectileController>().Info.ExplosionVFX = ChargedProjectile.ExplosionVFX;
        _chargedProjectile.GetComponent<ProjectileController>().Info.IsExplosiveType = ChargedProjectile.IsExplosiveType;
        _chargedProjectile.GetComponent<ProjectileController>().ProjectileSprite = ChargedProjectile.ProjectileSprite;
        _chargedProjectile.GetComponent<ProjectileController>().Info.Speed = ChargedProjectile.Speed;

        Controller.Behaviour.IsChargingUpShot = false;

        yield return null;
    }
    
    public IEnumerator FireMissileSwarm()
    {
        Controller.Behaviour.IsFiringSwarm = true;

        yield return new WaitForSeconds(5f);

        Controller.Behaviour.IsFiringSwarm = false;

        yield return null;
    }
}
