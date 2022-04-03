using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPositionActual;
    public Vector2 minPositionActual;
    public VectorValue maxPosition;
    public VectorValue minPosition;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition.initialValue = maxPositionActual;
        minPosition.initialValue = minPositionActual;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.initialValue.x, maxPosition.initialValue.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.initialValue.y, maxPosition.initialValue.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
