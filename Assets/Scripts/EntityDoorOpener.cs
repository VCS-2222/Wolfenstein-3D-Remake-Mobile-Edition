using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDoorOpener : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")
        {
            other.GetComponent<Door>().OpenDoor();
        }
    }
}