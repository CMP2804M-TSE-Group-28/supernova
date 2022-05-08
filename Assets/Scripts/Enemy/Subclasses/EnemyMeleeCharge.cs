using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeCharge : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Charge Stats")] public float ChargeDistance;
    public float ChargeDamage;
    public float ChargeTravelForce;
    public float ChargeDelay;
    [Range(0.5f, 1f)] public float WaitAfterAnimation;

    // PRIVATE DECLARATIONS
    private Vector3 _dirToPlayer;

    private float _settingUpChargeTimer = 0f;
    private float _chargeTimer = 0f;

    private bool _finishedChargeAttack = false;
    private bool _finishedChargeSetup = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();

        _settingUpChargeTimer = 0f;
        _chargeTimer = 0f;
        _finishedChargeAttack = true;
    }

    public void ExecuteChargeAttack()
    {
        _chargeTimer += Time.deltaTime;

        if(_finishedChargeAttack == true && _chargeTimer >= ChargeDelay)
        {
            _chargeTimer = 0f;
            StartCoroutine(PreformChargeAttack());
        }
    }

    private IEnumerator PreformChargeAttack()
    {
        Debug.Log("Preform called");
        _finishedChargeAttack = false;

        Controller.NavAgent.isStopped = true;

        // Find direction to player
        _dirToPlayer = Controller.Behaviour.FindDirectionToPlayer();

        while (_finishedChargeSetup == false)
        {
            Debug.Log("Setting Up...");
            // Execute the 'setting up charge' animation
            _settingUpChargeTimer += Time.deltaTime;

            Controller.NavAgent.isStopped = true;

            if (_settingUpChargeTimer >= WaitAfterAnimation)
            {
                _finishedChargeSetup = true;
                _settingUpChargeTimer = 0f;
                Debug.Log("Setup finished");
            }
        }

        // Preform the charge attack
        Controller.AIRigidbody.AddForce(-_dirToPlayer * (ChargeTravelForce) * 10);

        _finishedChargeAttack = true;

        Debug.Log("Finished Charge");

        yield return new WaitForSecondsRealtime(1f);

        Controller.NavAgent.isStopped = false;
    }
}
