using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Narrative : MonoBehaviour
{
    public GameObject blocker;

    public GameObject confused;
    public GameObject smiling;
    public GameObject stock;
    public GameObject laughing;

    public Text narrText;
    //public Sprite[] sprites;
    string intro = "Добро пожаловать в игру\n Creature Inspector!\n В ней Вам предстоит проверять поступивших на вашу инспекцию существ и решать, можно ли их заселить на ту или иную планету.";
    int counter = 0;
    List<string> guides = new List<string>(5);

    //string firstStep = "Это характеристики существа. Внимательно изучите их.";
    //string secondStep = "Это кнопки, при нажатии которых Вы определяете судьбу существа";
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void AddGuides()
    {
        guides.Add("Чтобы пропустить обучение, нажмите кнопку Esc.");
        guides.Add("Это характеристики существа. Внимательно изучите их.");
        guides.Add("Это кнопки, при нажатии которых Вы определяете судьбу существа.");
        guides.Add("Нажмите на кнопку слева, чтобы забраковать существо. Нажмите на кнопку справа, чтобы отправить его на планету.");
        guides.Add("Попробуйте сделать выбор.");
    }

    void Start()
    {
        AddGuides();
        narrText.text = intro;
        blocker.SetActive(true);
        stock.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            blocker.SetActive(false);
        else if (counter < 5 && Input.anyKeyDown)
        {
            narrText.text = guides[counter];
            stock.SetActive(false);
            smiling.SetActive(true);
            counter++;
        }
        else if (Input.anyKeyDown)
            blocker.SetActive(false);
        
    }
}
