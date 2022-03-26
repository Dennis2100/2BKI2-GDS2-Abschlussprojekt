using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainer;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
        playerCurrentHealth.RuntimeValue = playerCurrentHealth.initialValue;
    }

    void Update()
    {
        UpdateHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainer.initialValue; i++)   //Solange i kleiner als der initialValue der heartContainer ist
        {
            hearts[i].gameObject.SetActive(true);               //Das GameObjekt am Index i wird aktiviert
            hearts[i].sprite = fullHeart;                       //Das Sprite wird auf das ausgefüllte Herz gesetzt
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;    //tempHealth wird der RunTimeValue vom playerCurrentHealth zugewiesen, es wird /2 gemacht da wir mit halben Herzen arbeiten

        for (int i = 0; i < heartContainer.initialValue; i++)
        {
            if (i <= tempHealth-1)
            {
                //Full Heart
                hearts[i].sprite = fullHeart; 
            }
            else if (i >= tempHealth)
            {
                //Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                //Half full Hearts
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
