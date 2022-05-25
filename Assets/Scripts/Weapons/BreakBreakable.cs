using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBreakable : MonoBehaviour
{
    void Awake()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("DETECTING COLLISION...");
            if (hitCollider.gameObject.tag == "Breakable")
            {
                Debug.Log("DISABLING BREAKABLE..");
                hitCollider.gameObject.SetActive(false);
            }
            else if(hitCollider.gameObject.tag == "Player")
            {
                Debug.Log("Hit player");
                hitCollider.gameObject.GetComponent<Health>().TakeDamage(25);
                hitCollider.gameObject.GetComponent<Rigidbody>().AddForce(-hitCollider.transform.forward * 100f);
            }
            else if(hitCollider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit enemy");
                hitCollider.gameObject.GetComponent<EnemyController>().Health -= 50;
            }
            else if(hitCollider.gameObject.tag == "NotPinky")
            {
                Debug.Log("Hit pinky");
                hitCollider.gameObject.GetComponent<BossController_Pinky>().Health -= 50;
            }
            else
            {
                Debug.Log("TAG IS NOT Breakable, IT IS: " + hitCollider.gameObject.tag);
            }
        }
    }
}
