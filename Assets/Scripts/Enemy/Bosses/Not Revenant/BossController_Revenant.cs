using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Scripts")] public BossBehaviour_Revenant Behaviour;
    public BossMovement_Revenant Movement;
    public BossPhaseAttacks_Revenant PhaseAttacks;
    public BossAnimator_Revenant Animator;

    [Header("Components")] public Rigidbody BossRigidbody;

    [Header("General Stats")] public float Health;
    [Range(25, 100)] public float Phase2HealthRequirement;
    public float MoveSpeed;

    [HideInInspector] public bool InPhase2 = false;
    [HideInInspector] public bool IsActive = false;
    [HideInInspector] public Transform PlayerEntity;

    // PRIVATE DECLARATIONS
    private float _maxHealth;

    private void Start()
    {
        Behaviour = GetComponent<BossBehaviour_Revenant>();
        Movement = GetComponent<BossMovement_Revenant>();
        PhaseAttacks = GetComponent<BossPhaseAttacks_Revenant>();
        Animator = GetComponent<BossAnimator_Revenant>();

        BossRigidbody = GetComponent<Rigidbody>();

        PlayerEntity = GameObject.FindGameObjectWithTag("Player").transform;

        _maxHealth = Health;
    }

    private void Update()
    {
        if(IsActive == true)
        {
            HealthChecks();
        }
    }

    private void HealthChecks()
    {
        // Destorys boss if health is 0 or less
        if(Health <= 0)
        {
            Destroy(transform.gameObject, 2f);
        }

        // Enters the 2 phase if bosses health is under a specific precentage and if it's not in phase 2 already
        if (Health <= (Phase2HealthRequirement / 100) * _maxHealth && InPhase2 == false)
        {
            InPhase2 = true;
        }
    }
}
