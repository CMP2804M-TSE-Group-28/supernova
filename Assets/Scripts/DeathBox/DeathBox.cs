using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Subtract player health here
            // I.E PlayerHealth = -69
            other.GetComponent<Health>().Kill();
        }
    }
}
