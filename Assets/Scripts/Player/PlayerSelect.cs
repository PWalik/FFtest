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
    PlayerMain main;
    private void Start()
    {
        main = GetComponent<PlayerMain>();
    }

    private void Update()
    {
        //if we are looking at a new object, light it up
        if(main.Cast.selectedObjectTransform != null && main.Cast.selectedObjectTransform != selectedObject)
        {
            if(selectedObject != null)
                UnlightObject(selectedObject);
            LightUpObject(main.Cast.selectedObjectTransform.gameObject);
        }
    }
    //call the Lit function of the current target object
    void LightUpObject(GameObject obj)
    {
        if (obj == null)
            return;
        ObjectSelectable select = obj.GetComponent<ObjectSelectable>();
        if (select != null && !select.isLit)
        {
            selectedObject = obj;
            select.Lit();
            isLit = true;
        }   
    }
    //call the Unlit function of the previous target object
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
