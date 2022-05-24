using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRays_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("Components")] public Transform HeadRay;

    [Header("Layer Masks")] public LayerMask MapMask;

    [HideInInspector] public bool PlayerSightBlocked;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckLineOfSight(Controller.PlayerEntity.gameObject);
    }

    private void CheckLineOfSight(GameObject PlayerPostion)
    {
        // Check whether any layer blocks line to player - Head to Head contact
        PlayerSightBlocked = Physics.Linecast(HeadRay.position,
            Controller.PlayerEntity.position,
            MapMask); ;

        // Debug lines - Draws rays in color based on sight
        if (PlayerSightBlocked == false)
        {
            Debug.DrawLine(HeadRay.position,
                Controller.PlayerEntity.position,
                Color.green);
        }
        else
        {
            Debug.DrawLine(HeadRay.position,
                Controller.PlayerEntity.position,
                Color.red);
        }
    }
}
