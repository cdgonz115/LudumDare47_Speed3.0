using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    AudioManager audioStuff;

    private void Awake()
    {
        audioStuff = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();

        slider.onValueChanged.AddListener(delegate { adjustVolume(audioStuff); });

        slider.value = audioStuff.GetVolume();
    }

    void adjustVolume(AudioManager manager)
    {
        manager.onVolumeChange(slider.value);
    }
}
