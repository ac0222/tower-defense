using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton
public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static PlayerController Instance {
        get 
        {
            return instance;
        }
    }

    public int maxLives = 20;
    public int Lives {get; private set;}
    public float startingMoney = 1000;
    public float Money {get; private set;}

    public Inventory PlayerInventory;

    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
        Lives = maxLives;
        instance = this;
        InitInventory();
        Debug.Log(PlayerInventory.AvailableTurrets);
    }

    public void InitInventory()
    {
        PlayerInventory = new Inventory();
        PlayerInventory.AvailableTurrets.Add("Shinobi Lookout", 5);
        PlayerInventory.AvailableTurrets.Add("Upgraded Shinobi Lookout", 5);
        PlayerInventory.AvailableTurrets.Add("Byakuya", 5);

    }

    public void Reset()
    {
        Money = startingMoney;
        Lives = maxLives;
    }

    public void ChangeMoney(float amount) 
    {
        Money += amount;
    }

    public void ChangeLives(int amount) 
    {
        Lives += amount;
    }
}
