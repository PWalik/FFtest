using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script responsible for looking around with the mouse
public class PlayerMouseLook : MonoBehaviour
{
    //field for mouse sensitivity
    [SerializeField] private float mouseSensitivity;
    //fields for input name axis, found in Edit -> Project Settings -> Input -> Axes
    [SerializeField] private string mouseXName, mouseYName;
    [SerializeField] private Transform playerObject;
    private float yAxisClamp;
    private void Awake()
    {
        LockCursor();
    }


    private void Update()
    {
        LookAround();
    }

    //locks the cursor in place (in the center of the screen)
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //used for looking around, taking mouseX and mouseY axis and multiplying by the sensitivity
    void LookAround()
    {
        float mouseX = Input.GetAxis(mouseXName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYName) * mouseSensitivity * Time.deltaTime;
        yAxisClamp += mouseY;

        //we clamp the y axis so we cannot overshoot the look around
        if (yAxisClamp > 90.0f)
        {
            yAxisClamp = 90.0f;
            mouseY = 0;
            ClampYAxis(270.0f);
        }
        else if (yAxisClamp < -90.0f)
        {
            yAxisClamp = -90.0f;
            mouseY = 0;
            ClampYAxis(90.0f);
        }
        transform.Rotate(Vector3.left * mouseY);
        playerObject.Rotate(Vector3.up * mouseX);
    }

    //helps clamp the y axis to a given value
    void ClampYAxis(float value)
    {
        Vector3 eulerRot = transform.eulerAngles;
        eulerRot.x = value;
        transform.eulerAngles = eulerRot;
    }
}
