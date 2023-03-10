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
            msp.GetComponent<MinionSpawner>().waveInfo = WaveMetadata.Waves[waveCounter];
            waveCounter++;
            foreach(GameObject turretObject in turrets)
            {
                turretObject.GetComponent<BasicTurret>().NewWaveUpdate();
            }
        }
    }

    public void WaveCompleteActions(Wave waveInfo)
    {
        RewardPanelController rpcInstance = RewardPanelController.Instance;
        if (rpcInstance != null && waveInfo.YieldsReward)
        {
            RewardPanelController.Instance.gameObject.SetActive(true);
            RewardPanelController.Instance.GenerateAndShowRewards();
        }
        foreach(GameObject turretObject in turrets)
        {
            turretObject.GetComponent<BasicTurret>().WaveCompleteUpdate();
        }
        PlayerController.Instance.buildPoints += PlayerController.Instance.buildPointsPerWave;
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
            .Where((t) => {
                string status = t.GetComponent<BasicTurret>().Status;
                return status == Constants.BEING_BUILT || status == Constants.BEING_TORN_DOWN;
            })
            .ToList();
    }
}
