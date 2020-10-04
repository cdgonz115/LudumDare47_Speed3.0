using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    [SerializeField]
    private float SlowDown = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity *= SlowDown;
        }
    }
}
