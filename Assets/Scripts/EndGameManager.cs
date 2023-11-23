using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;

    [Header("Percentages")]
    public float killPercent;
    public float secretPercent;
    public float treasurePercent;

    public int bonus;

    [Header("Totals")]
    public int totalPossibleKills;
    public int totalSecrets;
    public int totalTreasures;

    [Header("In Level")]
    public int kills;
    public int secrets;
    public int treasures;

    [Header("UI")]
    [SerializeField] GameObject canvas;
    [SerializeField] Text killsText;
    [SerializeField] Text secretsText;
    [SerializeField] Text treasuresText;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator FinishLevel()
    {
        canvas.SetActive(true);

        killPercent = ((float)kills / (float)totalPossibleKills) * 100;
        killsText.text = killPercent.ToString("0") + "%";

        secretPercent = ((float)secrets / (float)totalSecrets) * 100;
        secretsText.text = secretPercent.ToString("0") + "%";

        treasurePercent = ((float)treasures / (float)totalTreasures) * 100;
        treasuresText.text = treasurePercent.ToString("0") + "%";

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}