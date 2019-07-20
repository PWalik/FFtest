using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script for the objects that can be selected by looking at them
public class ObjectSelectable : MonoBehaviour
{
    //check if the object is currently lit up
    public bool isLit = false;
    //two materials to swap when the object is lit and not
    [SerializeField] Material litMaterial, unlitMaterial;

    private void Start()
    {
        GetComponent<Renderer>().material = unlitMaterial;
    }
    //change the material to lit 
    public void Lit()
    {
        if (GetComponent<ObjectMovable>() != null && GetComponent<ObjectMovable>().isMoving)
            return;

        if(!isLit)
        {
            GetComponent<Renderer>().material = litMaterial;
            isLit = true;
        }
    }
    //change the material to unlit 
    public void Unlit()
    {
        if (isLit)
        {
            GetComponent<Renderer>().material = unlitMaterial;
            isLit = false;
        }
    }
}
