using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAtSpeed : MonoBehaviour
{
    public float speedBreeak;
    public void Poof() => Destroy(transform.gameObject);
}