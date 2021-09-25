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

    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
        Lives = maxLives;
        instance = this;
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
