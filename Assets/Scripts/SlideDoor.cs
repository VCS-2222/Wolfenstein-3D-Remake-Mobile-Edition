using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    Animator animator;
    [HideInInspector]
    public bool isOpened;

    public void OpenSlideDoor()
    {
        if (isOpened)
            return;

        animator = GetComponent<Animator>();

        isOpened = true;
        animator.SetBool("open", true);
    }
}