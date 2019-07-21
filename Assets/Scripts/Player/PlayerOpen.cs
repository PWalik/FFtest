using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script responsible for opening doors (either the exit door ending stage 2, or scannable doors to the rooms)
public class PlayerOpen : MonoBehaviour
{
    PlayerMain main;
    private void Start()
    {
        main = GetComponent<PlayerMain>();
    }
    public void DoorOpen()
    {


        if (main.Select == null || main.GameOver == null)
            return;


        if (main.Select.selectedObject.tag == "ExitDoor")
            main.GameOver.Win();


        if (main.Select.selectedObject.tag != "Door")
            return;


       if (main.GameOver.CheckIfLoseLife(main.Select.selectedObject, main.Ring.CurrRing))
            main.GameOver.LoseLife();
        else
            Destroy(main.Select.selectedObject); //temporary thing, should prob be just an animation of door opening
    }
}
