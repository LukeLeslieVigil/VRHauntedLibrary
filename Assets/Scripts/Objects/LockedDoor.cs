using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockedDoor : MonoBehaviour
{
    public GameObject unlockKey;
    public GameObject doorStop;

    private void Update()
    {
        CheckForKey();
    }

    private void CheckForKey()
    {
        if (unlockKey.activeInHierarchy == false)
        {
            doorStop.SetActive(false);
        }
    }
}
