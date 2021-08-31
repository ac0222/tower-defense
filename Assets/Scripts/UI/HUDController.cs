using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Lives <= 0 && gameOverPanel.activeSelf == false)
        {
            gameOverPanel.SetActive(true);
        }
        
    }
}
