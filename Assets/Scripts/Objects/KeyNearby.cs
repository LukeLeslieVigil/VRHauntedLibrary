using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNearby : MonoBehaviour
{
    private GameSoundManager soundManager;
    private BoxCollider soundZone;
    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<GameSoundManager>();
        soundZone = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            KeyNearbySound();
        }
    }

    private void KeyNearbySound()
    {
        soundManager.PlayOneShot(soundManager.keyNearbyClip);
        Debug.Log("Key sound should play");
        //soundZone.enabled = false;
    }
}
