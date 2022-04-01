using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public IntValue Coins;
    public bool beenActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && beenActivated == false)
        {
            beenActivated = true;
            this.gameObject.SetActive(false);
            Coins.RuntimeValue += 10;
        }
    }
}
