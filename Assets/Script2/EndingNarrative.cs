using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class EndingNarrative : MonoBehaviour
{
    public GameObject blocker;
    Image blockerImage;
    BoxCollider2D blockerCollider;

    public GameObject smiling;
    public GameObject stock;

    bool offSmiling = false;

    public Text narrText;

    public int counter = 0;

    List<string> guides = new List<string>(3);

    public static bool canLoadMenu = false;

    void AddGuides()
    {
        guides.Add("Вы сумели заселить все планеты, не нарушив баланс между существами!");
        guides.Add("Жители планет будут Вам очень благодарны.");
        guides.Add("Спасибо за игру.");
        guides.Add("Авторы\nБГУИР, 724401\nМаксим Качаловский\nНикита Зайкин");
    }

    void Start()
    {     
        AddGuides();
        blockerImage = blocker.GetComponent<Image>();
        blockerCollider = blocker.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (RandomBackgraund5.lvlComplete)
        {
            blocker.SetActive(true);
            if (!offSmiling)
                smiling.SetActive(true);
            narrText.text = guides[counter];
            if (Input.anyKeyDown)
            {
                counter++;
                if (counter == 2)
                {
                    smiling.SetActive(false);
                    offSmiling = true;
                    stock.SetActive(true);
                }
                if (counter == 3)
                {
                    stock.SetActive(false);
                }
            }
            if (counter == 4)
            {
                RandomBackgraund5.lvlComplete = false;
                canLoadMenu = true;
            }
        }        
    }

}