using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Narrative : MonoBehaviour
{
    public GameObject blocker;
    Image blockerImage;
    BoxCollider2D blockerCollider;

    public GameObject confused;
    public GameObject smiling;
    public GameObject stock;
    public GameObject laughing;
    public GameObject[] arrows;

    public Text narrText;

    string intro = "Добро пожаловать в игру\n Creature Inspector!\n В ней Вам предстоит проверять поступивших на вашу инспекцию существ и решать, можно ли их заселить на ту или иную планету.";
    
    public int counter = 0;

    List<string> guides = new List<string>(8);

    bool rightChoiseGuide = false;
    bool losingGuide = false;

    bool isEsc = false;

    public static bool canReload = false;
    public static bool canLoadNext = false;

    void AddGuides()
    {
        guides.Add("Чтобы пропустить обучение, нажмите кнопку Esc.");
        guides.Add("Это характеристики существа. Внимательно изучите их.");
        guides.Add("Это кнопки, при нажатии которых Вы определяете судьбу существа.");
        guides.Add("Нажмите кнопку слева, чтобы забраковать существо. Нажмите кнопку справа, чтобы отправить его на планету.");
        guides.Add("Попробуйте сделать выбор.");
        guides.Add("Отлично! Продолжайте в том же духе.");
        guides.Add("Ничего, в следующий раз всё получится.");
        guides.Add("Поздравляю! Вы успешно заселили первую планету.");
    }

    void Start()
    {
        AddGuides();
        narrText.text = intro;
        blocker.SetActive(true);
        stock.SetActive(true);
        blockerImage = blocker.GetComponent<Image>();
    }

    //{     
    //    AddGuides();
    //    narrText.text = intro;
    //    blocker.SetActive(true);
    //    stock.SetActive(true);
    //    blockerImage = blocker.GetComponent<Image>();
    //    blockerCollider = blocker.GetComponent<BoxCollider2D>();
    //    if (Buttonses.isReloaded)
    //    {
    //        confused.SetActive(false);
    //        Buttonses.isReloaded = false;
    //    }
    //}

    void Update()
    {

        
        if (!isEsc)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                blocker.SetActive(false);
                isEsc = true;
            }
            else if (counter < 5 && Input.GetKeyDown(KeyCode.E))

        if (Buttonses.isReloaded)

            if (!isEsc)

            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    confused.SetActive(false);
                    Buttonses.isReloaded = false;
                }
                if (!isEsc)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        blocker.SetActive(false);
                        isEsc = true;
                    }
                    else if (counter < 5 && Input.anyKeyDown)
                    {
                        narrText.text = guides[counter];
                        if (counter == 1)
                        {
                            blockerImage.enabled = false;
                            arrows[0].SetActive(true);
                        }
                        else if (counter == 2 || counter == 3)
                        {
                            arrows[0].SetActive(false);
                            arrows[2].SetActive(true);
                            arrows[1].SetActive(true);
                        }
                        else if (counter == 4)
                        {
                            for (int i = 0; i < 3; i++)
                                arrows[i].SetActive(false);
                            blockerImage.enabled = true;
                        }
                        stock.SetActive(false);
                        confused.SetActive(false);
                        smiling.SetActive(true);
                        counter++;
                    }
                    else if (RandomBackground.rightChoise == true && rightChoiseGuide != true)
                    {
                        narrText.text = guides[counter];
                        blocker.SetActive(true);
                        smiling.SetActive(false);
                        laughing.SetActive(true);
                        rightChoiseGuide = true;
                        RandomBackground.rightChoise = false;
                    }
                    else if (RandomBackground.losing == true && losingGuide != true)
                    {
                        counter++;
                        narrText.text = guides[counter];
                        blocker.SetActive(true);
                        smiling.SetActive(false);
                        laughing.SetActive(false);
                        confused.SetActive(true);
                        losingGuide = true;
                        RandomBackground.losing = false;
                    }
                    else if (RandomBackground.lvlComplete == true)
                    {
                        counter = 7;
                        narrText.text = guides[counter];
                        blocker.SetActive(true);
                        smiling.SetActive(false);
                        laughing.SetActive(false);
                        confused.SetActive(false);
                        stock.SetActive(true);
                        RandomBackground.lvlComplete = false;
                        StartCoroutine(WaitForInput());

                    }
                    else if (Input.anyKeyDown)
                    {
                        blocker.SetActive(false);
                        stock.SetActive(false);
                        confused.SetActive(false);
                        smiling.SetActive(true);
                        counter++;
                    }

                }
                else if (RandomBackground.rightChoise == true && rightChoiseGuide != true)
                {
                    narrText.text = guides[counter];
                    blocker.SetActive(true);
                    smiling.SetActive(false);
                    laughing.SetActive(true);
                    rightChoiseGuide = true;
                    RandomBackground.rightChoise = false;
                }
                else if (RandomBackground.losing && !losingGuide)
                {
                    counter = 6;
                    narrText.text = guides[counter];
                    blockerCollider.enabled = false;
                    blocker.SetActive(true);
                    smiling.SetActive(false);
                    laughing.SetActive(false);
                    confused.SetActive(true);
                    losingGuide = true;
                    RandomBackground.losing = false;
                }
                else if (RandomBackground.lvlComplete == true)
                {
                    counter = 7;
                    narrText.text = guides[counter];
                    blocker.SetActive(true);
                    smiling.SetActive(false);
                    laughing.SetActive(false);
                    confused.SetActive(false);
                    stock.SetActive(true);
                    RandomBackground.lvlComplete = false;
                    StartCoroutine(WaitForInput());
                }
            }

            else if (Input.GetKeyDown(KeyCode.E))
                blocker.SetActive(false);
        }

    }

    public static IEnumerator WaitForInput()
    {
        while (!Input.GetKeyDown(KeyCode.E))
        {
            yield return 0;
        }
        canLoadNext = true;
    }

}