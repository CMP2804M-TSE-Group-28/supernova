using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAttacks_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("General Stats")] public float AttackDistancePhase1;
    public float AttackDistancePhase2;

    [Header("Projectile Stats")] public ProjectileInfoEnemy ProjectileInfo;

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

    // Update is called once per frame
    private void Update()
    {

    }

    public void FireProjectile()
    {

    }

    public IEnumerator FireChargedShot()
    {
        yield return null;
    }
    
    public IEnumerator FireMissileSwarm()
    {
        yield return null;
    }
}
