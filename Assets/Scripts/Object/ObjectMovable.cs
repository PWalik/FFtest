using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for objects that can be moved around
public class ObjectMovable : MonoBehaviour
{
    //starting rotation and position of the object - if we let go of the object without placing it on the avatar, it goes back to the original position
    Quaternion startRotation;
    Vector3 startPosition;
    //check if we are currently moving the object
    [System.NonSerialized] public bool isMoving;
    private void Start()
    {
        startRotation = transform.rotation;
        startPosition = transform.position;
    }
    //reset the placement of the object
    public void ResetPlacement()
    {
        transform.rotation = startRotation;
        transform.position = startPosition;
    }
}
