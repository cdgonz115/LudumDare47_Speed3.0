using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAtSpeed : MonoBehaviour
{
    public float speedBreeak;
    public TestMovement player;
    public Material shader;
    public void Poof() => Destroy(transform.gameObject);

    private void Update()
    {
        shader.SetFloat("ColorChangePercent", (player.velocity/speedBreeak));
    }
}