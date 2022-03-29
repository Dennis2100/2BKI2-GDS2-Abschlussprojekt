using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public FloatValue currentHealth;
    public FloatValue heartContainer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Wenn der Spieler sich im Radius befindet
        {
            this.gameObject.SetActive(false);
            heartContainer.RuntimeValue += 1;
        }
    }
}
