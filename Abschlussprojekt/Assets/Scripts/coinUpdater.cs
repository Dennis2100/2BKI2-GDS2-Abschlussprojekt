using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinUpdater : MonoBehaviour
{
    public Text txt;
    public IntValue coins;
    public GameObject updater;

    // Start is called before the first frame update
    void Start()
    {
        coins.initialValue = coins.masterValue;
        coins.RuntimeValue = coins.initialValue;
        updater.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = coins.RuntimeValue.ToString();
    }
}
