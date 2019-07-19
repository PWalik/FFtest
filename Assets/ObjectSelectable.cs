using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectable : MonoBehaviour
{

    public bool isLit = false;
    [SerializeField] Material litMaterial, unlitMaterial;

    private void Start()
    {
        GetComponent<Renderer>().material = unlitMaterial;
    }
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

    public void Unlit()
    {
        if (isLit)
        {
            GetComponent<Renderer>().material = unlitMaterial;
            isLit = false;
        }
    }
}
