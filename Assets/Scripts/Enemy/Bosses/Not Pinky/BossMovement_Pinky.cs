using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement_Pinky : MonoBehaviour
{
    // PUBLIC DECLARTIONS
    public BossController_Pinky Controller;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Pinky>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Controller.IsActive == true &&
            Controller.Behaviour.IsCharging == false)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        Controller.BossNavagent.SetDestination(Controller.PlayerEntity.position);
    }


}
