using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Entity Scripts")]
    public ProjectileInfoEnemy Info;
    public ProjectileMovement Movement;

    [Header("Componets")]
    public Rigidbody ProjectileRigidbody;
    public Sprite ProjectileSprite;
    public Transform SpritePlane;

    private Transform _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Gets scripts
        Movement = GetComponent<ProjectileMovement>();
        ProjectileRigidbody = GetComponent<Rigidbody>();

        _playerPosition = GameObject.Find("PlayerTarget").transform;
    }

    private void Update()
    {
        SpritePlane.LookAt(_playerPosition);
    }

    public void GetProjectileInfo(GameObject EntityFiring)
    {
        // Gets projectile info
        Info = EntityFiring.GetComponent<EnemyRanged>().Info;

        // Sets all the necessary stats and components
        ProjectileSprite = Info.ProjectileSprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(Info.Damage);
        }
    }
}
