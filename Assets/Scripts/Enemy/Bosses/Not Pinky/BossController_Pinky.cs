using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController_Pinky : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Scripts ")] public BossBehaviour_Pinky Behaviour;
    public BossMovement_Pinky Movement;
    public BossRays_Pinky Rays;
    public BossPhaseAttacks_Pinky PhaseAttacks;

    [Header("Components")] public NavMeshAgent BossNavagent;
    public Rigidbody BossRigidbody;

    [Header("General Stats")] public float Health;
    [Range(25, 100)] public float Phase2HealthRequirement;

    [HideInInspector] public bool InPhase2 = false;
    public bool IsActive = false;
    [HideInInspector] public Transform PlayerEntity;

    // PRIVATE DECLARATIONS
    private float _maxHealth;
    [SerializeField] private GameObject arenaSwitch;

    // Start is called before the first frame update
    private void Start()
    {
        Behaviour = GetComponent<BossBehaviour_Pinky>();
        Movement = GetComponent<BossMovement_Pinky>();
        Rays = GetComponent<BossRays_Pinky>();
        PhaseAttacks = GetComponent<BossPhaseAttacks_Pinky>();

        BossNavagent = GetComponent<NavMeshAgent>();
        BossRigidbody = GetComponent<Rigidbody>();

        PlayerEntity = GameObject.Find("PlayerTarget").transform;
        _maxHealth = Health;
    }

    private void Update()
    {
        if (IsActive == true)
        {
            HealthChecks();
        }
    }

    private void HealthChecks()
    {
        // Destorys boss if health is 0 or less
        if (Health <= 0)
        {
            arenaSwitch.SetActive(true);
            Destroy(transform.gameObject, 2f);
        }

        // Enters the 2 phase if bosses health is under a specific precentage and if it's not in phase 2 already
        if (Health <= (Phase2HealthRequirement / 100) * _maxHealth && InPhase2 == false)
        {
            InPhase2 = true;
        }
    }
}
