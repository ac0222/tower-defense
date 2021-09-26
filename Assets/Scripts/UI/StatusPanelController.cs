using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanelController : MonoBehaviour
{
    public Text livesText;
    public Text moneyText; 
    public Text waveText;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lives: {PlayerController.Instance.Lives}";
        moneyText.text = $"Money: {PlayerController.Instance.Money}";
        waveText.text = $"Wave: {GameController.Instance.waveCounter}/{WaveMetadata.Waves.Count}";
        timerText.text = $"Time: {GameController.Instance.timeElapsed:F2}";
    }
}
