using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedChargedAttack : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    public float ChargedChargeUpTime;
    public float ChargedShotDelayBetweenShots;
    [Range(1f, 3f)] public float ChargedDamageMultiplier = 1f;
    [Range(1f, 3f)] public float ChargedMoveSpeedMultipler = 1f;
    [HideInInspector] public bool AttackIsCharged = false;
    [HideInInspector] public bool PreformingChargeAttack = false;

    private float _chargedAttackTimer = 0f;
    private bool _attackCanBeCharged = true;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    public void CallChargedAttack()
    {
        if(_attackCanBeCharged == true)
        {
            // Adds to timer
            _chargedAttackTimer += Time.deltaTime;

            if(_chargedAttackTimer >= ChargedShotDelayBetweenShots)
            {
                AttackIsCharged = true;
                _attackCanBeCharged = false;
            }
        }

        if(AttackIsCharged == true)
        { 
            // Calls the coroutine
            //Debug.Log("Calling the function to charge my attack");
            StartCoroutine(ChargeUpChargedShot());
            _chargedAttackTimer = 0f;
        }
    }

    public IEnumerator SetCurrentTime(float CurrentTime)
    {
        // Adds to the current time
        _chargedAttackTimer = CurrentTime + 1f;

        // Calls the coroutine
        CallChargedAttack();

        yield return null;
    }

    public void ChargedAttackExecuted()
    {
        // Allows the agent to move again
        PreformingChargeAttack = false;
        _attackCanBeCharged = true;
        AttackIsCharged = false;
        _chargedAttackTimer = 0f;
        Controller.Behaviour.RangedChargedTimer = 0f;

        Controller.NavAgent.isStopped = false;

        //Debug.Log("I completed my charged attack");
    }

    private IEnumerator ChargeUpChargedShot()
    {
        // Stops the nav agent
        //Debug.Log("I'm charging up my attack");
        PreformingChargeAttack = true;
        AttackIsCharged = true;
        _attackCanBeCharged = false;
        _chargedAttackTimer = 0f;

        Controller.NavAgent.isStopped = true;

        // Waits the time
        yield return new WaitForSeconds(ChargedChargeUpTime);

        // Shoots the projectile
        Controller.Ranged.ShootThePlayerProjectile();

        // Reverts back all variables
        ChargedAttackExecuted();
    }
}
