using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public FloatValue xp;
    public bool beenActivated;
    public BoolValue value;
    public IntValue lvl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && beenActivated == false) //Wenn der Spieler sich im Radius befindet
        {
            beenActivated = true;
            value.RuntimeValue = true;
            xp.initialValue = 1f / lvl.RuntimeValue;
            this.gameObject.SetActive(false);
        }
    }
}
