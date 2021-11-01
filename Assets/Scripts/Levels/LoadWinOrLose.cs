using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWinOrLose : MonoBehaviour
{
    public GameObject targetZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (targetZone.tag == "WinZone")
            {
                var timer = FindObjectOfType<Timer>();
                //GameManager.instance.SaveTime((int)(timer.time));
                SceneManager.LoadScene("WinMenu");
            }
            else if (targetZone.tag == "GhostZone")
            {
                SceneManager.LoadScene("LoseMenu");
            }
        }
    }
}
