using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMultiSelectable : MonoBehaviour
{
    [SerializeField] Renderer[] componentRenderers;
    [SerializeField] Material litMaterial, unlitMaterial;
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


    void AssignMaterial(Material material)
    {
        for (int i = 0; i < componentRenderers.Length; i++)
        {
            componentRenderers[i].material = material;
        }
    }
}
