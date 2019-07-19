using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectMove : MonoBehaviour
{
    SelectedLight lit;
    bool isMoving;
    GameObject movingObject;
    [SerializeField] Transform lookAtTransform, holdReferenceTransform;
    private void Start()
    {
        lit = GetComponent<SelectedLight>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && lit.isLit && movingObject == false)
        {
            movingObject = lit.selectedObject;
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
