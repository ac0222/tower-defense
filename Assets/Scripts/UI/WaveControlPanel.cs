using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControlPanel : MonoBehaviour
{
    public Button sendNextWaveButton;

    // Start is called before the first frame update
    void Start()
    {
        sendNextWaveButton.onClick.AddListener(() => SendWave());
    }

    void SendWave()
    {
        GameController.Instance.CreateNextWave();    
    }
}
