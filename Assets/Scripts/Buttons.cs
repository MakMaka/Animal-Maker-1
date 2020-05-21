using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject n_on, n_off;
    public Sprite colDown, colUp;
    public bool guideSwitch;

    private void Start()
    {
        if (PlayerPrefs.GetString("Music") == "no")
        {
            n_on.SetActive(false);
            n_off.SetActive(true);
            GameObject.Find("SpaceAudio").GetComponent<AudioSource>().Stop();
        }
        else
        {
            n_on.SetActive(true);
            n_off.SetActive(false);
            GameObject.Find("SpaceAudio").GetComponent<AudioSource>().Play();
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = colDown;
    }

    public void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = colUp;
    }

    public void OnMouseUpAsButton()
    {
        if(PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Play_Button":
                GameObject.Find("SpaceAudio").GetComponent<AudioSource>().Stop();
                if (PlayerPrefs.GetInt("Level") != 1 && PlayerPrefs.GetInt("Level") != 2 && PlayerPrefs.GetInt("Level") != 3 
                    && PlayerPrefs.GetInt("Level") != 4 && PlayerPrefs.GetInt("Level") != 5)
                    Application.LoadLevel("Game");
                if (PlayerPrefs.GetInt("Level") == 1)
                    Application.LoadLevel("Game");
                if (PlayerPrefs.GetInt("Level") == 2)
                    Application.LoadLevel("Game3");
                if (PlayerPrefs.GetInt("Level") == 3)
                    Application.LoadLevel("Game4");
                if (PlayerPrefs.GetInt("Level") == 4)
                    Application.LoadLevel("Game2");
                if (PlayerPrefs.GetInt("Level") == 5)
                    Application.LoadLevel("Game5");

                break;
            case "Audio_On_Button":
                PlayerPrefs.SetString("Music", "no");
                n_on.SetActive(false);
                n_off.SetActive(true);
                GameObject.Find("SpaceAudio").GetComponent<AudioSource>().Stop();
                break;
            case "Audio_Off_Button":
                PlayerPrefs.SetString("Music", "yes");
                n_on.SetActive(true);
                n_off.SetActive(false);
                GameObject.Find("SpaceAudio").GetComponent<AudioSource>().Play();
                break;

        }
    }
}
