using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Entity Scripts")] public EnemyBehaviour Behaviour;
    public EnemyMovement Movement;
    public EnemyRays Rays;
    public EnemyAnimator Animator;
    public EnemyMelee Melee;
    public EnemyMeleeCharge MeleeCharge;
    public EnemyMeleeChargedAttack MeleeChargedAttack;
    public EnemyRanged Ranged;
    public EnemyRangedChargedAttack RangedChargedAttack;

    // Components
    [Header("Components")] public NavMeshAgent NavAgent;
    public Rigidbody AIRigidbody;
    public GameObject HealthDrop;
    public GameObject AmmoDrop;

    [Header("Layer Masks")] public LayerMask PlayerMask;

    // AI General Stats
    [Header("General Stats")] public float Health;
    public float Speed;
    public float PickupDropChance;

    // Hidden public declarations
    [HideInInspector] public GameObject PlayerEntity;
    [HideInInspector] public Transform PlayerTarget;
     public bool IsActive = true;
    [HideInInspector] public bool IsRanged = false;
    [HideInInspector] public bool IsMelee = false;
    [HideInInspector] public bool CanChargeRangedAttack = false;
    [HideInInspector] public bool CanChargeMeleeAttack = false;
    [HideInInspector] public bool CanMeleeCharge = false;
    [HideInInspector] public Vector3 PlayerLookTarget;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        // Core scripts
        Behaviour = GetComponent<EnemyBehaviour>();
        Movement = GetComponent<EnemyMovement>();
        Rays = GetComponent<EnemyRays>();
        Animator = GetComponent<EnemyAnimator>();

        // Role script - Melee or Ranged is required for the AI to do anything
        Melee = GetComponent<EnemyMelee>();
        Ranged = GetComponent<EnemyRanged>();

        // Extra scripts - These can be added to spice up the enemy behaviour
        MeleeCharge = GetComponent<EnemyMeleeCharge>();
        MeleeChargedAttack = GetComponent<EnemyMeleeChargedAttack>();

        RangedChargedAttack = GetComponent<EnemyRangedChargedAttack>();

        // Get components
        NavAgent = GetComponent<NavMeshAgent>();
        AIRigidbody = GetComponent<Rigidbody>();
        

        if(PlayerEntity == null)
        {
            PlayerEntity = GameObject.FindGameObjectWithTag("Player");
        }

        if(PlayerTarget == null)
        {
            PlayerTarget = GameObject.Find("PlayerTarget").transform;
        }

        // Sets appropriate bools to true if the script exists
        if (Melee != null)
        {
            IsMelee = true;
        }

        if(Ranged != null)
        {
            IsRanged = true;
        }

        if (MeleeCharge != null)
        {
            CanMeleeCharge = true;
        }

        if(MeleeChargedAttack != null)
        {
            CanChargeMeleeAttack = true;
        }

        if(RangedChargedAttack != null)
        {
            CanChargeRangedAttack = true;
        }
    }

    // Finds the players position
    private void Update()
    {
        PlayerLookTarget = new Vector3(PlayerTarget.position.x,
            transform.position.y,
            PlayerTarget.position.z);

        if(Health <= 0)
        {
            float _random = Random.Range(0f, 100f);
            float _type = Random.Range(0f, 1f);

            if(PickupDropChance <= _random)
            {
                if(_type <= 0.5f)
                {
                    GameObject _healthPickup = Instantiate(HealthDrop, transform.position, Quaternion.identity);
                    Debug.Log("Health picked up");
                }
                else
                {
                    GameObject _ammoPickup = Instantiate(AmmoDrop, transform.position, Quaternion.identity);
                    Debug.Log("Ammo picked up");
                }
            }

            // play death sound
            // call OpenDoor on door to end of game - second boss
            Destroy(this.gameObject);
        }
    }
}
