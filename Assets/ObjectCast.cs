using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCast : MonoBehaviour
{
    public Transform selectedObjectTransform;
    public RaycastHit objectCast;
    public Transform lookingTransform;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, lookingTransform.TransformDirection(Vector3.forward), out objectCast))
        {
            selectedObjectTransform = objectCast.transform;
        }
        else selectedObjectTransform = null;
    }
}
