using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotionInventory : MonoBehaviour
{
    public Text txt;
    public FloatValue currentHealth;
    public FloatValue hearts;
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
        txt.text = numberOfHealthPotions.RuntimeValue.ToString();
    }

    public void Use()
    {
        if (numberOfHealthPotions.RuntimeValue > 0)
        {
            if ((hearts.RuntimeValue * 2) >= currentHealth.RuntimeValue + 1)
            {
                currentHealth.RuntimeValue += 1;
                numberOfHealthPotions.RuntimeValue--;
            }
        }
    }
}
