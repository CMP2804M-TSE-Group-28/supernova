using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Entity Scripts")]
    public EnemyBehaviour Behaviour;
    public EnemyMovement Movement;
    public EnemyRays Rays;
    public EnemyAnimator Animator;
    public EnemyMelee Melee;
    public EnemyMeleeCharge MeleeCharge;
    public EnemyMeleeChargedAttack MeleeChargedAttack;
    public EnemyRanged Ranged;
    public EnemyRangedChargedAttack RangedChargedAttack;


    // Components
    [Header("Components")]
    public NavMeshAgent NavAgent;

    [Header("Layer Masks")]
    public LayerMask PlayerMask;

    // Hidden public declarations
    [HideInInspector]
    public GameObject PlayerEntity;

    [HideInInspector]
    public Transform PlayerTarget;

    [HideInInspector]
    public bool IsRanged = false;

    [HideInInspector]
    public bool IsMelee = false;

    [HideInInspector]
    public bool CanChargeRangedAttack = false;

    [HideInInspector]
    public bool CanChargeMeleeAttack = false;

    [HideInInspector]
    public bool CanMeleeCharge = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        // Core scripts
        Behaviour = this.GetComponent<EnemyBehaviour>();
        Movement = this.GetComponent<EnemyMovement>();
        Rays = this.GetComponent<EnemyRays>();
        Animator = this.GetComponent<EnemyAnimator>();

        // Role script - Melee or Ranged is required for the AI to do anything
        Melee = this.GetComponent<EnemyMelee>();
        Ranged = this.GetComponent<EnemyRanged>();

        // Extra scripts - These can be added to spice up the enemy behaviour
        MeleeCharge = this.GetComponent<EnemyMeleeCharge>();
        MeleeChargedAttack = this.GetComponent<EnemyMeleeChargedAttack>();

        RangedChargedAttack = this.GetComponent<EnemyRangedChargedAttack>();

        // Get components
        NavAgent = this.GetComponent<NavMeshAgent>();

        if(PlayerEntity == null)
        {
            PlayerEntity = GameObject.FindGameObjectWithTag("Player");
        }

        PlayerTarget = GameObject.Find("PlayerTarget").transform;

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
}
