using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    private float slowDown = 0.5f;
    private GameObject player;

    private float timer = 5;
    bool hitTrap = false;

    private void Update()
    {
        if(hitTrap)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                player.GetComponent<TestMovement>().boostMultiplier = 1;
                hitTrap = false;
                timer = 5;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitTrap = true;
            player = other.gameObject;
            other.gameObject.GetComponent<TestMovement>().boostMultiplier *= slowDown;
        }
    }
}
