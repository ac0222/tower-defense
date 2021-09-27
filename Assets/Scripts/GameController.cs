using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


// Singleton
public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance {
        get 
        {
            return instance;
        } 
    }

    public List<GameObject> turrets;
    public GameObject minionSpawnerPrefab;
    public int waveCounter = 0;
    public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        instance = this;
        turrets = new List<GameObject>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (waveCounter < WaveMetadata.Waves.Count 
            && timeElapsed >= WaveMetadata.Waves[waveCounter].Timing)
        {
            CreateNextWave();
        }
    }

    public string GetGameState()
    {
        if (MinionController.minionsDestroyed >= WaveMetadata.TotalMinions)
        {
            return Constants.VICTORY;
        }
        if (PlayerController.Instance.Lives <= 0)
        {
            return Constants.GAME_OVER;
        }
        return Constants.IN_PROGRESS;
    }

    public void CreateNextWave()
    {
        if (waveCounter < WaveMetadata.Waves.Count)
        {
            GameObject msp = Instantiate(minionSpawnerPrefab, MapPoints.Instance.spawnPoint.transform.position, Quaternion.identity);  
            msp.GetComponent<MinionSpawner>().waveInfo = WaveMetadata.Waves[waveCounter].SpawnEvents;
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
        // reset turrets
        turrets = new List<GameObject>();
        SceneManager.LoadScene("MainScene");
    }

    public List<GameObject> TurretsUnderConstruction()
    {
        return turrets
            .Where(t => !t.GetComponent<BasicTurret>().IsBuilt)
            .ToList();
    }
}
