using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class BreakAtSpeed : MonoBehaviour
{
    private AudioManager audioSource;
    public float speedBreeak;
    public TestMovement player;
    public Material shader;
    public GameObject effectObject;
    //public VisualEffect explosion;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TestMovement>();
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    public void Poof()
    {
        //explosion.initialEventName = "DestroyWall";
        Instantiate(effectObject, transform.position, transform.rotation);
        audioSource.manualVolumeSources[2].Play();
        Destroy(transform.gameObject);
    }

    private void Update()
    {
        shader.SetFloat("ColorChangePercent", (player.velocity/speedBreeak));
    }
}