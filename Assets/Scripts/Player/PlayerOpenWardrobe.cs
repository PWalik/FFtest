using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script responsible for opening the wardrobes in stage 1
public class PlayerOpenWardrobe : MonoBehaviour
{
    PlayerSelect select;
    void Start()
    {
        select = GetComponent<PlayerSelect>();
    }

    void Update()
    {
        if(select != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryOpen();
        }
    }

    //try to open the wardrobe
    void TryOpen()
    {
        if (select.selectedObject == null)
            return;
        ObjectOpenable open = select.selectedObject.GetComponent<ObjectOpenable>();
        if (open == null)
            return;
        //if it's open, close. If closed, open.
        if (open.IsOpen)
            open.Close();
        else open.Open();
    }
}
