using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script responsible for the tip of the laser following the mouse in stage 1
public class FollowMouse : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    void Update()
    {
        float moveLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivity;

        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.Translate(new Vector3(moveLR, moveUD, 0));
    }
}
