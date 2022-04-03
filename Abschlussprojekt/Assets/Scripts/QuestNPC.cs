using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNPC : MonoBehaviour
{
    public BoolValue questActive;
    public GameObject quest;
    public bool playerInRange;
    public IntValue toKill;
    public GameObject button1;
    public GameObject button2;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Bitte hilf mir, mein Dorf wurde von den Baummenschen angeriffen.";
    }

    // Update is called once per frame
    void Update()
    {
        Updater();
    }

    private void Updater()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (quest.activeInHierarchy)
            {
                quest.SetActive(false);                 //Dialogbox ist deaktiviert
            }
            else
            {
                quest.SetActive(true);                  //Dialogbox ist aktiviert
            }
        }
    }

    public void Accept()
    {
        questActive.RuntimeValue = true;
        toKill.RuntimeValue = 1;
        txt.text = "Danke, du bist unser Held";
        button1.SetActive(false);
        button2.SetActive(false);
    }

    public void Decline()
    {
        txt.text = "Schade, wir alle haben Angst";
        button1.SetActive(false);
        button2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Wenn der Spieler sich im Radius befindet
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Wenn der Spieler sich im Radius befindet
        {
            playerInRange = false;
            quest.SetActive(false); //Dialogbox wird deaktiviert
        }
    }
}
