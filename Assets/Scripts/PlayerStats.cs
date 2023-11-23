using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [Header("Needed Components")]
    [SerializeField] BJFacialExpressions BJ;
    [SerializeField] Text healthText;
    [SerializeField] Text livesText;
    [SerializeField] Text ammoText;
    [SerializeField] Text scoreText;

    [Header("Important Variables")]
    [SerializeField] int maxHealth;
    [SerializeField] int minHealth;
    [SerializeField] int currentHealth;

    [SerializeField] bool hasKnife;
    [SerializeField] bool hasPistol;
    [SerializeField] bool hasSub;
    [SerializeField] bool hasChain;

    [SerializeField] int score;

    [SerializeField] int lives;

    [Header("Guns and Ammo")]
    [SerializeField] int ammo;
    public Transform gunShootPoint;
    public GameObject currentGunSelected;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateHealth();
        UpdateLives();
        UpdateAmmo();
        UpdateScore();
    }

    #region health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealth();
        CheckForHealthStatus();
    }

    public void GainHealth(int gain)
    {
        currentHealth += gain;
        UpdateHealth();
        CheckForHealthStatus();
    }

    public void GainLive()
    {
        lives++;
        UpdateLives();
    }

    public void LoseLive()
    {
        lives--;
        UpdateLives();
    }

    void CheckForHealthStatus()
    {
        if(currentHealth >= 90)
        {
            BJ.ChangeFacialExpression("healthy");
        }

        if(currentHealth <= 89 && currentHealth >= 80)
        {
            BJ.ChangeFacialExpression("slight hurt");
        }
    }

    void UpdateHealth()
    {
        healthText.text = currentHealth.ToString();
    }

    void UpdateLives()
    {
        livesText.text = lives.ToString();
    }

    float ReturnHealth()
    {
        return currentHealth;
    }
    #endregion health

    #region gun

    public void ShootGun()
    {
        if(!currentGunSelected)
            return;

        print("Shot");
        currentGunSelected.GetComponent<WeaponScript>().StartCoroutine(currentGunSelected.GetComponent<WeaponScript>().Shooting());
    }

    void UpdateAmmo()
    {
        ammoText.text = ammo.ToString();
    }

    int ReturnAmmo()
    {
        return ammo;
    }
    #endregion gun

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    int ReturnScore()
    {
        return score;
    }
}