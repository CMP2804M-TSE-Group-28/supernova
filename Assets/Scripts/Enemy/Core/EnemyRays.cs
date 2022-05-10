using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRays : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Rays")] public Transform HeadRay;

    [Header("Layer Masks")] public LayerMask PlayerMask;

    [HideInInspector] public bool PlayerSightBlocked;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckLineOfSight(Controller.PlayerEntity);
    }

    private void CheckLineOfSight(GameObject PlayerPostion)
    {
        // Check whether any layer blocks line to player - Head to Head contact
        PlayerSightBlocked = Physics.Linecast(HeadRay.position,
            Controller.PlayerTarget.position,
            PlayerMask);


        // Debug lines - Draws rays in color based on sight
        if(PlayerSightBlocked == false)
        {
            Debug.DrawLine(HeadRay.position,
                Controller.PlayerTarget.position,
                Color.green);
        }
        else
        {
            Debug.DrawLine(HeadRay.position,
                Controller.PlayerTarget.position,
                Color.red);
        }
    }
}
