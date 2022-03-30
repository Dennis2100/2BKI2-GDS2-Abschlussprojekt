using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcBehavior : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public GameObject coinManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerInRange) //Wenn die Leertaste losgelassen wird und der Spieler sich im Radius befindet
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);                 //Dialogbox ist deaktiviert
                coinManager.SetActive(true);
            }
            else
            {
                coinManager.SetActive(false);
                dialogBox.SetActive(true);                  //Dialogbox ist aktiviert
                dialogText.text = dialog;
            }
        }
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
            dialogBox.SetActive(false); //Dialogbox wird deaktiviert
            coinManager.SetActive(true);
        }
    }
}
