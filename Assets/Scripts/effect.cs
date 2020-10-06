using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class effect : MonoBehaviour
{
    public VisualEffect explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
