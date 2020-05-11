using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCheck : MonoBehaviour
{

    private void OnEnable()
    {
        if (PlayerPrefs.GetString("Music") == "no")
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
            
    }
}
