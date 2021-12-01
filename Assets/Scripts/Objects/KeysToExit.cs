using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeysToExit : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform[] keyOneSpawnLocation;
    public Transform[] keyTwoSpawnLocation;
    public Transform[] keyThreeSpawnLocation;

    public GameObject[] doorLocks;

    public int keysCollected = 0;

    private int keysRequired = 3;

    private GameObject keyOne;
    private GameObject keyTwo;
    private GameObject keyThree;

    private BoxCollider exitZone;

    /// <summary>
    /// Instantiates a key prefab object at an array of locations,
    /// each corresponding to the same number in the array.
    /// </summary>
    /// <param name="num">The number input of the array.</param>
    private void SpawnKeys(int num)
    {
        keyOne = Instantiate(keyPrefab, keyOneSpawnLocation[num]) as GameObject;
        keyTwo = Instantiate(keyPrefab, keyTwoSpawnLocation[num]) as GameObject;
        keyThree = Instantiate(keyPrefab, keyThreeSpawnLocation[num]) as GameObject;
    }

    private void Start()
    {
        exitZone = GetComponent<BoxCollider>();
        exitZone.enabled = false;

        int spawnPoint = Random.Range(0, keyOneSpawnLocation.Length);

        SpawnKeys(spawnPoint);

        //Debug.Log("Keys spawned!");
        //Debug.Log("Key One spawned at: " + keyOne.transform);
        //Debug.Log("Key Two spawned at: " + keyTwo.transform);
        //Debug.Log("Key Three spawned at: " + keyThree.transform);
    }

    private void Update()
    {
        while(keysCollected > 0)
        {
            doorLocks[keysCollected-1].SetActive(false);
        }

        if (keysCollected >= keysRequired)
        {
            exitZone.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}
