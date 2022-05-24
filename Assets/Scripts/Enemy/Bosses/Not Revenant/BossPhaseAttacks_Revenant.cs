using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAttacks_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("General Stats")] public float AttackDistancePhase1;
    public float AttackDistancePhase2;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
