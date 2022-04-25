using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [Header("Master Script")]
    public ProjectileController Controller;

    private Vector3 _movementDir;
    private float _timer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<ProjectileController>();    
    }

    // Update is called once per frame
    private void Update()
    {
        MoveProjectile();
        DestoryProjectileAfterTime(5);
    }

    private void MoveProjectile()
    {
        _movementDir = transform.forward * Controller.Info.Speed;

        _movementDir.y += -Controller.Info.DropRate * Time.deltaTime;

        transform.Translate(_movementDir * Time.deltaTime);
    }

    private void DestoryProjectileAfterTime(float Seconds)
    {
        _timer += Time.deltaTime;

        if(_timer >= Seconds)
        {
            Destroy(transform.gameObject);
        }
    }
}
