using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class WaveInfoPanel : MonoBehaviour
{
    public Button closeButton;
    public GameObject waveGrid;
    public GameObject waveInfoTextPrefab;

    public static WaveInfoPanel Instance {get; private set;}
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void UpdateWaveInfo()
    {
        ClearWaveGrid();
        foreach((Wave wave, int i) in WaveMetadata.Waves.Select((wv, i) => (wv, i)))
        {
            GameObject waveTextObject = Instantiate(waveInfoTextPrefab, Vector3.zero, Quaternion.identity);
            
            Text waveText = waveTextObject.GetComponentInChildren<Text>();
            waveText.text = $"Wave #{i+1} contains {wave.SpawnEvents.Count} enemies";
            
            waveTextObject.transform.SetParent(waveGrid.transform);
            waveTextObject.transform.localScale = Vector3.one;
        }
    }

    void ClearWaveGrid()
    {
        foreach(Transform t in waveGrid.transform)
        {
            Destroy(t.gameObject);
        }
    }
}
