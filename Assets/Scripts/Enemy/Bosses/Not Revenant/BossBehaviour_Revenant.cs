using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [HideInInspector] public bool IsChargingUpShot = false;
    [HideInInspector] public bool IsFiringSwarm = false;

    // PRIVATE DECLARATIONS
    private Vector3 _playerPosition;
    private Vector3 _dirToPlayer;
    private float _distanceToPlayer;

    private float _swarmTimer = 0f;
    private float _shotTimer = 0f;
    private float _chargedShotTimer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Controller.IsActive == true)
        {
            GetPlayerInfo();
            UpdateBehaviour();
        }
    }

    private void GetPlayerInfo()
    {
        _dirToPlayer = (transform.position - Controller.PlayerEntity.transform.position).normalized;
        _playerPosition = Controller.PlayerEntity.position;
        _distanceToPlayer = Vector3.Distance(transform.position, _playerPosition);

        Controller.transform.LookAt(_playerPosition);
    }

    private void UpdateBehaviour()
    {
        if (Controller.InPhase2 == true && 
            IsFiringSwarm == false)
        {
            // Only adds to swarm once phase 2 kicks in
            _swarmTimer += Time.deltaTime;

            if(_swarmTimer >= Controller.PhaseAttacks.MissileSwarmDelay)
            {
                _swarmTimer = 0f;
                StartCoroutine(Controller.PhaseAttacks.FireMissileSwarm());
            }
        }

        // Adds to timers

        if(IsChargingUpShot == false ||
            IsFiringSwarm == false)
        {
            _chargedShotTimer += Time.deltaTime;
            _shotTimer += Time.deltaTime;
        }

        if (_distanceToPlayer <= Controller.PhaseAttacks.AttackDistancePhase1)
        {
            if((IsFiringSwarm == false ||
            IsChargingUpShot == false)){
                
                //Debug.Log("Player is in range");

                if (_shotTimer > Controller.PhaseAttacks.BasicAttackDelay &&
                    IsFiringSwarm == false)
                {
                    _shotTimer = 0f;
                    Controller.PhaseAttacks.FireProjectile();

                    Debug.Log("Shot the player with basic projectile");
                }

                if (_chargedShotTimer >= Controller.PhaseAttacks.ChargedShotDelay &&
                    IsFiringSwarm == false)
                {
                    _chargedShotTimer = 0f;
                    StartCoroutine(Controller.PhaseAttacks.FireChargedShot());

                    Debug.Log("Charing the shot");
                }
            }
        }
        else
        {
            if( IsFiringSwarm == false)
            {
                if(IsChargingUpShot == false)
                {
                    if (Controller.InPhase2 == true)
                    {
                        // Moves the boss to air positions
                        Controller.Movement.MoveToPosition(Controller.Movement.FindClosestAirPoint(Controller.Movement.AirMovementPositions));

                        Debug.Log("Moving to air position");
                    }
                    else
                    {
                        // Moves the boss to ground positions
                        Controller.Movement.MoveToPosition(Controller.Movement.FindClosestGroundPoint(Controller.Movement.GroundMovementPositions));

                        Debug.Log("Moving to ground position");
                    }
                }
            }
            else
            {
                Controller.Movement.MoveToPosition(Controller.Movement.FindFurthestAirPoint(Controller.Movement.AirMovementPositions));

                Debug.Log("Moving to swarm position");
            }
        }
    }
}
