using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class MusicClips
{
    [HideInInspector] public AudioSource Source;

    public string MusicName;
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;

}
