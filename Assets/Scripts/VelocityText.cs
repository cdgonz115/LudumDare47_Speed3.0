using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VelocityText : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI velText;

    private void Update()
    {
        velText.text = "Velocity: " + (int)player.GetComponent<TestMovement>().velocity;
    }
}
