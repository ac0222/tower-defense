using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    private int spawnIndex;
    private float spawnTimer;
    public List<GameObject> minionPrefabs;
    public List<SpawnEvent> waveInfo;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        spawnIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
           SpawnMinion();
        }
        if (spawnIndex >= waveInfo.Count) 
        {
            Destroy(gameObject);
        }
    }

    void SpawnMinion()
    {
        SpawnEvent currentSpawnEvent = waveInfo[spawnIndex];
        GameObject prefabToSpawn = minionPrefabs
            .FirstOrDefault(mp => mp.GetComponent<MinionController>().minionName == currentSpawnEvent.MinionPrefabName);
        GameObject minion = Instantiate(prefabToSpawn, this.transform.position, Quaternion.identity);
        MinionController mc = minion.GetComponent<MinionController>();
        mc.Path = MapPoints.Instance.MakePath();
        spawnTimer = currentSpawnEvent.TimeUntilNextSpawn;
        spawnIndex++;
    }
}
