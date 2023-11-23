using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJFacialExpressions : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        StartCoroutine(FaceCycle());
    }

    IEnumerator FaceCycle()
    {
        while (true)
        {
            animator.SetBool("cycle", true);

            yield return new WaitForSeconds(3);

            animator.SetBool("cycle", false);

            yield return new WaitForSeconds(3);
        }
    }

    public void ChangeFacialExpression(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}