using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void TryOpen()
    {
        if (select.selectedObject == null)
            return;
        ObjectOpenable open = select.selectedObject.GetComponent<ObjectOpenable>();
        if (open == null)
            return;
        if (open.IsOpen)
            open.Close();
        else open.Open();
    }
}
