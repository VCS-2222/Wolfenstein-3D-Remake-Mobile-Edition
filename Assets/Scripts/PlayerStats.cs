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
    [SerializeField] Image dropdownButtonImage;

    [Header("Important Variables")]
    [SerializeField] int maxHealth;
    [SerializeField] int minHealth;
    [SerializeField] int currentHealth;

    public bool hasKnife;
    public bool hasPistol;
    public bool hasSub;
    public bool hasChain;

    [SerializeField] int score;

    [SerializeField] int lives;

    [Header("Guns and Ammo")]
    [SerializeField] int ammo;
    public Transform gunShootPoint;
    public GameObject currentGunSelected;
    public GameObject[] gunArray;
    public Sprite[] gunHudSprites;
    public GameObject[] hudDropdownButtons;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MakeGunCurrent(1);

        CheckForSprites();

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
        if (currentHealth + gain > 100)
        {
            currentHealth = 100;
            UpdateHealth();
            return;
        }

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

    public int ReturnHealth()
    {
        return currentHealth;
    }
    #endregion health

    #region gun

    public void ShootGun()
    {
        if(!currentGunSelected)
            return;

        if (ammo <= 0)
        {
            MakeGunCurrent(0);
            return;
        }

        currentGunSelected.GetComponent<WeaponScript>().StartCoroutine(currentGunSelected.GetComponent<WeaponScript>().Shooting());
    }

    public void PickUpGun(int gunToPickUp)
    {
        if(gunToPickUp == 0)
        {
            hasKnife = true;
        }

        if(gunToPickUp == 1)
        {
            hasPistol = true;
        }

        if (gunToPickUp == 2)
        {
            hasSub = true;
        }

        if (gunToPickUp == 3)
        {
            hasChain = true;
        }

        CheckForSprites();
    }

    void CheckForSprites()
    {
        for (int i = 0; i < gunHudSprites.Length; i++)
        {
            hudDropdownButtons[i].SetActive(false);
        }

        if (hasKnife)
        {
            hudDropdownButtons[0].SetActive(true);
        }

        if (hasPistol)
        {
            hudDropdownButtons[1].SetActive(true);
        }

        if (hasSub)
        {
            hudDropdownButtons[2].SetActive(true);
        }

        if (hasChain)
        {
            hudDropdownButtons[3].SetActive(true);
        }
    }

    public void MakeGunCurrent(int numberInList)
    {
        for(int i = 0; i < gunArray.Length; i++)
        {
            gunArray[i].gameObject.SetActive(false);
        }

        if (hasKnife && numberInList == 0)
        {
            currentGunSelected = gunArray[numberInList];
            dropdownButtonImage.sprite = gunHudSprites[numberInList];
            gunArray[numberInList].SetActive(true);
        }

        if (hasPistol && numberInList == 1)
        {
            currentGunSelected = gunArray[numberInList];
            dropdownButtonImage.sprite = gunHudSprites[numberInList];
            gunArray[numberInList].SetActive(true);
        }

        if (hasSub && numberInList == 2)
        {
            currentGunSelected = gunArray[numberInList];
            dropdownButtonImage.sprite = gunHudSprites[numberInList];
            gunArray[numberInList].SetActive(true);
        }

        if (hasChain && numberInList == 3)
        {
            currentGunSelected = gunArray[numberInList];
            dropdownButtonImage.sprite = gunHudSprites[numberInList];
            gunArray[numberInList].SetActive(true);
        }
    }

    void UpdateAmmo()
    {
        ammoText.text = ammo.ToString();
    }

    public void PickUpAmmo(int amount)
    {
        if(ammo + amount > 99)
        {
            ammo = 99;
            UpdateAmmo();
            return;
        }

        ammo += amount;
        UpdateAmmo();
    }

    public void UseAmmo(int amount)
    {
        if (ammo <= 0)
            return;

        ammo -= amount;
        UpdateAmmo();
    }

    public int ReturnAmmo()
    {
        return ammo;
    }
    #endregion gun

    #region score

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void RemoveScore(int amount)
    {
        if (score <= 0)
            return;

        score -= amount;
        UpdateScore();
    }

    int ReturnScore()
    {
        return score;
    }

    #endregion score
}