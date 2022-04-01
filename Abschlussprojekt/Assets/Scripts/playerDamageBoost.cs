using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamageBoost : MonoBehaviour
{
    public IntValue playerDamage;
    public float timer;
    public bool resetAbility;
    public bool pressAble;
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        playerDamage.initialValue = playerDamage.masterValue;
        playerDamage.RuntimeValue = playerDamage.initialValue;
        pressAble = true;
        timer = 0;
        icon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) /*&& pressAble*/)
        {
            BoostDamage();
        }

        if (pressAble == false)
        {
            Updater();
        }
    }

    public void BoostDamage()
    {
        if(pressAble)
        {
            playerDamage.RuntimeValue++;
            pressAble = false;
        }
    }

    private void Updater()
    {
        timer += Time.deltaTime;

        if ((int)timer == 10)
        {
            timer = 0;
            playerDamage.RuntimeValue = playerDamage.initialValue;
            pressAble = true;
        }
    }
}
