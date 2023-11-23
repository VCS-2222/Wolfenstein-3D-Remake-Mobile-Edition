using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    [HideInInspector]
    public bool isOpened;

    public void OpenDoor()
    {
        if (isOpened)
            return;

        animator = GetComponent<Animator>();
        StartCoroutine(doorCycle());
    }

    IEnumerator doorCycle()
    {
        isOpened = true;
        animator.SetBool("open", true);

        yield return new WaitForSeconds(8);

        animator.SetBool("open", false);

        yield return new WaitForSeconds(2);

        isOpened = false;
    }
}