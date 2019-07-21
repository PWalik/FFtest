using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script responsible for handling the raycast, finding the object we are currently looking at
public class PlayerCast : MonoBehaviour
{
    //raycast reference
    RaycastHit objectCast;
    //transform we are shooting the raycast from
    [SerializeField] Transform lookingTransform;
    //transform of the currently looked up object
    public Transform selectedObjectTransform;
    //point where the object was hit;
    [System.NonSerialized] private Vector3 point;

    public Transform SelectedObjectTransform { get => selectedObjectTransform; }
    public Vector3 Point { get => point; }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(lookingTransform.position, lookingTransform.TransformDirection(Vector3.forward), out objectCast))
        {
            selectedObjectTransform = objectCast.transform;
            point = objectCast.point;
        }
        else
        {
            selectedObjectTransform = null;
            point = Vector3.zero;
        }
    }
}
