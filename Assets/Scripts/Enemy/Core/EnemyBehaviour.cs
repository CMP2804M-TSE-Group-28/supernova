using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Player Target")] public Transform PlayerTarget;

    [HideInInspector] public Vector3 DirectionToPlayer;

    public float RangedChargedTimer = 0f;
    [HideInInspector] public float MeleeChargedTimer = 0f;

    // PRIVATE DECLARATIONS
    private float _distanceToPlayer;
    private bool _isAttackingMelee = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Calls functions only is the agent is active
        if(Controller.IsActive == true)
        {
            FindDistanceToPlayer();
        }

        LookAtPlayer();
    }

    public Vector3 FindDirectionToPlayer()
    {
        // Finds the direction to the player
        Vector3 _dirToPlayer = (transform.position - Controller.PlayerEntity.transform.position).normalized;
        return _dirToPlayer;
    }

    private void LookAtPlayer()
    {
        // Always looks at the player
        Controller.transform.LookAt(Controller.PlayerLookTarget);
    }

    private void FindDistanceToPlayer()
    {
        // Find the distance to player
        _distanceToPlayer = Vector3.Distance(this.transform.position,
            Controller.PlayerEntity.transform.position);

        // Checks if the enemy can melee
        if (Controller.IsMelee)
        {
            // Checks the distance, whether a melee attack is happening and if line of sight isn't broken

            if (Controller.Rays.PlayerSightBlocked == false)
            {
                // Checks if the enemy can do melee charges and whether it's in good range 
                if (Controller.CanMeleeCharge &&
                    _distanceToPlayer > Controller.Melee.AttackDistance &&
                    _distanceToPlayer <= Controller.MeleeCharge.ChargeDistance)
                {
                    // Calls the melee charge function
                    Debug.Log("Calling Melee Charge");
                    Controller.MeleeCharge.ExecuteChargeAttack();
                }
                else
                {
                    if(Controller.CanChargeMeleeAttack == true)
                    {
                        if(Controller.MeleeChargedAttack.ChargingUpAttack == false)
                        {
                            // Lets the nav agent move again
                            Controller.NavAgent.isStopped = false;
                        }
                        else
                        {
                            Controller.NavAgent.isStopped = true;
                        }
                    }
                    else
                    {
                        Controller.NavAgent.isStopped = false;
                    }
                }

                if(Controller.CanChargeMeleeAttack == true)
                {
                    // Adds time to the melee charge timer
                    MeleeChargedTimer += Time.deltaTime;

                    if(MeleeChargedTimer >= Controller.MeleeChargedAttack.ChargeDelayBetweenCharges)
                    {
                        if(Controller.MeleeChargedAttack.AttackIsCharged == false)
                        {
                            StartCoroutine(Controller.MeleeChargedAttack.SetCurrentTime(MeleeChargedTimer));
                            MeleeChargedTimer = 0f;

                            //Debug.Log("I have called to melee coroutine!");
                        }
                    }

                    //Debug.Log("I have begun charging my melee charged attack!");
                }

                if (_distanceToPlayer <= Controller.Melee.AttackDistance &&
                    Controller.Rays.PlayerSightBlocked == false)
                {
                    // Stops the nav agent and sets attacking melee to true
                    Controller.NavAgent.isStopped = true;
                    _isAttackingMelee = true;

                    // Call a melee attack function
                    Controller.Melee.MeleeAttack();
                    Debug.Log("Is in melee distance");

                }
                else
                {
                    if(Controller.CanChargeMeleeAttack == true) {

                        if(Controller.MeleeChargedAttack.ChargingUpAttack == false)
                        {
                            // Lets the nav agent move again, sets melee attack to false
                            Controller.NavAgent.isStopped = false;
                            _isAttackingMelee = false;
                        }
                        else
                        {
                            Controller.NavAgent.isStopped = true;
                        }
                    }
                    else
                    {
                        Controller.NavAgent.isStopped = false;
                    }
                }
            }
        }

        // Checks if the enemy can shoot
        if (Controller.IsRanged)
        {
            if (_isAttackingMelee == false &&
                Controller.Rays.PlayerSightBlocked == false &&
                Controller.CanChargeRangedAttack == true)
            {
                // Adds to the timer
                RangedChargedTimer += Time.deltaTime;

                // Checks if the ranged timer is over the delay between shots
                if (RangedChargedTimer >= Controller.RangedChargedAttack.ChargedShotDelayBetweenShots)
                {
                    // Sets the current time to the current timer
                    // Resets the timer
                    StartCoroutine(Controller.RangedChargedAttack.SetCurrentTime(RangedChargedTimer));
                    RangedChargedTimer = 0f;

                    //Debug.Log("I have called to ranged charged coroutine to set current time");
                }

                //Debug.Log("I Have begun charging my ranged charged attack!");
            }


            // Checks the distance, whether a melee attack is happening and if line of sight isn't broken
            if (_distanceToPlayer <= Controller.Ranged.AttackDistance &&
                _isAttackingMelee == false &&
                Controller.Rays.PlayerSightBlocked == false)
            {

                if(Controller.CanChargeRangedAttack == false)
                {
                    // Stops the nav agent
                    Controller.NavAgent.isStopped = true;

                    // Call a ranged attack function
                    Controller.Ranged.RangedAttack();
                    //Debug.Log("Is in ranged distance");
                }
            }
            else
            {
                // Checks that melee attack is false
                if (_isAttackingMelee == false)
                {
                    if(Controller.CanChargeRangedAttack == true)
                    {
                        if(Controller.RangedChargedAttack.PreformingChargeAttack == false)
                        {
                            // Lets the nav agent move again
                            Controller.NavAgent.isStopped = false;
                        }
                        else
                        {
                            Controller.NavAgent.isStopped = true;
                        }
                    }
                    else
                    {
                        Controller.NavAgent.isStopped = false;
                    }
                }
                else
                {
                    Controller.NavAgent.isStopped = true;
                }
            }
        }
    }
}
