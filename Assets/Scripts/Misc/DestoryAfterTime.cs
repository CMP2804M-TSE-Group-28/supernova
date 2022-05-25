using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterTime : MonoBehaviour
{
    public float Time;

    private void Update()
    {
        Destroy(this.gameObject, Time);
    }
}
