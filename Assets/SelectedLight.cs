using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedLight : MonoBehaviour
{
    public GameObject selectedObject;
    ObjectCast cast;
    public bool isLit;
    private void Start()
    {
        cast = GetComponent<ObjectCast>();
    }

    private void Update()
    {
        if(cast.selectedObjectTransform != null && cast.selectedObjectTransform != selectedObject)
        {
            Debug.Log("yay");
            LightUpObject(cast.selectedObjectTransform.gameObject);
        }
        else if(isLit && cast.selectedObjectTransform != selectedObject)
        {
           UnlightObject(selectedObject);
        }
    }

    void LightUpObject(GameObject obj)
    {
        if (obj == null)
            return;
        ObjectSelectable select = obj.GetComponent<ObjectSelectable>();
        if (select != null && !select.isLit)
        {
            selectedObject = cast.selectedObjectTransform.gameObject;
            select.Lit();
            isLit = true;
        }   
    }

    void UnlightObject(GameObject obj)
    {
        if (obj == null)
            return;

        ObjectSelectable select = obj.GetComponent<ObjectSelectable>();
        if (select != null && select.isLit)
        {
            select.Unlit();
            selectedObject = null;
            isLit = false;
        }
    }
}
