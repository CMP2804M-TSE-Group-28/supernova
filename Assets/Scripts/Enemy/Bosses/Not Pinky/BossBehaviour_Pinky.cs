using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour_Pinky : MonoBehaviour
{
    // PUBLIC DECLARTIONS
    public BossController_Pinky Controller;

    [HideInInspector] public bool IsCharging = false;

    // PRIVATE DECLARATIONS
    private Vector3 _playerPosition;
    private Vector3 _dirToPlayer;
    private float _distanceToPlayer;

    private float _meleeAttackTimer = 0f;
    private float _chargeTimer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Pinky>();
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

        Controller.transform.LookAt(new Vector3(_playerPosition.x,
            transform.position.y,
            _playerPosition.z));
    }

    private void UpdateBehaviour()
    {
        if(Controller.InPhase2 == true &&
            IsCharging == false)
        {
            _chargeTimer += Time.deltaTime;

            if(_chargeTimer >= Controller.PhaseAttacks.ChargeDelay &&
                _distanceToPlayer <= Controller.PhaseAttacks.ChargeRange)
            {
                _chargeTimer = 0f;
                StartCoroutine(Controller.PhaseAttacks.PreformChargeAttack(_dirToPlayer));
            }
        }

        _meleeAttackTimer += Time.deltaTime;

        if(_meleeAttackTimer >= Controller.PhaseAttacks.MeleeDelay &&
            _distanceToPlayer <= Controller.PhaseAttacks.MeleeRange &&
            IsCharging == false)
        {
            _meleeAttackTimer = 0f;
            StartCoroutine(Controller.PhaseAttacks.PreformMeleeAttack());
        }
    }
}
