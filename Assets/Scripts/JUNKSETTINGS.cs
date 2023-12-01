using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUNKSETTINGS : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, Screen.fullScreen);
        Application.targetFrameRate = 60;
    }
}