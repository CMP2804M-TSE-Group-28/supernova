using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Ranged Related Components")] public Transform ShotOrigin;

    [Header("Ranged Attack Type - NOT IMPLEMENTED YET, ONLY RAYCAST")] public bool IsProjectile;

    public ProjectileInfo Info;

    [Header("Ranged Stats")] public float AttackDistance;

    public float AttackDelay;
    public float AttackDamage;

    //[Range(20, 100)]
    //public float BaseAccuracy;

    [Range(0, 5)]
    public float AccuracySpread;

    // PRIVATE DECLARATIONS

    private float _attackDelayTimer = 0f;
    private float _chargedAttackDelayTimer = 0f;

    private Vector3 _rayShotDirection;
    private RaycastHit _rayHit;

    private float _visibilityGracePeriod;
    private bool _playerCanTakeDamage = false;


    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Checks if the line of sight is blocked
        if (Controller.Rays.PlayerSightBlocked == false)
        {
            _visibilityGracePeriod += Time.deltaTime;
        }
        else
        {
            _visibilityGracePeriod = 0f;
        }

        // Check whether the grace period is over
        if (_visibilityGracePeriod >= 2f)
        {
            // Enables ability for player to take damage
            _playerCanTakeDamage = true;
        }
        else
        {
            _playerCanTakeDamage = false;
        }
    }

    private void CalculateAccuracy()
    {
        // Calculate base spread
        float _xSpread = Random.Range(-AccuracySpread, AccuracySpread);
        float _ySpread = Random.Range(-AccuracySpread, AccuracySpread);

        // SCRAPPED FOR THE TIME BEING - COULD BE REWORKDED LATER IF I RE-GROW MY BRAIN CELLS
        //float _xAccuracy = (BaseAccuracy / 100 - 1f) + _xSpread;
        //float _yAccuracy = (BaseAccuracy / 100 - 1f) + _ySpread;

        // Apply spread to foward transform and a new vector of spread
        _rayShotDirection = Controller.PlayerTarget.position - ShotOrigin.position;

        Vector3 _accuracySpread = new Vector3(_xSpread, _ySpread, 0f);

        _rayShotDirection += _accuracySpread;
    }

    public void RangedAttack()
    {
        // Checks if the enemy can preform a charged attack
        if (Controller.CanChargeRangedAttack == true)
        {
            // Adds time to the timer
            _chargedAttackDelayTimer += Time.deltaTime;
        }

        // Adds time to the base attack timer
        _attackDelayTimer += Time.deltaTime;

        // Checks if the attack timer is more than the set delay
        if(_attackDelayTimer >= AttackDelay)
        {
            // Calls function to calculate accuracy of the shot, then calls the shoot function
            CalculateAccuracy();
            ShootThePlayer_Ray();
        }
    }

    public void ShootThePlayer_Ray()
    {
        // Shoots out the raycast
        if(Physics.Raycast(ShotOrigin.transform.position, _rayShotDirection, out _rayHit, AttackDistance))
        {
            // Checks if the collider has the player tag and whether it can take damage
            if(_rayHit.collider.gameObject.tag == "Player" && _playerCanTakeDamage == true)
            {
                // Take damage from player
                // Debug.Log("Hit the player");
            }

            // Debug the ray
            Debug.DrawRay(ShotOrigin.transform.position, _rayShotDirection, Color.blue, 0.5f);

            // Reset the delaytimer
            _attackDelayTimer = 0f;
        }
    }
}
