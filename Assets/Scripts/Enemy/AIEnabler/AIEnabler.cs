using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnabler : MonoBehaviour
{
    public GameObject[] EnemyEntities;

    private int _sizeOfEntities;

    private void OnTriggerEnter(Collider other)
    {
        // Checks for what object just entered the trigger
        if (other.gameObject.tag == "Player")
        {
            // Checks the size of array
            _sizeOfEntities = EnemyEntities.Length;

            // Loops over the entites
            for(int i = 0; i < _sizeOfEntities; i++)
            {
                // Gets the IsActive bool and sets to to true
                EnemyEntities[i].GetComponent<EnemyController>().IsActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _sizeOfEntities = EnemyEntities.Length;

            for (int i = 0; i < _sizeOfEntities; i++)
            {
                // Gets the IsActive bool and sets to to false
                EnemyEntities[i].GetComponent<EnemyController>().IsActive = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
