using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)  //Solange i gr��er oder gleich 0 ist
        {
            listeners[i].OnSignalRaised();              //Beim Objekt am Index i wird .OnSignalRaised() aufgerufen 
        }
    }

    public void RegisterListener(SignalListener listener)   //Add-Methode f�r listeners
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener) //Remove-Methode f�r listeners
    {
        listeners.Remove(listener);
    }
}
