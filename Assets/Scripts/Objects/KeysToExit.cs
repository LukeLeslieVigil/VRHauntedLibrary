using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysToExit : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform[] keyOneSpawnLocation;
    public Transform[] keyTwoSpawnLocation;
    public Transform[] keyThreeSpawnLocation;

    public GameObject[] doorLocks;

    public int keysCollected = 0;

    private GameObject keyOne;
    private GameObject keyTwo;
    private GameObject keyThree;


    private void SpawnKeys(int num)
    {
        keyOne = Instantiate(keyPrefab, keyOneSpawnLocation[num]) as GameObject;
        keyTwo = Instantiate(keyPrefab, keyTwoSpawnLocation[num]) as GameObject;
        keyThree = Instantiate(keyPrefab, keyThreeSpawnLocation[num]) as GameObject;
    }

    private void Start()
    {
        int spawnPoint = Random.Range(0, keyOneSpawnLocation.Length);

        SpawnKeys(spawnPoint);

        Debug.Log("Keys spawned!");
        Debug.Log("Key One spawned at: " + keyOne.transform);
        Debug.Log("Key Two spawned at: " + keyTwo.transform);
        Debug.Log("Key Three spawned at: " + keyThree.transform);
    }

    private void Update()
    {
        
    }
}
