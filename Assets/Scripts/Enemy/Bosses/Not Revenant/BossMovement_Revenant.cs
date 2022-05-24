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

    [HideInInspector] public GameObject[] _groundMovePoints;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();

        _groundMovePoints = GameObject.FindGameObjectsWithTag("RevenantMovePos");

        for(int i = 0; i < _groundMovePoints.Length; i++)
        {
            GroundMovementPositions[i] = _groundMovePoints[i].transform;
        }
    }

    public void MoveToPosition(Transform NewPosition)
    {
        Controller.transform.position = Vector3.MoveTowards(Controller.transform.position, NewPosition.position, MoveSpeed * Time.deltaTime);
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

        return _nearestPoint;
    }

    public Transform FindFurthestAirPoint(Transform[] Points)
    {
        Transform _furthestPoint = null;
        float minDistance = Mathf.Infinity;
        Vector3 _playerPos = Controller.PlayerEntity.position;

        foreach (Transform p in Points)
        {
            float _distance = Vector3.Distance(p.position, _playerPos);

            if (_distance > minDistance)
            {
                _furthestPoint = p;
                minDistance = _distance;
            }
        }

        return _furthestPoint;
    }
}
