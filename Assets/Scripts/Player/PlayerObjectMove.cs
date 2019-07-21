using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script allowing the player to move objects around
public class PlayerObjectMove : MonoBehaviour
{
    PlayerSelect select;
    PlayerCast cast;
    //object we are currently moving
    GameObject movingObject;
    //are we currently moving any object?
    bool isMoving;
    private void Start()
    {
        select = GetComponent<PlayerSelect>();
        cast = GetComponent<PlayerCast>();
    }

    private void Update()
    {
       //conditions we need to meet before we can pick up the object
        if (Input.GetKeyDown(KeyCode.Mouse0) && select.isLit && movingObject == null)
        {
            StartMoving();
        }
        //what should happen before we drop the object
        else if(isMoving && Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopMoving();
        }
        //if we are moving the object, copy the mouse position into the object
        if (isMoving)
            MoveObject(movingObject);
    }

    //what happens when we pick up the object
    void StartMoving()
    {
        if (select.selectedObject.GetComponent<ObjectMovable>() == null)
            return;

        movingObject = select.selectedObject;
        movingObject.GetComponent<Collider>().enabled = false;
        movingObject.GetComponent<ObjectMovable>().isMoving = true;
        isMoving = true;

        //if the object can be worn by the avatar, spawn the indicator of where we should put it
        ObjectWearable wear = movingObject.GetComponent<ObjectWearable>();
        if(wear != null)
        {
            wear.StartIndicator();
        }
    }

    //what happens if we decide to drop the object
    void StopMoving()
    {
        isMoving = false;
        movingObject.GetComponent<ObjectMovable>().isMoving = false;
        movingObject.GetComponent<Collider>().enabled = true;
        movingObject.GetComponent<ObjectMovable>().ResetPlacement();

        //if the object is also wearable, do this
        ObjectWearable wear = movingObject.GetComponent<ObjectWearable>();
        if (wear != null)
        {
            //if we drop the object in a correct place to equip it
            if(cast.selectedObjectTransform == wear.ColliderIndicator)
            {
                wear.StartWearing(); //we start the sequence of equipping the item
            }
            else //or 
            {
                wear.StopIndicator(); //we turn of the indicator
            }
        }
        movingObject = null;
    }


    //what happens if we are currently moving the object - copy the position of the mouse to the object
    void MoveObject(GameObject obj)
    {
        if (obj.GetComponent<ObjectMovable>() == null)
            return;

        obj.transform.position = cast.Point;
    }
}
