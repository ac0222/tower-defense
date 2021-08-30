using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControlPanel : MonoBehaviour
{
    public GameObject minionSpawnerPrefab;
    public Button sendNextWaveButton;

    // Start is called before the first frame update
    void Start()
    {
        sendNextWaveButton.onClick.AddListener(() => SendWave());
    }

    void SendWave()
    {
        Instantiate(minionSpawnerPrefab, MapPoints.Instance.spawnPoint.transform.position, Quaternion.identity);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
