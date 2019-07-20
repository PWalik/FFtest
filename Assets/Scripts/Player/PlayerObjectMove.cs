using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectMove : MonoBehaviour
{
    PlayerSelect select;
    bool isMoving;
    GameObject movingObject;
    [SerializeField] Transform lookAtTransform, holdReferenceTransform;
    private void Start()
    {
        select = GetComponent<PlayerSelect>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && select.isLit && movingObject == false)
        {
            movingObject = select.selectedObject;
            movingObject.GetComponent<ObjectMovable>().isMoving = true; 
            isMoving = true;
        }
        else if(isMoving && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isMoving = false;
            movingObject.GetComponent<ObjectMovable>().isMoving = false; 
            movingObject.GetComponent<ObjectMovable>().ResetPlacement();
            movingObject = null;
        }

        if (isMoving)
            MoveObject(movingObject);
    }


    void MoveObject(GameObject obj)
    {
        if (obj.GetComponent<ObjectMovable>() == null)
            return;

        obj.transform.LookAt(lookAtTransform);
        obj.transform.position = holdReferenceTransform.position;
    }
}
