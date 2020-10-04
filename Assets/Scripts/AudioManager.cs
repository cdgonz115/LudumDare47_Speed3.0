using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// All this really does is allow volume adjustments. 
/// </summary>
public class AudioManager : MonoBehaviour
{
    //Audio sources on loop can't adjust volume through the audio clip manager so
    //I am adding an array of sources where I will manuall adjust the volumes for
    public AudioSource[] manualVolumeSources;

    public void onVolumeChange(float newVolume)
    {
        AudioClipModel.volume = newVolume;

        foreach(AudioSource source in manualVolumeSources)
        {
            source.volume = newVolume;
        }
    }
}
