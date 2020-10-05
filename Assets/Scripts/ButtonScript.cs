using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private AudioManager audioSource;
    public Button button;

    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();

        button.onClick.AddListener(delegate { playClip(audioSource); } );
    }

    public void playClip(AudioManager audioSource)
    {
        audioSource.manualVolumeSources[1].Play();
    }
}
