using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [Header("Percentages")]
    public float killPercent;
    public float secretPercent;
    public float treasurePercent;

    public int bonus;

    [Header("Totals")]
    public int totalPossibleKills;
    public int totalSecrets;
    public int totalTreasures;

    [SerializeField] int parTime;

    [Header("In Level")]
    public int kills;
    public int secrets;
    public int treasures;
    public int timeOfLevel;

    [Header("UI")]
    [SerializeField] GameObject canvas;
    [SerializeField] Text killsText;
    [SerializeField] Text secretsText;
    [SerializeField] Text treasuresText;
    [SerializeField] Text timerText;
    [SerializeField] Text parTimeText;
    [SerializeField] Text bonusText;

    public IEnumerator FinishLevel()
    {
        kills = PlayerStats.instance.ReturnKills();
        secrets = PlayerStats.instance.ReturnSecrets();
        treasures = PlayerStats.instance.ReturnTreasures();
        timeOfLevel = PlayerStats.instance.ReturnMinutes() + PlayerStats.instance.ReturnTime();

        if(timeOfLevel < parTime)
        {
            bonus = 1000;
        }
        else if(timeOfLevel >= parTime)
        {
            bonus = 1500;
        }

        canvas.SetActive(true);

        timerText.text = string.Format("{00:00}:{01:00}", PlayerStats.instance.ReturnMinutes(), PlayerStats.instance.ReturnTime());
        bonusText.text = bonus.ToString();

        killPercent = ((float)kills / (float)totalPossibleKills) * 100;
        killsText.text = killPercent.ToString("0") + "%";

        secretPercent = ((float)secrets / (float)totalSecrets) * 100;
        secretsText.text = secretPercent.ToString("0") + "%";

        treasurePercent = ((float)treasures / (float)totalTreasures) * 100;
        treasuresText.text = treasurePercent.ToString("0") + "%";

        yield return new WaitForSeconds(0.5f);
    }

    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}