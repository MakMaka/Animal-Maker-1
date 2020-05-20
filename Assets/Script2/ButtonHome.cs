using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHome : MonoBehaviour
{
    public Sprite colDown, colUp;


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
        if (PlayerPrefs.GetString("Music") != "no")
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Home":
                Application.LoadLevel("Menu");
                break;
        }
    }
}
