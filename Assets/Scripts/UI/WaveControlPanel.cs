using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControlPanel : MonoBehaviour
{
    public Button sendNextWaveButton;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        sendNextWaveButton.onClick.AddListener(() => SendWave());
        restartButton.onClick.AddListener(() => RestartListener());
    }

    void SendWave()
    {
        GameController.Instance.CreateNextWave();    
    }

    void RestartListener()
    {
        Debug.Log("restart clicked");
    }
}
