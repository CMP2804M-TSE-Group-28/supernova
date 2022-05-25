using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 

This script is to control the save rooms,
the save rooms are the big open green spaces in the game.

This class is added to a G/O which has the particle effect and a trigger box.

This will call the things to make the players health regen,
and will also update spawn point.

*/

public class SaveRoom : MonoBehaviour
{
    private Health pHealth;
    private AudioSource audioSrc;
    public AudioClip sfxRegen;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider player)
    {
        // If player
        if (player.CompareTag("Player"))
        {
            print("Player's gone to the save room!");
            
            // Get the players health script
            pHealth = player.GetComponent<Health>();
            
            // Regen Health and Set Respawn Point
            pHealth.Regenerate();
            pHealth.LastSetRespawnPoint = transform;
            
            // Play Regen Sound
            audioSrc.PlayOneShot(sfxRegen);
        }
    }
}
