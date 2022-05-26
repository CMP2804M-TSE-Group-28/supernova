using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [Header("Master Script")]
    public ProjectileController Controller;

    [HideInInspector] public Transform ShotOrigin;

    private Vector3 _movementDir;
    private float _timer = 0f;
    private Transform _playerTarget;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<ProjectileController>();
        _playerTarget = GameObject.Find("PlayerTarget").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Controller.Info.IsTrackingPlayer == false)
        {
            MoveProjectile();
        }
        else
        {
            TrackPlayerPosition();
        }

        DestoryProjectileAfterTime(5);
    }

    private void TrackPlayerPosition()
    {
        _movementDir = (ShotOrigin.transform.forward * Controller.Info.Speed) * 10;
        _movementDir.y += Controller.Info.DropRate * Time.deltaTime;

        Controller.ProjectileRigidbody.AddForce(_movementDir * Time.deltaTime);

        Vector3 _dirToPlayer = _playerTarget.position - transform.position;
        Vector3 _currentDir = transform.forward;
        float _turnSpeed = 65f;
        Vector3 _rotationAngle = Vector3.RotateTowards(_currentDir, _dirToPlayer, _turnSpeed * Mathf.Rad2Deg * Time.deltaTime, 1f);
        transform.rotation = Quaternion.LookRotation(_rotationAngle);
    }

    private void MoveProjectile()
    {
        _movementDir =  (ShotOrigin.transform.forward * Controller.Info.Speed) * 10;
        _movementDir.y += -Controller.Info.DropRate * Time.deltaTime;

        Controller.ProjectileRigidbody.AddForce(_movementDir * Time.deltaTime);
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
