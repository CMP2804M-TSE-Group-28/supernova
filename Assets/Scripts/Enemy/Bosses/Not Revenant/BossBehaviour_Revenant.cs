using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    // PRIVATE DECLARATIONS
    private Vector3 _playerPosition;
    private Vector3 _dirToPlayer;
    private float _distanceToPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Controller.IsActive == true)
        {
            GetPlayerInfo();
            UpdateBehaviour();
        }
    }

    private void GetPlayerInfo()
    {
        _dirToPlayer = (transform.position - Controller.PlayerEntity.transform.position).normalized;
        _playerPosition = Controller.PlayerEntity.position;
        _distanceToPlayer = Vector3.Distance(transform.position, _playerPosition);

        Controller.transform.LookAt(_playerPosition);
    }

    private void UpdateBehaviour()
    {

    }
}
