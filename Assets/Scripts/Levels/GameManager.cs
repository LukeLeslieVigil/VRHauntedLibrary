using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        DisplayPreviousTimes();
    }

    public PlayerTimeEntry LoadPreviousTimes()
    {
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/times.dat", FileMode.Open);
        PlayerTimeEntry playerBestTime = (PlayerTimeEntry)bFormatter.Deserialize(file);
        file.Close();

        foreach (var x in playerBestTime.timeScore)
        {
            Debug.Log(x + " best time");
        }

        return playerBestTime;
    }

    public void SaveTime(decimal time)
    {
        PlayerTimeEntry times = LoadPreviousTimes();
        times.timeScore.Add((int)(time));
        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/times.dat");
        bFormatter.Serialize(file, times);
        file.Close();
    }

    public void DisplayPreviousTimes()
    {
        PlayerTimeEntry times = LoadPreviousTimes();
        times.timeScore.Sort();
        if(GameObject.Find("PreviousTimes") != null)
        {
            Text timesLabel = GameObject.Find("PreviousTimes").GetComponent<Text>();
            timesLabel.text = "Best Escape Times: \n";
            foreach (var time in times.timeScore)
            {
                timesLabel.text += time + " seconds \n";
            }
        }  
    }
}
