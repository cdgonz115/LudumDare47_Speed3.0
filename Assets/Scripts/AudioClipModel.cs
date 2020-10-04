using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipModel : MonoBehaviour
{
    public AudioClip[] audioClips;
    public static float Volume
    {
        get { return _volume; }
        set
        {
            if (value < 0) _volume = 0;
            else if (value > 1) _volume = 1;
            else _volume = value;
        }
    }

    private AudioSource[] _sources;
    private static float _volume = 1;
    // Start is called before the first frame update
    void Awake()
    {
        _sources = new AudioSource[audioClips.Length];

        for (int x = 0; x < _sources.Length; x++)
        {
            _sources[x] = gameObject.AddComponent<AudioSource>();
            _sources[x].clip = audioClips[x];
            _sources[x].volume = Volume;
        }
    }

    public void Play(string name, bool doLoop = false)
    {
        AudioSource source = Array.Find(_sources, clip => clip.name == name);
        if (source)
        {
            source.volume = Volume;
            source.loop = doLoop;
            source.Play();
        }
    }

    public void Stop(string name)
    {
        AudioSource source = Array.Find(_sources, clip => clip.name == name);
        if (source) source.Stop();
    }
}
