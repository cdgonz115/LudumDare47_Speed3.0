using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Class on individual objects that play clips for said object
/// </summary>
public class AudioClipModel : MonoBehaviour
{
    public AudioClip[] audioClips;
    public static float volume = 1.0f;

    private AudioSource[] _sources;
    // Start is called before the first frame update
    void Awake()
    {
        volume = gameObject.GetComponent<AudioSource>().volume;

        _sources = new AudioSource[audioClips.Length];

        for (int x = 0; x < _sources.Length; x++)
        {
            _sources[x] = gameObject.AddComponent<AudioSource>();
            _sources[x].clip = audioClips[x];
        }
    }

    public void Play(string name, bool doLoop = false, int priority = 128, float pitch = 1)
    {
        AudioSource source = Array.Find(_sources, s => s.clip.name.Equals(name));
        if (source)
        {
            source.volume = volume;
            source.loop = doLoop;
            source.priority = priority;
            source.pitch = pitch;
            source.Play();
        }
    }

    public void Stop(string name)
    {
        AudioSource source = Array.Find(_sources, clip => clip.name == name);
        if (source) source.Stop();
    }
}
