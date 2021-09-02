using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
        if (GameController.Instance.GetGameState() == Constants.VICTORY 
            && gameOverPanel.activeSelf == false)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponentInChildren<Text>().text = "VICTORY";
        }
        if (GameController.Instance.GetGameState() == Constants.GAME_OVER 
            && gameOverPanel.activeSelf == false)
        {
            // don't show victory video if loss
            Destroy(gameOverPanel.GetComponentInChildren<VideoPlayer>().gameObject);
            gameOverPanel.SetActive(true);
        }
        
    }
}
