using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject minionSpawnerPrefab;
    static int waveCounter = 0;
    static List<int> waves = new List<int> {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
    static GameController instance;
    public static GameController Instance {get {return instance;}}
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public string GetGameState()
    {
        if (PlayerController.Lives <= 0)
        {
            return Constants.GAME_OVER;
        }
        return Constants.IN_PROGRESS;
    }

    public void CreateNextWave()
    {
        if (waveCounter < waves.Count)
        {
            GameObject msp = Instantiate(minionSpawnerPrefab, MapPoints.Instance.spawnPoint.transform.position, Quaternion.identity);  
            msp.GetComponent<MinionSpawner>().WaveSize = waves[waveCounter];
            waveCounter++;
        }
    }
}