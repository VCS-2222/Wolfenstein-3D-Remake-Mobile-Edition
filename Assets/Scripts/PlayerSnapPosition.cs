using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnapPosition : MonoBehaviour
{
    public Vector3 desiredPosition;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move(new Vector3(this.transform.position.x, desiredPosition.y, this.transform.position.z));
    }
}
