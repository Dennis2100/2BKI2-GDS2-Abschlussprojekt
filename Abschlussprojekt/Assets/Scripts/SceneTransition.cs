using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Vector3 playerPosition;
    public GameObject player;
    public VectorValue maxPosition;
    public VectorValue minPosition;
    public Vector2 maxPositionActual;
    public Vector2 minPositionActual;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        maxPosition.initialValue = maxPositionActual;
        minPosition.initialValue = minPositionActual;
        player.transform.position = playerPosition;
    }
}
