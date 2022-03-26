using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        signalEvent.Invoke();   //Führt das angegebene Event aus
    }

    private void OnEnable()
    {
        signal.RegisterListener(this);  //Fügt dieses Objekt der Generischen-Liste in Signal hinzu
    }

    private void OnDisable()
    {
        signal.DeRegisterListener(this);    //Enfernt dieses Objekt in der Generischen-Liste in Signal
    }
}
