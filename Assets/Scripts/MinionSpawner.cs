using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    int minionsLeftToCreate;
    public int WaveSize {get; private set; } = 100;
    float spawnTimer;
    public float spawnFrequency = 3.0f;
    public GameObject minionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        minionsLeftToCreate = WaveSize;
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0) {
           SpawnMinion();
        }
        if (minionsLeftToCreate <= 0) 
        {
            Destroy(gameObject);
        }
    }

    void SpawnMinion()
    {
        GameObject minion = Instantiate(minionPrefab, this.transform.position, Quaternion.identity);
        MinionController mc = minion.GetComponent<MinionController>();
        mc.Path = MapPoints.Instance.MakePath();
        spawnTimer = spawnFrequency;
        minionsLeftToCreate--;
    }
}
