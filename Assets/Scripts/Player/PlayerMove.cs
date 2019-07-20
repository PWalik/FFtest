using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //names of the input axis for movement, taken from Edit -> Project Settings -> Input -> Axes
    [SerializeField] string horizontalInput, verticalInput;
    [SerializeField] float movementSpeed;
    private CharacterController charControl;
    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float vertical = Input.GetAxis(verticalInput) * movementSpeed;
        float horizontal = Input.GetAxis(horizontalInput) * movementSpeed;
        Vector3 forwardMove = transform.forward * vertical;
        Vector3 rightMove = transform.right * horizontal;
        charControl.SimpleMove(forwardMove + rightMove);
    }
}
