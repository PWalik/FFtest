using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for selecting the objects we look at
public class PlayerSelect: MonoBehaviour
{
    //currently selected gameobject
    [System.NonSerialized]
    public GameObject selectedObject;
    //check if we are currently lighting up any objects
    [System.NonSerialized]
    public bool isLit;
    PlayerCast cast;
    private void Start()
    {
        cast = GetComponent<PlayerCast>();
    }

    private void Update()
    {
        //if we are looking at a new object, light it up
        if(cast.SelectedObjectTransform != null && cast.SelectedObjectTransform != selectedObject)
        {
            if(selectedObject != null)
                UnlightObject(selectedObject);
            LightUpObject(cast.SelectedObjectTransform.gameObject);
        }
    }
    //call the Lit function of the current target object
    void LightUpObject(GameObject obj)
    {
        if (obj == null)
            return;
        ObjectSelectable select = obj.GetComponent<ObjectSelectable>();
        ObjectMultiSelectable multi = obj.GetComponent<ObjectMultiSelectable>();

        if (multi != null && !multi.IsLit)
        {
            selectedObject = obj;
            multi.Lit();
            isLit = true;
            return;
        }

        if (select != null && !select.IsLit)
        {
            selectedObject = obj;
            select.Lit();
            isLit = true;
            return;
        }   
    }
    //call the Unlit function of the target object
    void UnlightObject(GameObject obj)
    {
        if (obj == null)
            return;

        ObjectSelectable select = obj.GetComponent<ObjectSelectable>();
        ObjectMultiSelectable multi = obj.GetComponent<ObjectMultiSelectable>();

        //if it's an object made of multiple parts
        if (multi != null && multi.IsLit)
            multi.Unlit();
        //if it's not
        else if (select != null && select.IsLit)
            select.Unlit();

        selectedObject = null;
        isLit = false;
    }
}
