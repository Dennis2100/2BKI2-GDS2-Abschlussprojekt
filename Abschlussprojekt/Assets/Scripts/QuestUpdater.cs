using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUpdater : MonoBehaviour
{
    public BoolValue questActive;
    public Image image;
    public Text txt;
    //public StringValue dialog;
    public IntValue toKill;
    public IntValue killed;
    public GameObject Item;
    public GameObject questInventory;

    // Start is called before the first frame update
    void Start()
    {
        questActive.initialValue = questActive.masterValue;
        questActive.RuntimeValue = questActive.initialValue;
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Updater();
        OpenQuestInventory();
    }

    private void OpenQuestInventory()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (questInventory.activeInHierarchy)
            {
                questInventory.SetActive(false);
            }
            else
            {
                questInventory.SetActive(true);
            }
        }
    }

    private void Updater()
    {
        if (questActive.RuntimeValue)
        {
            Item.SetActive(true);

            txt.text = $"T�te {toKill.RuntimeValue} Gegner f�r mich\n{killed.RuntimeValue}/{toKill.RuntimeValue}";
        }

        if (toKill.RuntimeValue == killed.RuntimeValue)
        {
            questActive.RuntimeValue = false;
            toKill.RuntimeValue = 0;
        }
    }
}
