using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    [Header("Movement")] public float MoveSpeed;
    public Transform[] GroundMovementPositions;
    public Transform[] AirMovementPositions;

    // PRIVATE DECLARATIONS
    private GameObject[] _groundMovePoints;
    private GameObject[] _airMovePoints;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();

        _groundMovePoints = GameObject.FindGameObjectsWithTag("RevenantMoveGround");
        _airMovePoints = GameObject.FindGameObjectsWithTag("RevenantMoveAir");

        for(int i = 0; i < _groundMovePoints.Length; i++)
        {
            GroundMovementPositions[i] = _groundMovePoints[i].transform;
        }

        for (int i = 0; i < _airMovePoints.Length; i++)
        {
            AirMovementPositions[i] = _airMovePoints[i].transform;
        }
    }

    public void MoveToPosition(Transform NewPosition)
    {
        Controller.transform.position = Vector3.MoveTowards(Controller.transform.position, NewPosition.position, Time.deltaTime * MoveSpeed);
    }

    public Transform FindClosestGroundPoint(Transform[] Points)
    {
        Transform _nearestPoint = null;
        float minDistance = Mathf.Infinity;
        Vector3 _playerPos = Controller.PlayerEntity.position;

        foreach (Transform p in Points)
        {
            float _distance = Vector3.Distance(p.position, _playerPos);

            if(_distance < minDistance)
            {
                _nearestPoint = p;
                minDistance = _distance;
            }
        }

        Debug.DrawLine(transform.position, _nearestPoint.position, Color.cyan);

        return _nearestPoint;
    }

    public Transform FindClosestAirPoint(Transform[] Points)
    {
        Transform _nearestPoint = null;
        float minDistance = Mathf.Infinity;
        Vector3 _playerPos = Controller.PlayerEntity.position;

        foreach (Transform p in Points)
        {
            float _distance = Vector3.Distance(p.position, _playerPos);

            if (_distance < minDistance)
            {
                _nearestPoint = p;
                minDistance = _distance;
            }
        }

        Debug.DrawLine(transform.position, _nearestPoint.position, Color.cyan);

        return _nearestPoint;
    }

    public Transform FindFurthestAirPoint(Transform[] Points)
    {
        Transform _furthestPoint = null;
        float furthestDistance = 0f;
        Vector3 _playerPos = Controller.PlayerEntity.position;

        foreach (Transform p in Points)
        {
            float _distanceToPoint = Vector3.Distance(_playerPos,
                p.position);

            if(_distanceToPoint > furthestDistance)
            {
                _furthestPoint = p;
                furthestDistance = _distanceToPoint;
            }
        }

        Debug.DrawLine(transform.position, _furthestPoint.position, Color.cyan);

        return _furthestPoint;
    }
}
