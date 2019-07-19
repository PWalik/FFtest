using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovable : MonoBehaviour
{
    Quaternion startRotation;
    Vector3 startPosition;
    public bool isMoving;
    private void Start()
    {
        startRotation = transform.rotation;
        startPosition = transform.position;
    }
    public void ResetPlacement()
    {
        transform.rotation = startRotation;
        transform.position = startPosition;
    }
}
