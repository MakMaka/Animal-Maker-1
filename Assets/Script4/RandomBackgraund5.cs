using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackgraund5 : MonoBehaviour
{
    public Randomchik ran;

    public GameObject canvas;
    public Slider sl;
    int popitok = 6;

    private bool nextLevel;

    public Sprite colDown, colUp;

    int textCheck;

    public static bool lvlComplete = false;

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
        PlayerPrefs.SetInt("Level", 5);
    }

    private void Update()
    {
        if (EndingNarrative.canLoadMenu)
        {
            EndingNarrative.canLoadMenu = false;
            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
            Application.LoadLevel("Menu");
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
        }
    }

    public void CheckStatistic()
    {
        if (ran.type == true)
        {
            textCheck = int.Parse(ran.animalhead.text);
            if (textCheck > 50)
            {
                textCheck = int.Parse(ran.animalTorso.text);
                if (textCheck < 50)
                {
                    textCheck = int.Parse(ran.animalLegs2.text);
                    if (textCheck > 50)
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
                            lvlComplete = true;
                            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                            //Application.LoadLevel("Menu");
                        }
                    }
                    else
                    {
                        GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                        canvas.SetActive(true);
                    }

                }
                else
                {
                    GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                    canvas.SetActive(true);
                }

            }
            else
            {
                GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                canvas.SetActive(true);
            }

        }
        else
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
                textCheck = int.Parse(ran.animalTorso.text);
                if (textCheck < 50)
                {
                    textCheck = int.Parse(ran.animalLegs2.text);
                    if(textCheck > 50)
                    {
                        GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                        canvas.SetActive(true);
                    }
                    else
                        ran.onRandomchik = true;
                }
                else
                    ran.onRandomchik = true;
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
