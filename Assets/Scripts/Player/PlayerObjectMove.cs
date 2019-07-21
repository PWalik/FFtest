using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectMove : MonoBehaviour
{
    PlayerSelect select;
    PlayerCast cast;
    bool isMoving;
    GameObject movingObject;
    
    private void Start()
    {
        select = GetComponent<PlayerSelect>();
        cast = GetComponent<PlayerCast>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && select.isLit && movingObject == null)
        {
            StartMoving();
        }
        else if(isMoving && Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopMoving();
        }

        if (isMoving)
            MoveObject(movingObject);
    }


    void StartMoving()
    {
        if (select.selectedObject.GetComponent<ObjectMovable>() == null)
            return;

        movingObject = select.selectedObject;
        movingObject.GetComponent<Collider>().enabled = false;
        movingObject.GetComponent<ObjectMovable>().isMoving = true;
        isMoving = true;

        ObjectWearable wear = movingObject.GetComponent<ObjectWearable>();
        if(wear != null)
        {
            wear.StartIndicator();
        }
    }

    void StopMoving()
    {
        isMoving = false;
        movingObject.GetComponent<ObjectMovable>().isMoving = false;
        movingObject.GetComponent<Collider>().enabled = true;
        movingObject.GetComponent<ObjectMovable>().ResetPlacement();

        ObjectWearable wear = movingObject.GetComponent<ObjectWearable>();
        if (wear != null && cast.selectedObjectTransform == wear.ColliderIndicator)
        {
            wear.StartWearing();
        }


        movingObject = null;
    }



    void MoveObject(GameObject obj)
    {
        if (obj.GetComponent<ObjectMovable>() == null)
            return;

        obj.transform.position = cast.Point;
    }
}
