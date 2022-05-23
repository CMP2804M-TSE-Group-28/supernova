using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
    private void Update()
    {
        if (Controller.IsActive == true)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        // Moves the enemy to player position
        Controller.NavAgent.SetDestination(Controller.PlayerEntity.transform.position);

        // Sets nav agent speed
        Controller.NavAgent.speed = Controller.Speed;
    }
}
