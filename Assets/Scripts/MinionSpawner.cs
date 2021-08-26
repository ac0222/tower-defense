using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    float spawnTimer;
    public float spawnFrequency = 3.0f;
    public GameObject minionPrefab;
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
            mc.Path = MakePath();
            spawnTimer = spawnFrequency;
        }
    }

    Stack<Vector3> MakePath()
    {
        Stack<Vector3> path = new Stack<Vector3>();
        path.Push(new Vector3(0, 0, 0));
        path.Push(new Vector3(5, 5, 0));
        path.Push(new Vector3(1, 7, 0));
        path.Push(new Vector3(-3, 4, 0));
        return path;
    }
}
