using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionSound : MonoBehaviour
{
    private AudioManager audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    private void OnDestroy()
    {
        audioSource.manualVolumeSources[2].Play();
    }

}
