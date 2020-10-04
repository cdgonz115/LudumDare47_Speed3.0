using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShaderManager : MonoBehaviour
{
    public Volume PostProcessingVolume;

    private List<VolumeComponent> components
    {
        get
        {
            return PostProcessingVolume.profile.components;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOffPostProcessingEffect("SineWaveEffect");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TurnOnPostProcessingEffect("SineWaveEffect");
        }
    }

    /// <summary>
    /// Turns on a Post Processing effect.
    /// </summary>
    /// <param name="name">Name of Post Processing Effect.</param>
    /// <returns>True if sucessful, False if could not find effect component.</returns>
    public bool TurnOnPostProcessingEffect(string name)
    {
        foreach(VolumeComponent component in components)
        {
            if (component.name.Contains(name))
            {
                component.active = true;
                return true;
            }
        }

        // if wasnt found return false
        return false;
    }

    /// <summary>
    /// Turns off a Post Processing effect.
    /// </summary>
    /// <param name="name">Name of Post Processing Effect.</param>
    /// <returns>True if sucessful, False if could not find effect component.</returns>
    public bool TurnOffPostProcessingEffect(string name)
    {
        foreach (VolumeComponent component in components)
        {
            if (component.name.Contains(name))
            {
                component.active = false;
                print(component.active);
                return true;
            }
        }

        // if wasnt found return false
        return false;
    }
}
