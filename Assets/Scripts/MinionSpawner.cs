using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    float spawnTimer;
    public float spawnFrequency = 3.0f;
    public GameObject minionPrefab;
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0) {
            GameObject minion = Instantiate(minionPrefab, this.transform.position, Quaternion.identity);
            MinionController mc = minion.GetComponent<MinionController>();
            mc.Destination = destination;
            spawnTimer = spawnFrequency;
        }
    }
}
