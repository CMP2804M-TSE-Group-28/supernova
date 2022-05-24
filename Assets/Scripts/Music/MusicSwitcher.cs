using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public MusicController Controller;

    public string MusicName;

    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicController>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Controller.PlayMusic(MusicName, 1f);
        }
    }
}
