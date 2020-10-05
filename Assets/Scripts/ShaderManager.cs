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

    /// <summary>
    /// Turns on a Post Processing effect.
    /// </summary>
    /// <param name="name">Name of Post Processing Effect.</param>
    /// <param name="effectDurration">Optional param on how long you want effect to last. By default it lasts forever.</param>
    /// <returns>True if sucessful, False if could not find effect component.</returns>
    public bool TurnOnPostProcessingEffect(string name, float effectDurration = -1f)
    {
        foreach(VolumeComponent component in components)
        {
            if (component.name.Contains(name))
            {
                component.active = true;

                if (effectDurration > 0)
                    StartCoroutine(AfterTimeTurnOffEffect(component, effectDurration));

                return true;
            }
        }

        // if wasnt found return false
        return false;
    }

    /// <summary>
    /// Turns off effect after given duration.
    /// </summary>
    /// <param name="component">Volume Component to turn off.</param>
    /// <param name="effectDurration">Time for effect to last.</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator AfterTimeTurnOffEffect(VolumeComponent component, float effectDurration)
    {
        yield return new WaitForSeconds(effectDurration);
        component.active = false;
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
