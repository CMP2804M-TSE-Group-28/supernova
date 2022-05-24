using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicController : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public MusicClips[] Clips;

    // PRIVATE DECLARATIONS
    private AudioSource _currentMusic;
    private string _currentMusicName;

    private void Awake()
    {
        foreach(MusicClips MC in Clips)
        {
            MC.Source = gameObject.AddComponent<AudioSource>();
            MC.Source.clip = MC.Clip;

            MC.Source.volume = MC.Volume;
        }

        _currentMusic = null;
    }

    private void Start()
    {
        StartMusic();
    }

    public void StartMusic()
    {
        Clips[0].Source.Play();
        _currentMusicName = "Ambient 1";
        _currentMusic = Clips[0].Source;
        _currentMusic.loop = true;
    }

    public void PlayMusic(string MusicName, float MusicVolume)
    {
        MusicClips MC = Array.Find(Clips, music => music.MusicName == MusicName);

        Debug.Log(_currentMusicName);

        if (_currentMusicName == MusicName)
        {
            Debug.Log("Already Playing");
        }
        else
        {
            MC.Source.Play();
            MC.Source.volume = 0f;
            MC.Source.loop = true;

            for (float i = 0f; i < MusicVolume; i += 0.001f)
            {
                MC.Source.volume += i;
                _currentMusic.volume -= i;
            }

            _currentMusic.Stop();
            _currentMusic = MC.Source;
            _currentMusicName = MusicName;

            Debug.Log("Changed Music");
        }
    }
}
