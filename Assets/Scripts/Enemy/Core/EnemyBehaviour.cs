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

    // PRIVATE DECLARATIONS
    private float _distanceToPlayer;

    private bool _isAttackingMelee;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        FindDistanceToPlayer();
        LookAtPlayer();
    }

    public Vector3 FindDirectionToPlayer()
    {
        Vector3 _dirToPlayer = (transform.position - Controller.PlayerEntity.transform.position).normalized;
        return _dirToPlayer;
    }

    private void LookAtPlayer()
    {
        // Looks at the player's position
        Vector3 _playerPos = new Vector3(Controller.PlayerEntity.transform.position.x,
            0f,
            Controller.PlayerEntity.transform.position.z);

        this.transform.LookAt(_playerPos);

        if (Controller.IsRanged == true)
        {
            Vector3 _playerHeadPos = new Vector3(0f,
                Controller.PlayerTarget.position.y,
                0f);

            Controller.Ranged.ShotOrigin.transform.LookAt(_playerHeadPos);
        }
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
                    // Debug.Log("Calling Melee Charge");
                    Controller.MeleeCharge.ExecuteChargeAttack();
                }
                else
                {
                    // Lets the nav agent move again
                    Controller.NavAgent.isStopped = false;
                }

                if (Controller.CanChargeMeleeAttack)
                {
                }

                if (_distanceToPlayer <= Controller.Melee.AttackDistance)
                {
                    // Debug.Log("Is in melee distance");
                    // Stops the nav agent and sets attacking melee to true
                    Controller.NavAgent.isStopped = true;
                    _isAttackingMelee = true;

                    // Call a melee attack function
                    Controller.Melee.MeleeAttack();
                }
                else
                {
                    // Lets the nav agent move again, sets melee attack to false
                    Controller.NavAgent.isStopped = false;
                    _isAttackingMelee = false;
                }

                if (_distanceToPlayer <= Controller.Melee.AttackDistance &&
                    Controller.Rays.PlayerSightBlocked == false)
                {
                    // Stops the nav agent and sets attacking melee to true
                    Controller.NavAgent.isStopped = true;
                    _isAttackingMelee = true;

                    // Call a melee attack function
                    Controller.Melee.MeleeAttack();
                    // Debug.Log("Is in melee distance");
                }
                else
                {
                    // Lets the nav agent move again, sets melee attack to false
                    Controller.NavAgent.isStopped = false;
                    _isAttackingMelee = false;
                }
            }

            // Checks if the enemy can shoot
            if (Controller.IsRanged)
            {
                // Checks the distance, whether a melee attack is happening and if line of sight isn't broken
                if (_distanceToPlayer <= Controller.Ranged.AttackDistance &&
                    _isAttackingMelee == false &&
                    Controller.Rays.PlayerSightBlocked == false)
                {
                    // Stops the nav agent
                    Controller.NavAgent.isStopped = true;

                    // Call a ranged attack function
                    Controller.Ranged.RangedAttack();
                    // Debug.Log("Is in ranged distance");
                }
                else
                {
                    // Checks that melee attack is false
                    if (_isAttackingMelee == false)
                    {
                        // Lets the nav agent move again
                        Controller.NavAgent.isStopped = false;
                    }
                }
            }
        }
    }
}