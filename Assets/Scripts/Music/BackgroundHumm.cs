using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starts playing background hummm clip when you enter trigger
/// Stops playing when you leave.
/// </summary>

public class BackgroundHumm : MonoBehaviour
{
    private AudioSource audioSrc;

    /// <summary>
    /// Set ref to the audio source
    /// </summary>
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    /// <summary>
    /// When a Game Object enters trigger.
    /// </summary>
    /// <param name="col">Player Hopefully</param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            audioSrc.Play();
    }

    /// <summary>
    /// When a Game Object leaves trigger.
    /// </summary>
    /// <param name="col">Player Hopefully</param>
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
            audioSrc.Stop();
    }
}
