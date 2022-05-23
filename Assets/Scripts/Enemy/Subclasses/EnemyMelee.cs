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

    private float _attackTimer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    public void MeleeAttack()
    {
        // Adds real time to _attackTimer
        _attackTimer += Time.deltaTime;

        // Checks whether the timer exceeds or is equal to attack delay
        if(_attackTimer >= AttackDelay)
        {
            // Reset the timer
            _attackTimer = 0f;

            // Call function to attack the player - deduct health
            MeleeThePlayer();
        }
    }

    public void MeleeThePlayer()
    {
        // Preforms a charged melee attack
        if(Controller.CanChargeMeleeAttack == true)
        {
            if(Controller.MeleeChargedAttack.AttackIsCharged == true)
            {
                // Resets the melee charged attack
                Controller.MeleeChargedAttack.ChargeAttackExecuted();

                // Scales the damage according to the charge
                AttackDamage *= Controller.MeleeChargedAttack.ChargedDamageMultiplier;

                // Take players health
                Debug.Log("Hit a charged melee attack");
            }
        }
        // Preforms a default melee attack
        else
        {
            Debug.Log("Hit a normal melee attack");
            // Take players Health
        }

        // Needs player health function before this can be implemented
    }
}
