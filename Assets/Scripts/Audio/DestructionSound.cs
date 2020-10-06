using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class DestructionSound : MonoBehaviour
{
    public VisualEffect explosion;

    private void OnDestroy()
    {
        explosion.Play();
    }

}
