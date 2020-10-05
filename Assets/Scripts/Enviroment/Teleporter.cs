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
            //print(other.gameObject.transform.position.y);
            other.GetComponent<CharacterController>().enabled = false;
            //print("Position Before "+other.transform.position.y);
            //print("Velocity y " + other.GetComponent<TestMovement>().yVelocity.y);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + safetyTeleportValue * (other.GetComponent<Rigidbody>().velocity.y<0?2:1) * (other.GetComponent<Rigidbody>().velocity.magnitude), respawnPoint.transform.position.z);
            //print(other.gameObject.transform.position.y);
            other.GetComponent<CharacterController>().enabled = true;
            //print("Position after " + other.transform.position.y);
        }
    }
}
