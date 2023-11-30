using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    Text fpsText;

    private void Start()
    {
        fpsText = GetComponent<Text>();
        StartCoroutine(FPS());
    }

    IEnumerator FPS()
    {
        while (true)
        {
            int fps = (int) (1f / Time.deltaTime);
            fpsText.text = "[" + fps + " Frames Per Second]";
            yield return new WaitForSeconds(.2f);
        }
    }
}