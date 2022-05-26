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

        int _projectileAmount = 8;
        int _shotProjectiles = 0;

        float _shotDelay = 1f;
        float _shotDelaytimer = 0f;

        bool _shotLeftSide = false;

        while(_shotProjectiles < _projectileAmount)
        {
            _shotDelaytimer += Time.deltaTime;

            Debug.Log("Timer: " + _shotDelaytimer);

            if(_shotDelaytimer >= _shotDelay)
            {
                //Debug.Log("Firing swarm");

                if(_shotLeftSide == false)
                {
                    _shotLeftSide = true;

                    GameObject _swarmProjectile = Instantiate(SwarmProjectile.ProjectilePrefab, SwarmOriginRight.position, Quaternion.identity);

                    _swarmProjectile.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.Damage = SwarmProjectile.Damage;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.ExplosionVFX = SwarmProjectile.ExplosionVFX;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.IsExplosiveType = SwarmProjectile.IsExplosiveType;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.ProjectileSprite = SwarmProjectile.ProjectileSprite;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.Speed = SwarmProjectile.Speed;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.IsTrackingPlayer = SwarmProjectile.IsTrackingPlayer;

                    _shotProjectiles += 1;
                    _shotDelaytimer = 0f;

                    //Debug.Log("Swarm right side");
                }
                else
                {
                    _shotLeftSide = false;

                    GameObject _swarmProjectile = Instantiate(SwarmProjectile.ProjectilePrefab, SwarmOriginLeft.position, Quaternion.identity);

                    _swarmProjectile.GetComponent<ProjectileMovement>().ShotOrigin = ShotOrigin;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.Damage = SwarmProjectile.Damage;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.ExplosionVFX = SwarmProjectile.ExplosionVFX;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.IsExplosiveType = SwarmProjectile.IsExplosiveType;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.ProjectileSprite = SwarmProjectile.ProjectileSprite;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.Speed = SwarmProjectile.Speed;
                    _swarmProjectile.GetComponent<ProjectileController>().Info.IsTrackingPlayer = SwarmProjectile.IsTrackingPlayer;

                    _shotProjectiles += 1;
                    _shotDelaytimer = 0f;

                    //Debug.Log("Swarm left side");
                }
            }

            Debug.Log("Shot Projectiles: " + _shotProjectiles);
        }

        yield return new WaitForSeconds(4f);

        Controller.Behaviour.IsFiringSwarm = false;

        yield return null;
    }
}
