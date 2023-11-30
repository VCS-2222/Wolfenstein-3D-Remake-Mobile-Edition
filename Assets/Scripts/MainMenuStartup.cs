using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStartup : MonoBehaviour
{
    [Header("Music Settings")]
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip epicStartupMusic;
    [SerializeField] AudioClip mainTheme;

    [Header("UI stuff")]
    [SerializeField] GameObject starterCanvas;
    [SerializeField] GameObject ratingCanvas;
    [SerializeField] GameObject artCanvas;
    [SerializeField] GameObject mainMenuCanvas;

    public void StartUp()
    {
        StartCoroutine(start());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator start()
    {
        musicAudioSource.clip = epicStartupMusic;
        musicAudioSource.Play();

        ratingCanvas.SetActive(true);
        starterCanvas.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        ratingCanvas.SetActive(false);
        artCanvas.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        musicAudioSource.clip = mainTheme;
        musicAudioSource.Play();

        mainMenuCanvas.SetActive(true);
        artCanvas.SetActive(false);
    }
}