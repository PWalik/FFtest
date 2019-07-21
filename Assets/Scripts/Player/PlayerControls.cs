using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script responsible for simplifying the controls in stage 2. Calls different scripts depending on the input 
public class PlayerControls : MonoBehaviour
{
    PlayerMain main;

    private void Start()
    {
        main = GetComponent<PlayerMain>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && main.Scan != null)
            main.Scan.Scan();

        if (Input.GetKeyDown(KeyCode.Mouse1) && main.Shoot != null)
            main.Shoot.Shoot();

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && main.Ring != null)
            main.Ring.RotateRingUp();

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && main.Ring != null)
            main.Ring.RotateRingDown();

        if (Input.GetKeyDown(KeyCode.Space) && main.Open != null)
            main.Open.DoorOpen();

    }
}
