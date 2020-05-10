using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackgraund4 : MonoBehaviour
{
    public Randomchik ran;

    public GameObject canvas;
    public Slider sl;
    int popitok = 6;

    private bool nextLevel;

    public Sprite colDown, colUp;

    int textCheck;

    //int i = 0;

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = colDown;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = colUp;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Music") == "no")
        {
            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
        }
        else
        {
            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Play();
        }
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Okey_Button":
                CheckStatistic();
                break;
            case "Cancel_Button":
                CheckStatistic2();
                break;
            case "Right":
                Application.LoadLevel("Game2");
                break;
        }
    }

    public void CheckStatistic()
    {
        if (ran.type == true)
        {
            textCheck = int.Parse(ran.animalhead.text);
            if (textCheck > 51)
            {
                if (sl.value < popitok)
                {
                    if (PlayerPrefs.GetString("Music") != "no")
                        GetComponent<AudioSource>().Play();
                    ran.onRandomchik = true;
                    sl.value = sl.value + 1;
                }
                if (sl.value == 5)
                {
                    GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                    Application.LoadLevel("Game2");
                }
            }
            else
            {
                GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                canvas.SetActive(true);
            }

        }
        else
        if (ran.type != true)
        {
            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
            canvas.SetActive(true);
        }
    }

    public void CheckStatistic2()
    {
        if (ran.type == true)
        {
            textCheck = int.Parse(ran.animalhead.text);
            if (textCheck > 50)
            {
                GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                canvas.SetActive(true);
            }
            else
                ran.onRandomchik = true;
        }
        else
        if (ran.type != true)
        {
            ran.onRandomchik = true;
        }

    }
}
