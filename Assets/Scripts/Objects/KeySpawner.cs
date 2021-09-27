using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject keyPrefab;
    public GameObject keyClone;

    void spawnKey(int num)
    {
        keyClone = Instantiate(keyPrefab, spawnLocations[num]) as GameObject;
    }

    private void Start()
    {
        int spawnPoint = Random.Range(0, spawnLocations.Length);
        spawnKey(spawnPoint);
    }
}
