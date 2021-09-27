using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Key : MonoBehaviour
{
    public GameObject theKey;
    public bool goingToCollect = false;
    private bool isNextToKey = false;

    private void Update()
    {
        if (isNextToKey == true && goingToCollect == true)
        {
            GameSoundManager.SoundInstance.PlayOneShot(GameSoundManager.SoundInstance.keyCollected);
            theKey.SetActive(false);
        }
    }

    public void CollectKey()
    {
        goingToCollect = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("Hand in");
            isNextToKey = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            isNextToKey = false;
        }
    }
}
