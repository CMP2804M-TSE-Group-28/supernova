using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    /// <summary>
    /// Kill the player/enemy if they enter a death zone.
    /// This is used on objects that are big holes in the map.
    /// </summary>
    /// <param name="other">The person that entered the death zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Kill();
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Health = 0;
        }
    }
}
