using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float startingMoney = 10;
    public static float Money {get; private set;}
    static PlayerController instance = null;
    public static PlayerController Instance {get {return instance;}}
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ChangeMoney(float amount) 
    {
        Money += amount;
    }
}
