using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBookshelf : MonoBehaviour
{
    public GameObject AppearObjects;
    public GameObject DisappearObject;
    public float DelayTime;

    private void Start()
    {
        AppearObjects.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("EnableObjects", DelayTime);
        }
    }

    //Enables the invisible objects.
    //Set DisappearObject to self in inspector if not setting to already existing props.
    public void EnableObjects()
    {
        AppearObjects.SetActive(true);
        DisappearObject.SetActive(false);
    }
}
