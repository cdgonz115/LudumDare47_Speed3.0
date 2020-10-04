using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrap : MonoBehaviour
{
    private GameObject trapObject; //trap that will appear

    private float trapTimeCounter; //actual timer
    private float trapTime; //initial time for the counter

    private void Start()
    {
        trapObject = transform.GetChild(0).gameObject;
        trapTime = 1.0f;
        trapTimeCounter = trapTime;
    }

    private void Update()
    {
        if(trapObject.activeSelf)
        {
            if(trapTimeCounter > 0)
            {
                trapTimeCounter -= Time.deltaTime;
            }
            else
            {
                trapObject.SetActive(false);
                trapTimeCounter = trapTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trapObject.SetActive(true);
        }
    }
}
