using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class DestructionSound : MonoBehaviour
{
    private AudioManager audioSource;
    public VisualEffect explosion;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    private void OnDestroy()
    {
        explosion.Play();
        audioSource.manualVolumeSources[2].Play();
    }

}
