using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, Screen.fullScreen);
        Application.targetFrameRate = 80;
    }

    public void LoadLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void SetDifficulty(int difSet)
    {
        PlayerPrefs.SetInt("difficulty", difSet);
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}