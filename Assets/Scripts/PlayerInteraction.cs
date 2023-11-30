using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] bool interacting;
    [SerializeField] PlayerStats stats;

    void Update()
    {
        if (!interacting)
            return;

        Interact();
    }

    public void SetBool()
    {
        interacting = !interacting;
    }

    public void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 3);

        if (hit.collider == null)
            return;

        if(hit.transform.tag == "Door")
        {
            hit.transform.GetComponent<Door>().OpenDoor();
        }

        if (hit.transform.tag == "Secret")
        {
            hit.transform.GetComponent<SecretDoor>().OpenSecretDoor();
        }

        if (hit.transform.tag == "Slide")
        {
            hit.transform.GetComponent<SlideDoor>().OpenSlideDoor();
        }

        if (hit.transform.tag == "End")
        {
            hit.transform.GetComponent<EndGameManager>().StartCoroutine(hit.transform.GetComponent<EndGameManager>().FinishLevel());
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Item")
        {
            //items

            if(collision.transform.GetComponent<Item>().ReturnHealthAdd() == true)
            {
                if (stats.ReturnHealth() == 100)
                    return;

                stats.GainHealth(collision.transform.GetComponent<Item>().addToHealth);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnHealthRemove() == true)
            {
                if (stats.ReturnHealth() == 0)
                    return;

                stats.TakeDamage(collision.transform.GetComponent<Item>().removeFromHealth);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnAmmoAdd() == true)
            {
                if (stats.ReturnAmmo() == 99)
                    return;

                stats.PickUpAmmo(collision.transform.GetComponent<Item>().addToAmmo);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnAmmoRemove() == true)
            {
                if (stats.ReturnAmmo() == 0)
                    return;

                stats.UseAmmo(collision.transform.GetComponent<Item>().removeFromAmmo);
                Destroy(collision.gameObject);
            }

            //if (collision.transform.GetComponent<Item>().ReturnLivesAdd() == true)
            //{
            //    stats.UseAmmo(collision.transform.GetComponent<Item>().removeFromAmmo);
            //}

            //if (collision.transform.GetComponent<Item>().ReturnLivesRemove() == true)
            //{
            //    stats.UseAmmo(collision.transform.GetComponent<Item>().removeFromAmmo);
            //}

            if (collision.transform.GetComponent<Item>().ReturnScoreAdd() == true)
            {
                stats.AddScore(collision.transform.GetComponent<Item>().addToScore);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnScoreRemove() == true)
            {
                stats.RemoveScore(collision.transform.GetComponent<Item>().removesFromScore);
                Destroy(collision.gameObject);
            }

            //guns

            if(collision.transform.GetComponent<Item>().ReturnKnife() == true)  //KNIFE
            {
                if (stats.hasKnife == true)
                    return;

                stats.PickUpGun(0);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnPistol() == true)    //PISTOL
            {
                if (stats.hasPistol == true)
                {
                    if (stats.ReturnAmmo() < 99)
                    {
                        stats.PickUpAmmo(15);
                    }
                    return;
                }

                stats.PickUpGun(1);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnSub() == true)   //SUB
            {
                if (stats.hasSub == true)
                {
                    if (stats.ReturnAmmo() < 99)
                    {
                        stats.PickUpAmmo(15);
                    }
                    return;
                }

                stats.PickUpGun(2);
                Destroy(collision.gameObject);
            }

            if (collision.transform.GetComponent<Item>().ReturnChain() == true) //CHAIN
            {
                if (stats.hasChain == true)
                {
                    if (stats.ReturnAmmo() < 99)
                    {
                        stats.PickUpAmmo(15);
                    }
                    return;
                }

                stats.PickUpGun(3);
                Destroy(collision.gameObject);
            }

            //treasure

            if (collision.transform.GetComponent<Item>().isTreasure == true)
            {
                stats.AddTreasures();
                stats.AddScore(collision.transform.GetComponent<Item>().addToScore);
                Destroy(collision.gameObject);
            }
        }
    }
}