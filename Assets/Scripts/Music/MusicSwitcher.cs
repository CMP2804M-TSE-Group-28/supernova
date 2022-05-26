using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public MusicController Controller;

    public string MusicName;

    public string areaName;

    public Text anOutput;

    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicController>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Controller.PlayMusic(MusicName, 1f);

            anOutput.text = areaName;
        }
    }
}
