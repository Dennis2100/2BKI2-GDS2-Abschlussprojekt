using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthPotion : buyableItem
{
    public IntValue numberOfHealthPotions;

    // Start is called before the first frame update
    void Start()
    {
        /*numberOfHealthPotions.initialValue = numberOfHealthPotions.masterValue;
        numberOfHealthPotions.RuntimeValue = numberOfHealthPotions.initialValue;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (coins.RuntimeValue >= cost)
        {
            coins.RuntimeValue -= cost;
            numberOfHealthPotions.RuntimeValue++;
        }
    }
}
