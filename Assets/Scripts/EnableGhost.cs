using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhost : MonoBehaviour
{
    public GameObject theGhost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            theGhost.SetActive(true);
            Debug.Log(theGhost + " enabled!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            theGhost.SetActive(false);
            Debug.Log(theGhost + " disabled.");
        }
    }
}
