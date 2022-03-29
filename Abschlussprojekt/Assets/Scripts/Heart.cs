using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public FloatValue currentHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Wenn der Spieler sich im Radius befindet
        {
            this.gameObject.SetActive(false);
            currentHealth.RuntimeValue += 2;
        }
    }
}
