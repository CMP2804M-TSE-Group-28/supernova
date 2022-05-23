using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeChargedAttack : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    public float ChargeDelayBetweenCharges;
    public float ChargedChargeUpTime;
    [Range(1f, 3f)] public float ChargedDamageMultiplier = 1f;
    [HideInInspector] public bool AttackIsCharged = false;
     public bool ChargingUpAttack = false;

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
        if (_attackCanBeCharged == true)
        {
            // Adds to the timer
            _chargedAttackTimer += Time.deltaTime;

            if (_chargedAttackTimer >= ChargeDelayBetweenCharges)
            {
                AttackIsCharged = true;
                _attackCanBeCharged = false;
            }
        }

        if (AttackIsCharged == true)
        {
            // Calls the coroutine once all conditons are met
            StartCoroutine(ChargeUpMeleeAttack());
            _chargedAttackTimer = 0f;

            //Debug.Log("Called the Coroutine");
        }
    }

    public void ChargeAttackExecuted()
    {
        AttackIsCharged = false;
        _attackCanBeCharged = true;
        _chargedAttackTimer = 0f;
        Controller.Behaviour.MeleeChargedTimer = 0f;

        //Debug.Log("Charged Attack Done");
    }

    public IEnumerator SetCurrentTime(float CurrentTime)
    {
        // Adds to the time
        _chargedAttackTimer = CurrentTime + 1f;

        // Calls the function to call the coroutine
        CallChargedAttack();

        yield return null;
    }

    private IEnumerator ChargeUpMeleeAttack()
    {
        //Debug.Log("Charging up my melee attack");
        // Stops the navAgent
        ChargingUpAttack = true;
        Controller.NavAgent.isStopped = true;

        // Waits for the time
        yield return new WaitForSecondsRealtime(ChargedChargeUpTime);

        // Resets all variables to allow movement
        ChargingUpAttack = false;
        Controller.NavAgent.isStopped = false;
        AttackIsCharged = true;
        _attackCanBeCharged = false;
    }
}
