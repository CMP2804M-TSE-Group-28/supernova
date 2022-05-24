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

    private Transform _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Gets scripts
        Movement = GetComponent<ProjectileMovement>();
        ProjectileRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        transform.LookAt(_playerPosition);
    }

    public void GetProjectileInfo(GameObject EntityFiring)
    {
        // Gets projectile info
        Info = EntityFiring.GetComponent<EnemyRanged>().Info;

        // Sets all the necessary stats and components
        ProjectileSprite = Info.ProjectileSprite;
    }
}
