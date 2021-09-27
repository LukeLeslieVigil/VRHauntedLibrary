using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextBox : MonoBehaviour
{
    public GameObject activateObject;
    public GameObject textbox;
    public float timer;

    private bool enableText = true;
    private bool runTimer = true;

    private void Update()
    {
        if (enableText == true)
        {
            activateText();
        }
        else
        {
            if(runTimer == true)
            {
                timer = timer + Time.deltaTime;

                if (timer > 5)
                {
                    disableText();
                    timer = 0;
                }
            }  
        } 
    }

    private void activateText()
    {
        if (activateObject.activeInHierarchy == false)
        {
            textbox.SetActive(true);
            enableText = false;
        }
    }

    private void disableText()
    {
        textbox.SetActive(false);
        runTimer = false;
    }
}
