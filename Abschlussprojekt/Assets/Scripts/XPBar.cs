using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public float targetPosition = 0;
    public FloatValue add;
    public IntValue lvl;
    public BoolValue value;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        lvl.initialValue = lvl.masterValue;
        lvl.RuntimeValue = lvl.initialValue;
        add.initialValue = add.masterValue;
        add.RuntimeValue = add.initialValue;
        Addition(0);
        value.RuntimeValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (value.RuntimeValue)
        {
            Addition(add.initialValue);
            value.RuntimeValue = false;
        }

        Updater();

        txt.text = lvl.RuntimeValue.ToString();
    }

    private void Updater()
    {
        if (slider.value < targetPosition)
        {
            slider.value += Time.deltaTime * 6f;
        }

        if (slider.value == 1)
        {
            targetPosition = 0;
            slider.value = 0;
            lvl.RuntimeValue++;
        }
    }

    private void Addition(float newProgress)
    {
        targetPosition = slider.value + newProgress;
    }
}
