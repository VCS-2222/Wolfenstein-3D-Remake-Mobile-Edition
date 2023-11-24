using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [Header("Customs")]
    [SerializeField] bool hasRange;
    [SerializeField] float range;
    [SerializeField] bool hasCooldown;
    [SerializeField] float cooldownSeconds;
    [SerializeField] int damageDeal;

    [SerializeField] bool usesBullets;

    [Header("Important Components")]
    public PlayerStats playerStats;

    private void Start()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    public IEnumerator Shooting()
    {
        if (hasCooldown)
        {
            Shoot(playerStats.gunShootPoint);

            if (usesBullets)
            {
                playerStats.UseAmmo(1);
            }

            yield return new WaitForSeconds(cooldownSeconds);
        }
        else
        {
            Shoot(playerStats.gunShootPoint);
            if (usesBullets)
            {
                playerStats.UseAmmo(1);
            }
        }
    }

    public void Shoot(Transform GunShootPoint)
    {
        RaycastHit thingHit;
        Physics.Raycast(GunShootPoint.position, GunShootPoint.forward, out thingHit, range);

        if (thingHit.transform.tag == "Enemy")
        {
            if (thingHit.transform.GetComponent<GermanTrooperAI>() != null)
            {
                thingHit.transform.GetComponent<GermanTrooperAI>().TakeDamage(damageDeal);
            }
        }
    }
}