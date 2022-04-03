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
    public FloatValue xp;
    public IntValue lvl;

    // Start is called before the first frame update
    void Start()
    {
        questActive.initialValue = questActive.masterValue;
        questActive.RuntimeValue = questActive.initialValue;
        toKill.initialValue = toKill.masterValue;
        toKill.RuntimeValue = toKill.initialValue;
        killed.initialValue = killed.masterValue;
        killed.RuntimeValue = killed.initialValue;
        Item.SetActive(false);
        questInventory.SetActive(false);
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

            txt.text = $"Töte {toKill.RuntimeValue} Gegner für mich\n{killed.RuntimeValue}/{toKill.RuntimeValue}";
        }

        if (toKill.RuntimeValue == killed.RuntimeValue)
        {
            //xp.initialValue = 1f / lvl.RuntimeValue;
            questActive.RuntimeValue = false;
            toKill.RuntimeValue = 0;
            Item.SetActive(false);
        }
    }
}
