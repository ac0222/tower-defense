using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanelController : MonoBehaviour
{
    public Text livesText;
    public Text moneyText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lives: {PlayerController.Lives}";
        moneyText.text = $"Money: {PlayerController.Money}";
    }
}
