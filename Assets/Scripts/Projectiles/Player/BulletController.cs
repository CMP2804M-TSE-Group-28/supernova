using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Stats & FX")] public float Damage;
    public GameObject HitFx;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit an enemy");

            other.gameObject.GetComponent<EnemyController>().Health -= Damage;

            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "NotRevenant")
        {
            other.gameObject.GetComponent<BossController_Revenant>().Health -= Damage;
            Destroy(gameObject);

            Debug.Log("Hit the not revenant");
        }
        else if(other.gameObject.tag == "NotPinky")
        {
            other.gameObject.GetComponent<BossController_Pinky>().Health -= Damage;
            Destroy(gameObject);

            Debug.Log("Hit the not pinky");
        }
        else if(other.gameObject.tag == "Map")
        {
            Debug.Log("Hit a wall");

            GameObject _wallHitFX = Instantiate(HitFx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
