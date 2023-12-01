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

    [SerializeField] Text endGameScoreText;
    [SerializeField] Text endGameAmmoText;
    [SerializeField] Text endGameLivesText;
    [SerializeField] Text endGameHealthText;

    [SerializeField] GameObject currentWeaponSelectedSprite;
    [SerializeField] GameObject[] listOfWeaponSprites;
    [SerializeField] GameObject nextLevelButton;

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

        endGameAmmoText.text = PlayerStats.instance.ReturnAmmo().ToString();
        endGameHealthText.text = PlayerStats.instance.ReturnHealth() + "%";
        endGameLivesText.text = PlayerStats.instance.ReturnLives().ToString();

        if(PlayerStats.instance.currentGunSelected.name == "Knife")
        {
            currentWeaponSelectedSprite = listOfWeaponSprites[0];
        }
        else if (PlayerStats.instance.currentGunSelected.name == "Pistol")
        {
            currentWeaponSelectedSprite = listOfWeaponSprites[1];
        }
        else if (PlayerStats.instance.currentGunSelected.name == "Sub Machine Gun")
        {
            currentWeaponSelectedSprite = listOfWeaponSprites[2];
        }
        else if (PlayerStats.instance.currentGunSelected.name == "Chain Gun")
        {
            currentWeaponSelectedSprite = listOfWeaponSprites[3];
        }

        currentWeaponSelectedSprite.SetActive(true);

        timerText.text = string.Format("{00:00}:{01:00}", PlayerStats.instance.ReturnMinutes(), PlayerStats.instance.ReturnTime());
        bonusText.text = bonus.ToString();

        killPercent = ((float)kills / (float)totalPossibleKills) * 100;
        killsText.text = killPercent.ToString("0") + "%";

        secretPercent = ((float)secrets / (float)totalSecrets) * 100;
        secretsText.text = secretPercent.ToString("0") + "%";

        treasurePercent = ((float)treasures / (float)totalTreasures) * 100;
        treasuresText.text = treasurePercent.ToString("0") + "%";

        endGameScoreText.text = PlayerStats.instance.ReturnScore() + killPercent + secretPercent + treasurePercent + PlayerStats.instance.ReturnLives() + PlayerStats.instance.ReturnHealth().ToString();

        yield return new WaitForSeconds(0.5f);

        nextLevelButton.SetActive(true);
    }

    //public void MoveToNextLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}