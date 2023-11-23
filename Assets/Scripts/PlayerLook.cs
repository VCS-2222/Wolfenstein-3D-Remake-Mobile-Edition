using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject playerBody;
    [SerializeField] Joystick lookJoystick;

    [Header("Variables")]
    [SerializeField] float sensitivity;

    private void Update()
    {
        playerBody.transform.Rotate(((Vector3.up * lookJoystick.Horizontal) * sensitivity) * Time.deltaTime);
    }
}