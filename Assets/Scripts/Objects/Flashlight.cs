using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light flashLight;

    private void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;
    }

    public void TriggerLight()
    {
        flashLight.enabled = !(flashLight.enabled);
    }
}
