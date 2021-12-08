using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    private KeysToExit exitDoor;
    private GameSoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<GameSoundManager>();
        exitDoor = GameObject.FindGameObjectWithTag("ExitDoors").GetComponent<KeysToExit>();
    }

    public void KeyCollected()
    {
        //Adds to the keys collected count in the exit door's script
        exitDoor.keysCollected++;
        //disables the relevant door lock
        exitDoor.doorLocks[exitDoor.keysCollected-1].SetActive(false);
        //Plays the key collection sound from the sound manager so the playe rwill hear it directly in their ears
        soundManager.PlayOneShot(soundManager.keyCollected);
        //Clears the key collider from the list of interactables so it won't create an error when deleting
        GetComponent<XROffsetGrabInteractable>().colliders.Clear();
        Destroy(this.gameObject);
    }
}
