using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
door sound received from: https://freesound.org/people/nichols8917/sounds/339632/
*/

[RequireComponent(typeof(AudioSource))] // requires audiosource to work properly
public class LockedDoor : MonoBehaviour
{// MADE BY VANTA -
//This script is placed onto glowing purple objects scattered around the
//  map. These are "switches" which, when interacted with (pressing E?)
//  change material to stop glowing and disable the "locked door" object
//  associated with it.

    private float sfxVol = 0.7f; // if we do global volume, then please edit this variable to use it.
    private bool flipped = false; 
    [SerializeField]private GameObject doorToBeOpened; // door
    [SerializeField]private AudioSource audioSource; // source
    [SerializeField]private AudioClip audioClip; // sound
    [SerializeField]private Material afterOpened; // material that switch changes to after being opened

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("YOU CAN PRESS E ON THIS OBJECT!!");
            if (Input.GetKeyDown("E"))
            {
                OpenDoor();
            }
        }


    }

    public void OpenDoor()
    { // when switch is flipped..
        if (flipped)
        {
            Debug.Log("SWITCH ALREADY FLIPPED!! returning...");
            return;
        }
        
        if (audioSource == null)
        {
            Debug.Log("AUDIO SOURCE NOT FOUND. assigning...");
            audioSource = GetComponent<AudioSource>();
            Debug.Log("AUDIO SOURCE " + audioSource + " ADDED!");
        }

        if (doorToBeOpened == null)
        { // if you can't interact with a switch, it's likely because of this. assign an object to disable.
            Debug.Log("DOOR NOT ASSIGNED TO THIS SWITCH!! returning...");
            return;
        }
        audioSource.PlayOneShot(audioClip, sfxVol); // play opening sound
        GetComponent<Renderer>().material = afterOpened; // change material to indicate change
        doorToBeOpened.SetActive(false); // disable assigned door
        flipped = true;
    }
}
