using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("States")]
    [SerializeField] bool addsHealth;
    [SerializeField] bool removesHealth;
    [SerializeField] bool addsAmmo;
    [SerializeField] bool removesAmmo;
    [SerializeField] bool addsLives;
    [SerializeField] bool removeLives;
    [SerializeField] bool addsScore;
    [SerializeField] bool removeScore;
    public bool isTreasure;

    [Header("Variables")]
    public int addToHealth;
    public int removeFromHealth;
    public int addToAmmo;
    public int removeFromAmmo;
    public int addToLives;
    public int removesFromLives;
    public int addToScore;
    public int removesFromScore;

    [Header("Guns")]
    [SerializeField] bool giveKnife;
    [SerializeField] bool givePistol;
    [SerializeField] bool giveSub;
    [SerializeField] bool giveChain;

    public bool ReturnHealthAdd()
    {
        return addsHealth;
    }

    public bool ReturnHealthRemove()
    {
        return removesHealth;
    }

    public bool ReturnAmmoAdd()
    {
        return addsAmmo;
    }

    public bool ReturnAmmoRemove()
    {
        return removesAmmo;
    }

    public bool ReturnLivesAdd()
    {
        return addsLives;
    }

    public bool ReturnLivesRemove()
    {
        return removeLives;
    }

    public bool ReturnScoreAdd()
    {
        return addsScore;
    }

    public bool ReturnScoreRemove()
    {
        return removeScore;
    }


    public bool ReturnKnife()
    {
        return giveKnife;
    }

    public bool ReturnPistol()
    {
        return givePistol;
    }

    public bool ReturnSub()
    {
        return giveSub;
    }

    public bool ReturnChain()
    {
        return giveChain;
    }
}