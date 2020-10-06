using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public Slider slider;
    public Camera playerCam;
    private float startSens;
    private float mouseSens;

    // Start is called before the first frame update
    void Start()
    {
        mouseSens = playerCam.GetComponent<MouseMove>().mouseSensitvity;
        startSens = mouseSens;

        slider.onValueChanged.AddListener(delegate { adjustSens(playerCam); });
        slider.value = mouseSens / startSens;
}

    void adjustSens(Camera camera)
    {
        camera.GetComponent<MouseMove>().mouseSensitvity = slider.value * startSens;
    }
}
