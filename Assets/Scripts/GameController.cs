using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public List<GameObject> towers;
    public GameObject minionSpawnerPrefab;
    public static int waveCounter = 0;
    public static List<int> waves = new List<int> {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

    static GameController instance;
    public static GameController Instance {get {return instance;}}
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        towers = new List<GameObject>();
    }

    public string GetGameState()
    {
        if (MinionController.minionsDestroyed >= waves.Sum())
        {
            return Constants.VICTORY;
        }
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

    public void Restart()
    {
        // reset wave
        waveCounter = 0;
        // reset minions destroyed
        MinionController.minionsDestroyed = 0;
        // reset player stats
        PlayerController.Instance.Reset();
        SceneManager.LoadScene("MainScene");
    }
}
