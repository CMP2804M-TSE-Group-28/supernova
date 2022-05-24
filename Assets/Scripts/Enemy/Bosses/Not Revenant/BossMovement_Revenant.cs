using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("Movement")] public float MoveSpeed;
    public Transform[] GroundMovementPositions;
    public Transform[] AirMovementPositions;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void MoveToPosition(Vector3 NewPosition)
    {
        Controller.transform.position = Vector3.MoveTowards(Controller.transform.position, NewPosition, 1f);
    }
}
