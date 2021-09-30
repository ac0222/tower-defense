using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusPanelController : MonoBehaviour, IPointerClickHandler
{
    public Text livesText;
    public Text moneyText; 
    public Text waveText;
    public Text timerText;
    public Text buildersCounter;

    // Update is called once per frame
    void Update()
    {
        livesText.text = $"Lives: {PlayerController.Instance.Lives}";
        moneyText.text = $"Money: {PlayerController.Instance.Money}";
        waveText.text = $"Wave: {GameController.Instance.waveCounter}/{WaveMetadata.Waves.Count}";
        buildersCounter.text = $"Build Points: {PlayerController.Instance.buildPoints}";
        timerText.text = $"Time: {GameController.Instance.timeElapsed:F2}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string clickedName = eventData.pointerCurrentRaycast.gameObject.name;
        if (clickedName == "CurrentWave")
        {
            WaveInfoPanel.Instance.gameObject.SetActive(true);
            WaveInfoPanel.Instance.UpdateWaveInfo();
        }
    } 
}
