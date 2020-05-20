using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBeckgraund3 : MonoBehaviour
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
        PlayerPrefs.SetInt("Level",2);
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
                Application.LoadLevel("Game4");
                break;
        }
    }

    public void CheckStatistic()
    {
        if (ran.type == false)
        {
            textCheck = int.Parse(ran.animalLegs.text);
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
                        Application.LoadLevel("Game4");
                    }
            }
            else
            {
                GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                PlayerPrefs.SetInt("Level", 1);
                canvas.SetActive(true);
            }

        }
        else
        if (ran.type != false)
        {
            GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt("Level", 1);
            canvas.SetActive(true);
        }
    }

    public void CheckStatistic2()
    {
        if (ran.type == false)
        {
            textCheck = int.Parse(ran.animalLegs.text);
            if (textCheck > 50)
            {
                GameObject.Find("NatureAudio").GetComponent<AudioSource>().Stop();
                PlayerPrefs.SetInt("Level", 1);
                canvas.SetActive(true);
            }
            else
                ran.onRandomchik = true;
        }
        else
        if (ran.type != false)
        {
            ran.onRandomchik = true;
        }

    }
}
