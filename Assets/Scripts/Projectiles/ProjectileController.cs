using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Entity Scripts")]
    public ProjectileInfo Info;
    public ProjectileMovement Movement;

    [Header("Componets")]
    public Rigidbody ProjectileRigidbody;

    public Sprite ProjectileSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Gets scripts
        Movement = GetComponent<ProjectileMovement>();
        ProjectileRigidbody = GetComponent<Rigidbody>();
    }

    public void GetProjectileInfo(GameObject EntityFiring)
    {
        Info = EntityFiring.GetComponent<EnemyRanged>().Info;

        ProjectileSprite = Info.ProjectileSprite;
    }
}
