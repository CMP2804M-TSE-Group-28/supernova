using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeChargedAttack : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
