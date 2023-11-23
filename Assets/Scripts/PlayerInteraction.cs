using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] bool interacting;

    void Update()
    {
        if (!interacting)
            return;

        Interact();
    }

    public void SetBool()
    {
        interacting = !interacting;
    }

    public void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 3);

        if (hit.collider == null)
            return;

        if(hit.transform.tag == "Door")
        {
            hit.transform.GetComponent<Door>().OpenDoor();
        }

        if (hit.transform.tag == "Secret")
        {
            hit.transform.GetComponent<SecretDoor>().OpenSecretDoor();
        }

        if (hit.transform.tag == "Slide")
        {
            hit.transform.GetComponent<SlideDoor>().OpenSlideDoor();
        }
    }
}