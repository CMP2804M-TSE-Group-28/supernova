using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAttacks_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("Components")] public Transform ShotOrigin;
    public Transform SwarmOriginLeft;
    public Transform SwarmOriginRight;

    [Header("General Stats")] public float AttackDistancePhase1;
    public float AttackDistancePhase2;

    [Header("Projectile Stats")] public ProjectileInfoEnemy BasicProjectile;
    public ProjectileInfoEnemy ChargedProjectile;
    public ProjectileInfoEnemy SwarmProjectile;

    [Header("Phase 1 Attacks")] public float BasicAttackDelay;
    public float ChargedShotDelay;

    [Header("Phase 2 Attacks")] public float MissileSwarmDelay;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    private void InstantiateSwarmProjecile()
    {
        GameObject _swarmProjectileR = Instantiate(SwarmProjectile.ProjectilePrefab, SwarmOriginRight.position, Quaternion.identity);

        _swarmProjectileR.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.Damage = SwarmProjectile.Damage;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.ExplosionVFX = SwarmProjectile.ExplosionVFX;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.IsExplosiveType = SwarmProjectile.IsExplosiveType;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.ProjectileSprite = SwarmProjectile.ProjectileSprite;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.Speed = SwarmProjectile.Speed;
        _swarmProjectileR.GetComponent<ProjectileController>().Info.IsTrackingPlayer = SwarmProjectile.IsTrackingPlayer;

        GameObject _swarmProjectileL = Instantiate(SwarmProjectile.ProjectilePrefab, SwarmOriginLeft.position, Quaternion.identity);

        _swarmProjectileL.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.Damage = SwarmProjectile.Damage;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.ExplosionVFX = SwarmProjectile.ExplosionVFX;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.IsExplosiveType = SwarmProjectile.IsExplosiveType;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.ProjectileSprite = SwarmProjectile.ProjectileSprite;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.Speed = SwarmProjectile.Speed;
        _swarmProjectileL.GetComponent<ProjectileController>().Info.IsTrackingPlayer = SwarmProjectile.IsTrackingPlayer;
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
        _basicProjectile.GetComponent<ProjectileController>().Info.IsTrackingPlayer = BasicProjectile.IsTrackingPlayer;
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
        _chargedProjectile.GetComponent<ProjectileController>().Info.IsTrackingPlayer = ChargedProjectile.IsTrackingPlayer;

        Controller.Behaviour.IsChargingUpShot = false;

        yield return null;
    }
    
    public IEnumerator FireMissileSwarm()
    {
        Debug.Log("Sending a missile swarm");
        Controller.Behaviour.IsFiringSwarm = true;

        yield return new WaitForSeconds(4f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(0.5f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(0.5f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(0.5f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(0.5f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(0.5f);

        InstantiateSwarmProjecile();
        yield return new WaitForSeconds(2f);

        Controller.Behaviour.IsFiringSwarm = false;

        yield return null;
    }
}
