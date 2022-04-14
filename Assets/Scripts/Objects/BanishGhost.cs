using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanishGhost : MonoBehaviour
{
    public float DisableTime = 5.0f;
    private GameObject Ghost;
    public GameObject ThisObject;

    //This script checks to see if the object has had its trigger entered by the ghost
    //then it disables that ghost for a set amount of seconds before re-enabling it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GhostEnemy")
        {
            Debug.Log("Banished Ghost");
            Ghost = other.gameObject;
            Ghost.SetActive(false);
            ThisObject.SetActive(false);
            Invoke("EnableGhost", DisableTime);
        }
    }

    private void EnableGhost()
    {
        Ghost.SetActive(true);
    }
}
