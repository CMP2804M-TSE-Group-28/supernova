using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyEnabler : MonoBehaviour
{
    public GameObject Pinky;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" &&
            Pinky != null)
        {
            Pinky.GetComponent<BossController_Pinky>().IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" &&
            Pinky != null)
        {
            Pinky.GetComponent<BossController_Pinky>().IsActive = false;
        }
    }
}
