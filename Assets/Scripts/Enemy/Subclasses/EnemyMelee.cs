using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Melee Stats")] public float AttackDistance;
    
    public float AttackDelay;
    public float AttackDamage;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    public void MeleeAttack()
    {
        // Needs player health function before this can be implemented
    }

    public void MeleeThePlayer()
    {
        // Needs player health function before this can be implemented
    }
}
