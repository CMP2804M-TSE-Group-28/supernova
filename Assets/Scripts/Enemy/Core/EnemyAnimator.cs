using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    // Scripts
    [Header("Master Script")] public EnemyController Controller;

    [Header("Sprites")] public Transform MainSprite;

    // Start is called before the first frame update
    private void Start()
    {
        // Get all available scripts on the entity
        Controller = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        //LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        MainSprite.LookAt(Controller.PlayerEntity.transform.position);
    }
}
