using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        UnPauseGame();
        PlayerPrefs.DeleteKey("difficulty");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("difficulty");
        Application.Quit();
    }
}