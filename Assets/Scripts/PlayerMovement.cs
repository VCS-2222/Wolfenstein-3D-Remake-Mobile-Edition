using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] CharacterController controller;
    [SerializeField] Joystick moveJoystick;

    Vector3 moveDirection;

    [Header("Variables")]
    [SerializeField] float currentSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] bool isRunning;

    private void Start()
    {
        currentSpeed = walkSpeed;
    }


    private void Update()
    {
        moveDirection = transform.forward * moveJoystick.Vertical + transform.right * moveJoystick.Horizontal;
    }

    private void FixedUpdate()
    {
        controller.Move((moveDirection * currentSpeed) * Time.deltaTime);

        if (controller.isGrounded)
            return;
        controller.Move(-Vector3.up * 9);
    }

    public void Run()
    {
        isRunning = !isRunning;

        if(isRunning)
        {
            //runButtonImage.color = Color.red;
            currentSpeed = runSpeed;
        }
        else
        {
            //runButtonImage.color = Color.white;
            currentSpeed = walkSpeed;
        }
    }
}