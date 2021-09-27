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

    public int builders = 3;
    public int maxLives = 1000;
    public int Lives {get; private set;}
    public float startingMoney = 200;
    public float Money {get; private set;}

    public Inventory PlayerInventory;

    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
        Lives = maxLives;
        instance = this;
        InitInventory();
    }

    public void InitInventory()
    {
        PlayerInventory = new Inventory();
        PlayerInventory.AvailableTurrets.Add("Shinobi Lookout", 8);
        PlayerInventory.AvailableTurrets.Add("Eva01", 1);
        PlayerInventory.AvailableTurrets.Add("Byakuya", 1);
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

    public int NumberOfAvailableBuilders()
    {
        return builders - GameController.Instance.TurretsUnderConstruction().Count;
    }
}
