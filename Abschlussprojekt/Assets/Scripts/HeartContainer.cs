using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public FloatValue currentHealth;
    public FloatValue heartContainer;
    public bool beenActivated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && beenActivated == false) //Wenn der Spieler sich im Radius befindet
        {
            beenActivated = true;
            this.gameObject.SetActive(false);
            heartContainer.RuntimeValue += 1;
        }
    }
}
