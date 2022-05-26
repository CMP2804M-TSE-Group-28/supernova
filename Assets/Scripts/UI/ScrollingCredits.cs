using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingCredits : MonoBehaviour
{
    [SerializeField] private RectTransform position;
    public float Speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((Vector3.up * Speed) * Time.deltaTime);

        if(transform.position.y >= 2900f)
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }
    }
}
