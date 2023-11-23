using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Needed Components")]
    [SerializeField] BJFacialExpressions BJ;
    [SerializeField] Text healthText;

    [Header("Important Variables")]
    [SerializeField] float maxHealth;
    [SerializeField] float minHealth;
    [SerializeField] float currentHealth;

    [SerializeField] bool hasKnife;
    [SerializeField] bool hasPistol;
    [SerializeField] bool hasSub;
    [SerializeField] bool hasChain;

    [SerializeField] int score;

    [SerializeField] int lives;

    [Header("Guns and Ammo")]
    [SerializeField] int ammo;
    [SerializeField] RaycastHit thingHit;
    [SerializeField] Transform gunShootPoint;
    public GameObject currentGunSelected;

    private void Start()
    {
        UpdateHealth();
    }

    #region health
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();
        CheckForHealthStatus();
    }

    public void GainHealth(float gain)
    {
        currentHealth += gain;
        UpdateHealth();
        CheckForHealthStatus();
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

    float ReturnHealth()
    {
        return currentHealth;
    }
    #endregion health

    #region gun
    public void Shoot()
    {
        Physics.Raycast(gunShootPoint.transform.position, gunShootPoint.transform.forward, out thingHit, 100);

        if(thingHit.transform.tag == "Enemy")
        {
            if (thingHit.transform.GetComponent<GermanTrooperAI>() != null)
            {
                thingHit.transform.GetComponent<GermanTrooperAI>().TakeDamage(5);
            }
        }
    }

    int ReturnAmmo()
    {
        return ammo;
    }
    #endregion gun

    int ReturnScore()
    {
        return score;
    }
}