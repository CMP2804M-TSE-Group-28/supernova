using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Sprites")] public Transform MainSprite;

    public Vector3 LookAtPlayerOffset;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 _playerPos = new Vector3(Controller.PlayerTarget.transform.position.x,
            Controller.PlayerTarget.transform.position.y,
            Controller.PlayerTarget.transform.position.z);

        MainSprite.LookAt(_playerPos + LookAtPlayerOffset);
    }
}
