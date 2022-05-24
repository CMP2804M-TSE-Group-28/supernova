using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator_Revenant : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    [Header("Master Script")] public BossController_Revenant Controller;

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GetComponent<BossController_Revenant>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
