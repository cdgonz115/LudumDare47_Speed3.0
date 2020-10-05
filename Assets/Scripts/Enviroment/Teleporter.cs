using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject respawnPoint;
    public float safetyTeleportValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + safetyTeleportValue * (other.GetComponent<Rigidbody>().velocity.y<0?2:1) * (other.GetComponent<Rigidbody>().velocity.magnitude), respawnPoint.transform.position.z);
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
