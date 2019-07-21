using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Object script similar to ObjectSelectable, but made for objects made of multiple parts - allows to light up multiple parts once the object is selected
public class ObjectMultiSelectable : MonoBehaviour
{
    //all parts of the object that need to be lit up
    [SerializeField] Renderer[] componentRenderers;
    //materials for when the object is currently lit up
    [SerializeField] Material litMaterial, unlitMaterial;
    //is the object currently lit or not?
    bool isLit;

    public bool IsLit { get => isLit; }

    //change material to lit
    public void Lit()
    {
        if (GetComponent<ObjectMovable>() != null && GetComponent<ObjectMovable>().isMoving)
            return;

        if (!isLit)
        {
            AssignMaterial(litMaterial);
            isLit = true;
        }
    }
    //change the material to unlit 
    public void Unlit()
    {
        if (isLit)
        {
            AssignMaterial(unlitMaterial);
            isLit = false;
        }
    }

    //assign the material to all parts
    void AssignMaterial(Material material)
    {
        for (int i = 0; i < componentRenderers.Length; i++)
        {
            componentRenderers[i].material = material;
        }
    }
}
