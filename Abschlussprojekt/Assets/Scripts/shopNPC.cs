using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopNPC : MonoBehaviour
{
    public GameObject shop;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerInRange) //Wenn die Leertaste losgelassen wird und der Spieler sich im Radius befindet
        {
            if (shop.activeInHierarchy)
            {
                shop.SetActive(false);                 //Dialogbox ist deaktiviert
            }
            else
            {
                shop.SetActive(true);                  //Dialogbox ist aktiviert
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
            shop.SetActive(false); //Dialogbox wird deaktiviert
        }
    }
}
