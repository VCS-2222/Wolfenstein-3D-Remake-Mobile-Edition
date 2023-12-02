using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JUNKSETTINGS : MonoBehaviour
{
    static bool resolutionInitialised = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (resolutionInitialised == false)
        {
            Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, Screen.fullScreen);
            resolutionInitialised = true;
        }

        SceneManager.LoadScene(1);
    }
}