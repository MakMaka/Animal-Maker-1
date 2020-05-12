using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomchik : MonoBehaviour
{
    public bool type;

    public GameObject[] headD;
    public GameObject[] headP;
    public GameObject[] torso;

    public GameObject textPl;
    public GameObject background;
    public GameObject planet;

    public Text animal;
    public Text animalhead;

    public Text animalTorso;
    public Text animalTorso2;

    public Text animalLegs;
    public Text animalLegs2;

    int randStatistic;
    int randAnimal;
    int randHead;

    public bool onRandomchik = true;

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(true);
        planet.SetActive(true);
        textPl.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(onRandomchik == true)
        {
            for (int k = 0; k < headD.Length; k++)
            {
                headD[k].SetActive(false);
            }
            for (int k = 0; k < headP.Length; k++)
            {
                headP[k].SetActive(false);
            }
            for (int k = 0; k < torso.Length; k++)
            {
                torso[k].SetActive(false);
            }

            randStatistic = Random.Range(0,5);
            torso[randStatistic].SetActive(true);

            randStatistic = Random.Range(6, 100);
            animalhead.text = randStatistic.ToString();

            randStatistic = Random.Range(6, 100);
            animalTorso.text = randStatistic.ToString();

            randStatistic = Random.Range(6, 100);
            animalTorso2.text = randStatistic.ToString();

            randStatistic = Random.Range(6, 100);
            animalLegs.text = randStatistic.ToString();

            randStatistic = Random.Range(6, 100);
            animalLegs2.text = randStatistic.ToString();

            randHead = Random.Range(0, 2);

            randAnimal = Random.Range(1, 3);
            if (randAnimal == 1)
            {
                type = true;
                animal.text = "Хищник";
                headD[randHead].SetActive(true);
            }
            if (randAnimal == 2)
            {
                type = false;
                animal.text = "Травоядное";
                headP[randHead].SetActive(true);
            }
            onRandomchik = false;
        }
    }
}
