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

    // Start is called before the first frame update
    void Start()
    {
        
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
        toKill.RuntimeValue = 10;
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
