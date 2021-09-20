using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int maxLives = 20;
    public static int Lives {get; private set;}
    public static float startingMoney = 1000;
    public static float Money {get; private set;}
    static PlayerController instance = null;
    public static PlayerController Instance {get {return instance;}}
    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
        Lives = maxLives;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Money = startingMoney;
        Lives = maxLives;
    }

    public static void ChangeMoney(float amount) 
    {
        Money += amount;
    }

    public static void ChangeLives(int amount) 
    {
        Lives += amount;
    }
}
