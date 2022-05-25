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
            else
            {
                Debug.Log("TAG IS NOT Breakable, IT IS: " + hitCollider.gameObject.tag);
            }
        }
    }
}
