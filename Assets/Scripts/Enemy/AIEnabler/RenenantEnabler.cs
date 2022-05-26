using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenenantEnabler : MonoBehaviour
{
    public GameObject Revenant;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" &&
            Revenant != null)
        {
            Revenant.GetComponent<BossController_Revenant>().IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" &&
            Revenant != null)
        {
            Revenant.GetComponent<BossController_Revenant>().IsActive = false;
        }
    }
}
