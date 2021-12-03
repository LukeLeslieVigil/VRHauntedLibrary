using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour
{
    private KeysToExit exitDoor;

    private void Start()
    {
        exitDoor = GameObject.FindGameObjectWithTag("ExitDoors").GetComponent<KeysToExit>();
    }

    public void KeyCollected()
    {
        exitDoor.keysCollected++;
        exitDoor.doorLocks[exitDoor.keysCollected-1].SetActive(false);
        this.gameObject.SetActive(false);
    }
}
