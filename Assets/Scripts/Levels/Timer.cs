using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public decimal time;
    private Scene scene;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (scene.name == "Game")
        {
            time = System.Math.Round((decimal)Time.timeSinceLevelLoad, 2);
        }
        timerText.text = time.ToString();
    }
}
