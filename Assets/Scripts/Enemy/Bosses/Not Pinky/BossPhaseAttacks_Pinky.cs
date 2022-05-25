using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseAttacks_Pinky : MonoBehaviour
{
    // PUBLIC DECLARTIONS
    public BossController_Pinky Controller;

    [Header("Phase 1 Stats")] public int MeleeDamage;
    public float MeleeDelay;
    public float MeleeRange;

    [Header("Phase 2 Stats")] public int ChargeDamage;
    public float ChargeDelay;
    public float ChargeRange;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Pinky>();
    }

    public IEnumerator PreformMeleeAttack()
    {
        Debug.Log("Preforming melee attack");
        Controller.BossNavagent.isStopped = true;
        Controller.PlayerEntity.GetComponent<Health>().TakeDamage(MeleeDamage);

        yield return new WaitForSeconds(1);
        Controller.BossNavagent.isStopped = false;

        yield return null;
    }

    public IEnumerator PreformChargeAttack(Vector3 DirToPlayer)
    {
        Debug.Log("Preforming charge attack");

        Controller.BossRigidbody.isKinematic = false;
        Controller.Behaviour.IsCharging = true;
        Controller.BossNavagent.isStopped = true;
        yield return new WaitForSeconds(1);

        Controller.BossRigidbody.AddForce(-DirToPlayer * 2500f, ForceMode.Acceleration);

        yield return new WaitForSeconds(2f);
        Controller.BossRigidbody.isKinematic = true;
        Controller.Behaviour.IsCharging = false;
        Controller.BossNavagent.isStopped = false;

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && 
            Controller.Behaviour.IsCharging == true)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(ChargeDamage);
            other.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000f, ForceMode.Acceleration);
        }
        else if(other.gameObject.tag == "Breakable" &&
            Controller.Behaviour.IsCharging == true)
        {
            other.gameObject.SetActive(false);
        }
    }
}
